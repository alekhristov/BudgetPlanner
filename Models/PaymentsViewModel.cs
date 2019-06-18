using BudgetPlanner.Data.Models;
using System.Collections.Generic;

namespace BudgetPlanner.Models
{
    public class PaymentsViewModel
    {
        public PaymentsViewModel()
        {
            this.Payments = new List<Payment>();
        }

        public IList<Payment> Payments { get; set; }
    }
}
