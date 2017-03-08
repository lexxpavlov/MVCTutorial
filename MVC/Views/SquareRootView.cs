using MVC.Models;
using MVC.Views.Validators;
using MVC.Utils;
using System;

namespace MVC.Views
{
    public class SquareRootView : ICalculationView
    {
        public string Title { get { return "Расчёт квадратного корня"; } }

        public IDataModel GetModel()
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

        public void PrintResult(IDataModel result)
        {
            var model = result as DoubleModel;
            if (model == null)
            {
                Console.WriteLine("Неверный тип результата");
                return;
            }

            Console.WriteLine("Результат: {0}", model.Number);
        }
    }
}
