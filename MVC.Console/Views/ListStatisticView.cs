using System.Collections.Generic;
using MVC.Core.Models;
using MVC.Core.Views;

namespace MVC.Console.Views
{
    public class ListStatisticView : AbstractView<ListModel, ListStatisticModel>
    {
        public string Title { get { return "Статистика списка чисел"; } }

        public override ListModel GetModel()
        {
            var list = new List<double>();
            System.Console.WriteLine("Введите список чисел (Enter - окончание ввода списка):");
            int count = 1;
            do
            {
                System.Console.Write("Введите {0}-й элемент: ", count);
                string s = System.Console.ReadLine();
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
                    System.Console.WriteLine("Неверный ввод. Повторите ввод числа или нажмите Enter для окончания ввода.");
                }
            } while (true);
            return new ListModel(list);
        }

        public override void PrintResult(ListStatisticModel result)
        {
            if (result == null)
            {
                System.Console.WriteLine("Неверный тип результата");
                return;
            }
            System.Console.WriteLine("Результат:");
            System.Console.WriteLine("  Минимальное число: {0}", result.Min);
            System.Console.WriteLine("  Максимальное число: {0}", result.Max);
            System.Console.WriteLine("  Среднее значение: {0}", result.Average);
        }
    }
}
