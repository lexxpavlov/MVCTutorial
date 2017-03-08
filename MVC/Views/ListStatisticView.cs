using MVC.Models;
using MVC.Utils;
using System;
using System.Collections.Generic;

namespace MVC.Views
{
    public class ListStatisticView : ICalculationView
    {
        public string Title { get { return "Статистика списка чисел"; } }

        public IDataModel GetModel()
        {
            var list = new List<double>();
            Console.WriteLine("Введите список чисел (Enter - окончание ввода списка):");
            int count = 1;
            do
            {
                Console.Write("Введите {0}-й элемент: ", count);
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                {
                    break;
                }
                double number;
                if (double.TryParse(s, out number))
                {
                    list.Add(number);
                    count++;
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Повторите ввод числа или нажмите Enter для окончания ввода.");
                }
            } while (true);
            return new ListModel(list);
        }

        public void PrintResult(IDataModel result)
        {
            var model = result as ListStatisticModel;
            if (model == null)
            {
                Console.WriteLine("Неверный тип результата");
                return;
            }
            Console.WriteLine("Результат:");
            Console.WriteLine("  Минимальное число: {0}", model.Min);
            Console.WriteLine("  Максимальное число: {0}", model.Max);
            Console.WriteLine("  Среднее значение: {0}", model.Average);
        }
    }
}
