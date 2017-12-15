﻿using GOOS_Sample.DataModels;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Interface;
using GOOS_Sample.Service;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetService budgetServiceStub;

        public BudgetController()
        {
            this.budgetServiceStub = new BudgetService();
        }

        public BudgetController(IBudgetService budgetServiceStub)
        {
            this.budgetServiceStub = budgetServiceStub;
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            this.budgetServiceStub.Create(model);
            ViewBag.Message = "added successfully";
            return View(model);
        }
    }
}