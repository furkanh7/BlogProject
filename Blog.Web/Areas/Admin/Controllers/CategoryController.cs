using AutoMapper;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.DTOs.Categories;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using Blog.Web.ResultMessages;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public CategoryController(ICategoryService categoryService,IValidator<Category> validator, IMapper mapper,IToastNotification toast) 
        {
            this.categoryService = categoryService;
            this.validator = validator;
            this.mapper = mapper;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(categoryAddDto);
                toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
                result.AddToModelState(this.ModelState);
                return View();
           

        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await categoryService.GetCategoryByGuid(categoryId);
            var map = mapper.Map<Category,CategoryUpdateDto>(category);

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
          
            var map = mapper.Map<Category>(categoryUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await categoryService.UpdateCategoryAsync(categoryUpdateDto);
             
                toast.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "Başarılı" });

                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);
            return View();
        }

        public async Task<IActionResult> Delete(Guid categoryId)
        {

            var name = await categoryService.SafeDeleteCategoryAsync(categoryId);
            toast.AddWarningToastMessage(Messages.Category.Delete(name), new ToastrOptions { Title = " İşlem Başarılı" });


            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

    }
}
