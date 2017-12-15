using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOOS_SampleTests.Steps;
using FluentAutomation;

namespace GOOS_SampleTests.PageObjects
{
    public class BudgetCreatePage : PageObject<BudgetCreatePage>
    {        
        public BudgetCreatePage(FluentTest test) : base(test)
        {
            this.Url = $"{PageContext.Domain}/budget/add";
        }

        internal BudgetCreatePage Amount(int amount)
        {
            I.Enter(amount.ToString()).In("#amount");
            return this;
        }

        internal BudgetCreatePage Month(string yearMonth)
        {
            I.Enter(yearMonth.ToString()).In("#month");
            return this;
        }

        internal void AddBudget()
        {
            I.Click("input[type=\"submit\"]");
        }

        internal void ShouldDisplay(string message)
        {
            I.Assert.Text(message).In("#message");
        }
    }
}
