using BudgetPlanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetPlanner.Data
{
    public static class DatabaseInitializer
    {
        public async static void Initialize(BudgetPlannerDbContext dbContext)
        {
            try
            {
                dbContext.Database.EnsureCreated();
                if (!dbContext.Categories.Any())
                {
                    var budget = new Budget();
                    var categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Groceries",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Shopping",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Restaurants",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Transport",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Travel",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Entertaiment",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Health",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Services",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Utilities",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Cash",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Transfer",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Insurance",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Sport",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        },
                        new Category()
                        {
                            Name = "Home",
                            DateCreated = DateTime.UtcNow,
                            Budget = budget
                        }
                    };
                    dbContext.Categories.AddRange(categories);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
