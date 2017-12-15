using GOOS_Sample.Controllers;
using GOOS_Sample.Interface;
using GOOS_Sample.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOOS_SampleTests.Controllers
{
    [TestClass()]
    public class BudgetControllerTests
    {
        private BudgetController _budgetController;
        private IBudgetService budgetServiceStub = Substitute.For<IBudgetService>();
        [TestMethod()]
        public void AddTest_add_budget_successfully_should_invoke_budgetService_Create_one_time()
        {
            this._budgetController = new BudgetController(budgetServiceStub);
            var model = new BudgetAddViewModel()
            {
                Amount = 2000,
                Month = "2017-02"
            };

            var result = this._budgetController.Add(model);

            budgetServiceStub.Received()
                             .Create(Arg.Is<BudgetAddViewModel>(x => x.Amount == 2000 && x.Month == "2017-02"));
        }
    }
}
