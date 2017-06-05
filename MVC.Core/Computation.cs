using System;
using MVC.Core.Calculation;
using MVC.Core.Models;
using MVC.Core.Views;

namespace MVC.Core
{
    public interface IComputation
    {
        string Title { get; }
        Type CalculatorType { get; }
        Type ViewType { get; }
        ICalculationView View { get; }
        ICalculator GetCalculator(IDataModel model);
    }

    public class Computation<TModel, TResult> : IComputation 
        where TModel : IDataModel 
        where TResult : IDataModel
    {
        public string Title { get; }
        public Type CalculatorType { get; }
        public Type ViewType { get; }
        public ICalculationView View { get; }

        public Computation(string title, Type calculatorType, Type viewType)
        {
            Title = title;
            CalculatorType = calculatorType;
            ViewType = viewType;
            View = (ICalculationView)Activator.CreateInstance(viewType);
        }        

        public ICalculator GetCalculator(IDataModel model)
        {
            return (ICalculator)Activator.CreateInstance(CalculatorType, model);
        }

    }
}
