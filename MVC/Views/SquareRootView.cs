using MVC.Models;
using MVC.Utils;
using System;

namespace MVC.Views
{
    public class SquareRootView
    {
        public DoubleModel GetModel()
        {
            double number = ConsoleHelper.ReadDouble("Введите число: ");
            return new DoubleModel(number);
        }

        public void PrintResult(double result)
        {
            Console.WriteLine("Результат: {0}", result);
        }
    }
}
