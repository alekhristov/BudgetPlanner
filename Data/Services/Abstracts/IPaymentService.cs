using BudgetPlanner.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetPlanner.Data.Services.Abstracts
{
    public interface IPaymentService
    {
        Task AddPayment(Payment payment);

        Task DeletePayment(int paymentId);

        Task EditPayment(Payment payment);

        Task<Payment> GetPayment(int paymentId);

        Task<ICollection<Payment>> GetPaymentsForUser(string userId);

        Task<ICollection<Category>> FindCategoriesByUser(string userId);
    }
}
