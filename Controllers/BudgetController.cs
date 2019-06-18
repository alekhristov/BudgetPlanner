using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BudgetPlanner.Data.Services.Abstracts;
using BudgetPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.Controllers
{
    public class BudgetController : AbstractController
    {
        private readonly IBudgetService budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            this.budgetService = budgetService;
        }

        public async Task<IActionResult> Index()
        {
            var budgetsViewModel = new BudgetsViewModel();
            var userBudgets = await this.budgetService.GetBudgetsForUser(GetUserId());

            foreach (var b in userBudgets)
            {
                budgetsViewModel.Budgets.Add(b);
            }

            return View(budgetsViewModel);
        }
    }
}