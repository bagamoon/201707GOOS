using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Interface
{
    public interface IBudgetService
    {
        void Create(BudgetAddViewModel budgetAddViewModel);
    }
}