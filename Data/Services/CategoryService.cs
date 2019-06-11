using BudgetPlanner.Data.Models;
using BudgetPlanner.Data.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetPlanner.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BudgetPlannerDbContext dbContext;

        public CategoryService(BudgetPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// For populating DB
        /// </summary>
        public async Task AddCategoriesRange(ICollection<Category> categories)
        {
            this.dbContext.Categories.AddRange(categories);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddCategory(Category category)
        {
            this.dbContext.Categories.Add(category);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await this.GetCategory(categoryId);

            this.dbContext.Categories.Remove(category);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DisableCategory(int categoryId)
        {
            var category = await this.GetCategory(categoryId);

            category.IsDisabled = true;
            await this.EditCategory(category);
        }

        public async Task EditCategory(Category category)
        {
            var categoryToUpdate = await this.dbContext.Categories.FindAsync(category.Id) ?? throw new NullReferenceException("No such category exists!");

            this.dbContext.Categories.Update(category);
            await this.dbContext.SaveChangesAsync();
        }

        public Task<ICollection<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            var category = await this.dbContext.Categories.FindAsync(categoryId) ?? throw new NullReferenceException("No such category exists!");

            return category;
        }
    }
}
