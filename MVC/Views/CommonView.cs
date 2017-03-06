using System;
using System.Collections.Generic;
using System.Linq;
using MVC.Utils;

namespace MVC.Views
{
    class CommonView
    {
        public ICalculationView GetView(List<ICalculationView> views)
        {
            Console.WriteLine("Расчёты:");
            int n = 1;
            foreach (var view in views)
            {
                Console.WriteLine("{0} - {1}", n++, view.Title);
            }

            int choice;
            do
            {
                choice = ConsoleHelper.ReadInt("Выберите расчёт: ");
            } while (choice < 1 || choice > views.Count);

            return views[choice - 1];
        }

        public bool RunAgain()
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
