using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BudgetPlanner.Data.Models;
using BudgetPlanner.Data.Services.Abstracts;
using BudgetPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetPlanner.Controllers
{
    public class PaymentController : AbstractController
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public async Task<IActionResult> Index()
        {
            var paymentsViewModel = new PaymentsViewModel();
            var userPayments = await this.paymentService.GetPaymentsForUser(GetUserId());
            var qry = from p in userPayments
                      orderby p.Date descending, p.Category.Name
                      select p;
 
            foreach (var b in qry)
            {
                paymentsViewModel.Payments.Add(b);
            }

            return View(paymentsViewModel);
        }

        public IActionResult Create()
        {
            PopulateCategoriesDropDownList();
            return View();
        }

        private async void PopulateCategoriesDropDownList(object selectedCategory = null)
        {
            var categories = await this.paymentService.FindCategoriesByUser(GetUserId());
            var qry = from c in categories
                      orderby c.BudgetId descending, c.Name
                      select c;
            ViewBag.CategoryId = new SelectList(qry, "Id", "Name", selectedCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Amount,Comment,CategoryId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                await paymentService.AddPayment(payment);
                return RedirectToAction(nameof(Index));
            }
            PopulateCategoriesDropDownList(payment.CategoryId);
            return View(payment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payment payment = null;
            try
            {
                payment = await paymentService.GetPayment(id.Value);
            }
            catch (Exception e)
            {
                payment = null;
            }

            if (payment == null || payment.Category.Budget.ApplicationUserId != GetUserId())
            {
                return NotFound();
            }
            PopulateCategoriesDropDownList(payment.CategoryId);
            return View(payment);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payment payment = null;
            try
            {
                payment = await paymentService.GetPayment(id.Value);
            }
            catch (Exception e)
            {
                payment = null;
            }

            if (payment == null || payment.Category.Budget.ApplicationUserId != GetUserId())
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Payment>(payment,
                "",
                p => p.Date, p => p.Amount, p => p.Comment, p => p.CategoryId))
            {
                try
                {
                    await paymentService.EditPayment(payment);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }

            PopulateCategoriesDropDownList(payment.CategoryId);
            return View(payment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payment payment = null;
            try
            {
                payment = await paymentService.GetPayment(id.Value);
            }
            catch (Exception e)
            {
                payment = null;
            }

            if (payment == null || payment.Category.Budget.ApplicationUserId != GetUserId())
            {
                return NotFound();
            }

            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payment payment = null;
            try
            {
                payment = await paymentService.GetPayment(id.Value);
            }
            catch (Exception e)
            {
                payment = null;
            }

            if (payment == null || payment.Category.Budget.ApplicationUserId != GetUserId())
            {
                return NotFound();
            }

            await paymentService.DeletePayment(payment.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}