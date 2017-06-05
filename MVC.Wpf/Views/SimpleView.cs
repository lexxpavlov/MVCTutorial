using System;
using System.Collections.Generic;
using System.Linq;
using MVC.Core.Models;

namespace MVC.Wpf.Views
{
    class SimpleView : CalculationViewModelBase<SimpleModel, DoubleModel>
    {
        #region Simple calculation

        private double _result;

        public double X { get; set; }
        public double Y { get; set; }
        public Operation Operation { get; set; }

        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }

        public List<Operation> Operations { get; set; } = ((Operation[])Enum.GetValues(typeof(Operation))).ToList();

        #endregion

        #region CalculationViewModelBase

        public override int ViewNumber => 0;
        public override Type ViewControlType => typeof(Controls.SimpleView);

        #endregion

        #region AbstractView

        public override SimpleModel GetModel()
        {
            return new SimpleModel(X, Y, Operation);
        }

        public override void PrintResult(DoubleModel result)
        {
            Result = result.Number;
        }

        #endregion
    }
}
