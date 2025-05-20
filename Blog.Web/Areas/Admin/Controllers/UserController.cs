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

        public UserController(UserManager<AppUser> userManager, IUserService userService, IUnitOfWork unitOfWork, RoleManager<AppRole> roleManager, IImageHelper imageHelper, IValidator<AppUser> validator, SignInManager<AppUser> signInManager, IMapper mapper, IToastNotification toast)
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


            var result = await userService.DeleteUserAsync(userId);



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

            var profile = await userService.GetUserProfileAsync();

            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            

            if (ModelState.IsValid)
            {
                var result = await userService.UserProfileUpdateAsync(userProfileDto);


                if(result)
                {
                    toast.AddSuccessToastMessage("Profil güncelleme işlemi tamamlandı" ,new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await userService.GetUserProfileAsync();
                    toast.AddErrorToastMessage("Profil güncelleme işlemi tamamlanamadı", new ToastrOptions { Title = "Başarısız" });
                    return View(profile);
                }

            }
            else 
               return NotFound();



        }
    }
}


