using System;
using System.Collections.Generic;
using System.Linq;
using MVC.Models;
using MVC.Utils;

namespace MVC.Views
{
    public class SimpleView : ICalculationView
    {
        private Dictionary<Operation, string> _operations = new Dictionary<Operation, string>
        {
            {Operation.Add, "Сложение"},
            {Operation.Sub, "Вычитание"},
            {Operation.Mul, "Умножение"},
            {Operation.Div, "Деление"}
        };

        public string Title { get { return "Расчёт арифметических операций"; } }

        public IDataModel GetModel()
        {
            double x = ConsoleHelper.ReadDouble("Введите первое число: ");
            double y = ConsoleHelper.ReadDouble("Введите второе число: ");
            Operation operation = GetOperation();

            return new SimpleModel(x, y, operation);
        }

        private Operation GetOperation()
        {
            Console.WriteLine("Список операций:");
            int n = 1;
            foreach (var op in _operations)
            {
                Console.WriteLine("{0} - {1}", n++, op.Value);
            }

            int choice;
            do
            {
                choice = ConsoleHelper.ReadInt("Выберите опреацию: ");
            } while (choice < 1 || choice > _operations.Count);

            return _operations.Keys.ToList()[choice - 1];
        }

        public void PrintResult(double result)
        {
            Console.WriteLine("Результат: {0}", result);
        }
    }
}
