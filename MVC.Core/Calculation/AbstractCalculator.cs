using MVC.Core.Models;

namespace MVC.Core.Calculation
{
    public abstract class AbstractCalculator<TModel, TResult> : ICalculator<TModel, TResult> where TModel : IDataModel where TResult : IDataModel
    {
        public abstract TModel Model { get; protected set; }

        public abstract TResult Calc();

        IDataModel ICalculator.Model
        {
            get { return Model; }
        }

        IDataModel ICalculator.Calc()
        {
            return Calc();
        }
    }
}
