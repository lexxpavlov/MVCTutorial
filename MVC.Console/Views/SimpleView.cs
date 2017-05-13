using System.Collections.Generic;
using System.Linq;
using MVC.Console.Utils;
using MVC.Core.Models;
using MVC.Core.Views;

namespace MVC.Console.Views
{
    public class SimpleView : AbstractView<SimpleModel, DoubleModel>
    {
        private Dictionary<Operation, string> _operations = new Dictionary<Operation, string>
        {
            {Operation.Add, "Сложение"},
            {Operation.Sub, "Вычитание"},
            {Operation.Mul, "Умножение"},
            {Operation.Div, "Деление"}
        };

        public override SimpleModel GetModel()
        {
            double x = ConsoleHelper.ReadDouble("Введите первое число: ");
            double y = ConsoleHelper.ReadDouble("Введите второе число: ");
            Operation operation = GetOperation();

            return new SimpleModel(x, y, operation);
        }

        private Operation GetOperation()
        {
            System.Console.WriteLine("Список операций:");
            int n = 1;
            foreach (var op in _operations)
            {
                System.Console.WriteLine("{0} - {1}", n++, op.Value);
            }

            int choice;
            do
            {
                choice = ConsoleHelper.ReadInt("Выберите опреацию: ");
            } while (choice < 1 || choice > _operations.Count);

            return _operations.Keys.ToList()[choice - 1];
        }

        public override void PrintResult(DoubleModel result)
        {
            System.Console.WriteLine("Результат: {0}", result.Number);
        }
    }
}
