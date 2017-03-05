using MVC.Calculation;
using MVC.Views;

namespace MVC
{
    public class CalcController
    {
        private readonly CommonView _commonView = new CommonView();

        public void Run()
        {
            do
            {
                double result;
                switch (_commonView.GetViewIndex())
                {
                    case 0:
                        var simpleView = new SimpleView();
                        var simpleModel = simpleView.GetModel();
                        result = new SimpleCalculator(simpleModel).Calc();
                        simpleView.PrintResult(result);
                        break;
                    case 1:
                        var squareRootView = new SquareRootView();
                        var squareRootModel = squareRootView.GetModel();
                        result = new SquareRootCalculator(squareRootModel).Calc();
                        squareRootView.PrintResult(result);
                        break;
                    default:
                        continue;
                }
            } while (_commonView.RunAgain());
        }
    }
}
