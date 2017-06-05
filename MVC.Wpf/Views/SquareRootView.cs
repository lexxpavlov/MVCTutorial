using System;
using MVC.Core.Models;

namespace MVC.Wpf.Views
{
    class SquareRootView : CalculationViewModelBase<DoubleModel, DoubleModel>
    {
        #region Square root calculation

        private double _result;

        public double Number { get; set; }

        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }
        
        #endregion

        #region CalculationViewModelBase

        public override int ViewNumber => 1;
        public override Type ViewControlType => typeof(Controls.SquareRootView);

        #endregion

        #region AbstractView

        public override DoubleModel GetModel()
        {
            return new DoubleModel(Number);
        }

        public override void PrintResult(DoubleModel result)
        {
            Result = result.Number;
        }

        #endregion
    }
}
