using MVC.Core.Models;

namespace MVC.Core.Calculation
{
    public interface ICalculator
    {
        IDataModel Model { get; }
        IDataModel Calc();
    }

    public interface ICalculator<TModel, TResult>: ICalculator where TModel : IDataModel where TResult : IDataModel
    {
        new TModel Model { get; }
        new TResult Calc();
    }
}
