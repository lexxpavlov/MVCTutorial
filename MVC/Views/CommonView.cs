using System;
using System.Collections.Generic;
using System.Linq;
using MVC.Utils;

namespace MVC.Views
{
    class CommonView
    {
        private readonly List<string> _views = new List<string>
        {
            "Расчёт арифметических операций",
            "Расчёт квадратного корня",
        };

        public int GetViewIndex()
        {
            Console.WriteLine("Расчёты:");
            int n = 1;
            foreach (var view in _views)
            {
                Console.WriteLine("{0} - {1}", n++, view);
            }

            int choice;
            do
            {
                choice = ConsoleHelper.ReadInt("Выберите расчёт: ");
            } while (choice < 1 || choice > _views.Count);

            return choice - 1;
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
