using BudgetPlanner.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetPlanner.Data.Models
{
    public class Category : ModelBase
    {
        public Category()
        {
            this.Payments = new HashSet<Payment>();
        }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Category name must be between 2 and 50 symbols")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        public bool IsDisabled { get; set; }

        public decimal PlannedAmount { get; set; }

        public decimal CurrentAmount { get; set; }

        public int BudgetId { get; set; }

        public Budget Budget { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<Payment> Payments { get; set; }
    }
}
