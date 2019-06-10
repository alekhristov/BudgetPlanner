using BudgetPlanner.Data.Models.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetPlanner.Data.Models
{
    public class ApplicationUser : ModelBase
    {
        public ApplicationUser()
        {
            this.Budgets = new HashSet<Budget>();
        }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 symbols")]
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int PaymentId { get; set; }

        public Payment Payment { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<Budget> Budgets { get; set; }
    }

    public enum Gender
    {
        MALE,
        FEMALE
    }
}
