using MVC.Console.Utils;
using MVC.Core.Models;
using MVC.Core.Views;
using MVC.Core.Views.Validators;

namespace MVC.Console.Views
{
    public class SquareRootView : AbstractView<DoubleModel, DoubleModel>
    {
        public override DoubleModel GetModel()
        {
            double number;
            do
            {
                number = ConsoleHelper.ReadDouble("Введите число: ");
                var error = new NotNegativeValidator().Validate(number);
                if (string.IsNullOrEmpty(error))
                {
                    break;
                }
                System.Console.WriteLine(error);
            } while (true);
            return new DoubleModel(number);
        }

        public override void PrintResult(DoubleModel model)
        {
            System.Console.WriteLine("Результат: {0}", model.Number);
        }
    }
}
