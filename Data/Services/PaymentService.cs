using BudgetPlanner.Data.Models;
using BudgetPlanner.Data.Services.Abstracts;
using System;
using System.Threading.Tasks;

namespace BudgetPlanner.Data.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly BudgetPlannerDbContext dbContext;

        public PaymentService(BudgetPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPayment(Payment payment)
        {
            this.dbContext.Payments.Add(payment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeletePayment(int paymentId)
        {
            var payment = await this.GetPayment(paymentId);

            this.dbContext.Remove(payment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditPayment(Payment payment)
        {
            await this.GetPayment(payment.Id);

            this.dbContext.Update(payment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Payment> GetPayment(int paymentId)
        {
            var payment = await this.dbContext.Payments.FindAsync(paymentId) ?? throw new NullReferenceException("There is no such payment!");

            return payment;
        }
    }
}
