using BudgetPlanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.Data.Services.Abstracts
{
    public interface ICategoryService
    {
        Task AddCategory(Category category);

        Task AddCategoriesRange(ICollection<Category> categories);

        Task<ICollection<Category>> GetAllCategories();

        Task<Category> GetCategory(int categoryId);

        Task EditCategory(Category category);

        Task DeleteCategory(int categoryId);

        Task DisableCategory(int categoryId);
    }
}
