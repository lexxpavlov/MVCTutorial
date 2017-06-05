using System;
using System.Collections.Generic;
using MVC.Core;
using MVC.Core.Calculation;
using MVC.Core.Models;
using MVC.Core.Views;

namespace MVC.Wpf.Views
{
    class CommonView : ViewModelBase, ICommonView
    {
        private readonly CalcController _calcController;

        public List<IComputation> Computations { get; } = new List<IComputation>
        {
            new Computation<SimpleModel, DoubleModel>("Арифметические расчёты", typeof(SimpleCalculator), typeof(SimpleView)),
            new Computation<DoubleModel, DoubleModel>("Расчёт квадратного корня", typeof(SquareRootCalculator), typeof(SquareRootView)),
            new Computation<ListModel, ListStatisticModel>("Статистика списка чисел", typeof(ListStatisticCalculator), typeof(ListStatisticView)),
        };

        public IComputation CurrentComputation { get; set; }
        public int CurrentNumber { get; set; }

        public CommonView()
        {
            _calcController = new CalcController(this, Computations);
        }

        public void Run()
        {
            _calcController.Run();
        }

        public IComputation GetComputation(List<IComputation> computations)
        {
            return CurrentComputation;
        }

        public bool RunAgain()
        {
            return true;
        }
    }
}
