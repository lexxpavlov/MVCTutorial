using MVC.Core.Models;

namespace MVC.Core.Views
{
    public abstract class AbstractView<TModel, TResult> : ICalculationView<TModel, TResult> where TModel : IDataModel where TResult : IDataModel
    {
        public abstract TModel GetModel();
        public abstract void PrintResult(TResult result);

        IDataModel ICalculationView.GetModel()
        {
            return GetModel();
        }

        void ICalculationView.PrintResult(IDataModel result)
        {
            PrintResult((TResult)result);
        }
    }
}
