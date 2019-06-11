using BudgetPlanner.Data.Models;
using System.Threading.Tasks;

namespace BudgetPlanner.Data.Services.Abstracts
{
    public interface IPaymentService
    {
        Task AddPayment(Payment payment);

        Task DeletePayment(int paymentId);

        Task EditPayment(Payment payment);

        Task<Payment> GetPayment(int paymentId);
    }
}
