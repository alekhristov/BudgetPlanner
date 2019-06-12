using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetPlanner.Data.Services.Abstracts;
using BudgetPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categoriesViewModel = new CategoriesViewModel();
            var categories = await this.categoryService.GetAllCategories();

            foreach (var category in categories)
            {
                categoriesViewModel.Categories.Add(category.Name);
            }

            return View(categoriesViewModel);
        }
    }
}