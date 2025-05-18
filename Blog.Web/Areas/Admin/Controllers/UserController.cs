using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Entity.Enums;
using Blog.Service.Extensions;
using Blog.Service.Helpers.Images;
using Blog.Service.Services.Abstractions;
using Blog.Web.ResultMessages;
using FluentValidation;
//using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using NToastNotify;
using static Blog.Web.ResultMessages.Messages;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IImageHelper imageHelper;
        private readonly IValidator<AppUser> validator;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public UserController(UserManager<AppUser> userManager,IUserService userService ,IUnitOfWork unitOfWork, RoleManager<AppRole> roleManager, IImageHelper imageHelper, IValidator<AppUser> validator, SignInManager<AppUser> signInManager, IMapper mapper, IToastNotification toast)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
            this.roleManager = roleManager;
            this.imageHelper = imageHelper;
            this.validator = validator;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
           var result = await userService.GetAllUserWithRoleAsync();

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await userService.GetAllRolesAsync();
            return View(new UserAddDto
            {
                Roles = roles
            });
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);
            var roles = await roleManager.Roles.ToListAsync();

            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserAsync(userAddDto);
                if (result.Succeeded)
                {               
                    toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarılı" });
                    RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                { 
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);

                    return View(new UserAddDto
                    {
                        Roles = roles
                    });


                }



            }
            return View(new UserAddDto
            {
                Roles = roles
            });
        }

      
        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userService.GetAppUserByIdAsync(userId);
            var roles = await userService.GetAllRolesAsync();

            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;

            var userRoles = await userManager.GetRolesAsync(user);
            var userRole = userRoles.FirstOrDefault();

            if (userRole != null)
            {
                var role = await roleManager.FindByNameAsync(userRole);
                map.RoleId = role.Id;
            }

            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);

            if (user != null)
            {
                var roles = await userService.GetAllRolesAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validation = await validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userService.UpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {

                            toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Başarılı" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            validation.AddToModelState(this.ModelState);

                            return View(new UserUpdateDto
                            {
                                Roles = roles
                            });


                        }

                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto
                        {
                            Roles = roles
                        });
                    }


                }
            }

            return NotFound();


        }

        public async Task<IActionResult> Delete(Guid userId)
        {
            

            var result =  await userService.DeleteUserAsync(userId);



            if (result.identityResult.Succeeded)
            {

                toast.AddSuccessToastMessage(Messages.User.Delete(result.email), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });

            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);

            }
            return NotFound();



        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {

            var user = await userManager.GetUserAsync(HttpContext.User);
            var getImage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == user.Id, x=>x.Image );
            var map = mapper.Map<UserProfileDto>(user);
            map.Image.FileName = getImage.Image.FileName;

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var IsVerified = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
                if (IsVerified && userProfileDto.NewPassword != null && userProfileDto.Photo != null)
                {
                    var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await userManager.UpdateSecurityStampAsync(user);
                        await signInManager.SignOutAsync();
                        await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

                        user.FirstName = userProfileDto.FirstName;
                        user.LastName = userProfileDto.LastName;
                        user.PhoneNumber = userProfileDto.PhoneNumber;

                        var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName} ", userProfileDto.Photo, ImageType.User);
                        Image image = new Image
                        (
                            imageUpload.FullName,
                            userProfileDto.Photo.ContentType,
                        user.Email

                            );

                        await unitOfWork.GetRepository<Image>().AddAsync(image);

                        user.ImageId = image.Id;


                        await userManager.UpdateAsync(user);

                        await unitOfWork.SaveAsync();


                        toast.AddSuccessToastMessage("Şifreniz ve Bilgileriniz Başarıyla Güncellenmiştir ");
                        return View();

                    }
                    else

                        result.AddToIdentityModelState(this.ModelState);
                    return View();


                }

                else if (IsVerified && userProfileDto.Photo != null)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    user.FirstName = userProfileDto.FirstName;
                    user.LastName = userProfileDto.LastName;
                    user.PhoneNumber = userProfileDto.PhoneNumber;
                    var imageUpload = await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName} ", userProfileDto.Photo, ImageType.User);
                    Image image = new Image
                    (
                        imageUpload.FullName,
                        userProfileDto.Photo.ContentType,
                    user.Email

                        );

                    await unitOfWork.GetRepository<Image>().AddAsync(image);

                    user.ImageId = image.Id;


                    await userManager.UpdateAsync(user);

                    await unitOfWork.SaveAsync();
                  
                    toast.AddSuccessToastMessage("Bilgileriniz Başarıyla Güncellenmiştir ");
                    return View();


                }
                else
                    toast.AddErrorToastMessage("Bilgileriniz Güncellenirken Bir Hata Oluştu ");
                return View();
            }
            return View();


        }
    }
}


