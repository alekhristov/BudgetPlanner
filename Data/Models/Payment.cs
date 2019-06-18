using BudgetPlanner.Data.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetPlanner.Data.Models
{
    public class Payment : ModelBase
    {
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = "Comment must be between 0 and 100 symbols")]
        public string Comment { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
