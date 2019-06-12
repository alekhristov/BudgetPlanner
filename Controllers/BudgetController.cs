using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetPlanner.Data.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IBudgetService budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            this.budgetService = budgetService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}