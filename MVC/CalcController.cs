using MVC.Calculation;
using MVC.Views;

namespace MVC
{
    public class CalcController
    {
        public void Run()
        {
            var view = new SimpleView();
            do
            {
                var model = view.GetModel();
                var result = new SimpleCalculator(model).Calc();
                view.PrintResult(result);
            } while (view.RunAgain());
        }
    }
}
