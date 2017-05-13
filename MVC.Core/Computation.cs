using System;
using MVC.Core.Calculation;
using MVC.Core.Models;
using MVC.Core.Views;

namespace MVC.Core
{
    public interface IComputation
    {
        string Title { get; }
        ICalculationView GetView();
        ICalculator GetCalculator(IDataModel model);
    }

    public class Computation<TModel, TResult> : IComputation 
        where TModel : IDataModel 
        where TResult : IDataModel
    {
        private Type _calculatorType;
        private Type _viewType;

        public string Title { get; private set; }
        
        public Computation(string title, Type calculatorType, Type viewType)
        {
            Title = title;
            _calculatorType = calculatorType;
            _viewType = viewType;
        }

        public ICalculationView GetView()
        {
            return (ICalculationView)Activator.CreateInstance(_viewType);
        }

        public ICalculator GetCalculator(IDataModel model)
        {
            return (ICalculator)Activator.CreateInstance(_calculatorType, model);
        }

    }
}
