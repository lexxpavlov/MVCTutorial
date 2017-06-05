using System;
using System.ComponentModel;
using MVC.Core.Models;
using MVC.Core.Views;

namespace MVC.Wpf.Views
{
    public interface ICalculationViewModel
    {
        int ViewNumber { get; }
        Type ViewControlType { get; }
    }

    internal abstract class CalculationViewModelBase<TModel, TResult> : AbstractView<TModel, TResult>, ICalculationViewModel, INotifyPropertyChanged
        where TModel : IDataModel 
        where TResult : IDataModel
    {
        public abstract int ViewNumber { get; }
        public abstract Type ViewControlType { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            
        }
    }
}
