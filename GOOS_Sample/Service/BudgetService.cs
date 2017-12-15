using GOOS_Sample.DataModels;
using GOOS_Sample.Interface;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Service
{
    public class BudgetService : IBudgetService
    {
        public void Create(BudgetAddViewModel model)
        {
            using (var dbcontext = new GOOSEntities())
            {
                var budget = new Budget() { Amount = model.Amount, YearMonth = model.Month };
                dbcontext.Budgets.Add(budget);
                dbcontext.SaveChanges();
            }
        }
    }
}