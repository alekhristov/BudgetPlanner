using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetPlanner.Data.Models.Abstracts
{
    public class ModelBase
    {
        [Key]
        public int Id { get; set; }
    }
}
