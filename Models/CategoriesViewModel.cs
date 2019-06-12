using System.Collections.Generic;

namespace BudgetPlanner.Models
{
    public class CategoriesViewModel
    {
        public CategoriesViewModel()
        {
            this.Categories = new List<string>();
        }

        public IList<string> Categories { get; set; }
    }
}
