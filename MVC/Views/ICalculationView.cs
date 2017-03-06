using MVC.Models;

namespace MVC.Views
{
    public interface ICalculationView
    {
        string Title { get; }

        IDataModel GetModel();

        void PrintResult(double result);
    }
}
