using BudgetPlanner.Data.Models;
using BudgetPlanner.Data.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<Payment>> GetPaymentsForUser(string userId)
        {
            return await this.dbContext.Payments
                .Include(b => b.Category)
                .Include(b => b.Category.Budget)
                .Where(b => b.Category.Budget.ApplicationUserId == userId)
                .ToListAsync();
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
            var payment = await this.dbContext.Payments
                .Include(b => b.Category)
                .Include(b => b.Category.Budget)
                .FirstOrDefaultAsync(x => x.Id == paymentId) ?? throw new NullReferenceException("There is no such payment!");

            return payment;
        }

        public async Task<ICollection<Category>> FindCategoriesByUser(string userId)
        {
            return await this.dbContext.Categories.Where(b => b.Budget.ApplicationUserId == userId).ToListAsync();
        }
    }
}
