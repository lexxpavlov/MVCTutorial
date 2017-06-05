using System;
using System.Collections.ObjectModel;
using System.Linq;
using MVC.Core.Models;

namespace MVC.Wpf.Views
{
    class ListStatisticView : CalculationViewModelBase<ListModel, ListStatisticModel>
    {
        #region List statistic calculation

        private double _min;
        private double _max;
        private double _average;

        public ObservableCollection<double> List { get; set; } = new ObservableCollection<double>();

        public double Min
        {
            get { return _min; }
            set
            {
                _min = value;
                RaisePropertyChanged(nameof(Min));
            }
        }

        public double Max
        {
            get { return _max; }
            set
            {
                _max = value;
                RaisePropertyChanged(nameof(Max));
            }
        }

        public double Average
        {
            get { return _average; }
            set
            {
                _average = value;
                RaisePropertyChanged(nameof(Average));
            }
        }

        #endregion

        #region CalculationViewModelBase

        public override int ViewNumber => 2;
        public override Type ViewControlType => typeof(Controls.ListStatisticView);

        #endregion

        #region AbstractView

        public override ListModel GetModel()
        {
            return new ListModel(List.ToList());
        }

        public override void PrintResult(ListStatisticModel result)
        {
            Min = result.Min;
            Max = result.Max;
            Average = result.Average;
        }

        #endregion
    }
}
