using MVC.Models;

namespace MVC.Calculation
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
