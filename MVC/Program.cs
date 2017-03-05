using MVC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC
{
    class Program
    {
        private static Dictionary<Operation, string> _operations = new Dictionary<Operation, string>
        {
            {Operation.Add, "Сложение"},
            {Operation.Sub, "Вычитание"},
            {Operation.Mul, "Умножение"},
            {Operation.Div, "Деление"}
        };

        static void Main(string[] args)
        {
            do
            {
                double x = ConsoleHelper.ReadDouble("Введите первое число: ");
                double y = ConsoleHelper.ReadDouble("Введите второе число: ");
                var operation = GetOperation();

                double result = Calc(x, y, operation);
                Console.WriteLine("Результат: {0}", result);
            } while (RunAgain());
        }

        private static Operation GetOperation()
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

        private static double Calc(double x, double y, Operation operation)
        {
            switch (operation)
            {
                case Operation.Add:
                    return x + y;
                case Operation.Sub:
                    return x - y;
                case Operation.Mul:
                    return x * y;
                case Operation.Div:
                    return x / y;
            }
            throw new ArgumentException(string.Format("Неизвестная операция: {0}", operation));
        }

        private static bool RunAgain()
        {
            do
            {
                Console.WriteLine("Запустить ещё раз? [Enter - да, Esc - выход]");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        return true;
                    case ConsoleKey.Escape:
                        return false;
                }
            } while (true);
        }
    }
}
