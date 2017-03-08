using MVC.Calculation;
using MVC.Views;
using System.Collections.Generic;

namespace MVC
{
    public class CalcController
    {
        private readonly List<ICalculationView> _views = new List<ICalculationView>
        {
            new SimpleView(),
            new SquareRootView(),
            new ListStatisticView(),
        };

        private readonly CommonView _commonView = new CommonView();

        public void Run()
        {
            do
            {
                var view = _commonView.GetView(_views);
                var model = view.GetModel();
                var result = Calculator.Calc(model);
                view.PrintResult(result);
            } while (_commonView.RunAgain());
        }
    }
}
