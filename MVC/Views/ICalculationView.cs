using MVC.Models;

namespace MVC.Views
{
    public interface ICalculationView
    {
        IDataModel GetModel();
        void PrintResult(IDataModel result);
    }

    public interface ICalculationView<TModel, TResult> : ICalculationView where TModel : IDataModel where TResult : IDataModel
    {
        new TModel GetModel();
        void PrintResult(TResult result);
    }
}
