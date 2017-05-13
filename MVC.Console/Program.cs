using System.Collections.Generic;
using MVC.Console.Views;
using MVC.Core;
using MVC.Core.Calculation;
using MVC.Core.Models;

namespace MVC.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var computations = new List<IComputation>
            {
                new Computation<SimpleModel, DoubleModel>("Арифметические расчёты", typeof(SimpleCalculator), typeof(SimpleView)),
                new Computation<DoubleModel, DoubleModel>("Расчёт квадратного корня", typeof(SquareRootCalculator), typeof(SquareRootView)),
                new Computation<ListModel, ListStatisticModel>("Статистика списка чисел", typeof(ListStatisticCalculator), typeof(ListStatisticView)),
            };

            var calcController = new CalcController(new CommonView(), computations);
            bool again;
            do
            {
                again = calcController.Run();
            } while (again);
        }
    }
}
