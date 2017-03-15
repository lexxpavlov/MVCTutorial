using MVC.Models;
using MVC.Views.Validators;
using MVC.Utils;
using System;

namespace MVC.Views
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
                Console.WriteLine(error);
            } while (true);
            return new DoubleModel(number);
        }

        public override void PrintResult(DoubleModel model)
        {
            Console.WriteLine("Результат: {0}", model.Number);
        }
    }
}
