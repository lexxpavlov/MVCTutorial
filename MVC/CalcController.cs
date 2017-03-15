using MVC.Calculation;
using MVC.Models;
using MVC.Views;
using System.Collections.Generic;

namespace MVC
{
    public class CalcController
    {
        private readonly List<IComputation> _computations = new List<IComputation>
        {
            new Computation<SimpleModel, DoubleModel>("Арифметические расчёты", typeof(SimpleCalculator), typeof(SimpleView)),
            new Computation<DoubleModel, DoubleModel>("Расчёт квадратного корня", typeof(SquareRootCalculator), typeof(SquareRootView)),
            new Computation<ListModel, ListStatisticModel>("Статистика списка чисел", typeof(ListStatisticCalculator), typeof(ListStatisticView)),
        };

        private readonly CommonView _commonView = new CommonView();

        public void Run()
        {
            do
            {
                var computation = _commonView.GetComputation(_computations);
                var view = computation.GetView();
                var model = view.GetModel();
                var result = computation.GetCalculator(model).Calc();
                view.PrintResult(result);
            } while (_commonView.RunAgain());
        }
    }
}
