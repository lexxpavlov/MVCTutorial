using System;
using System.Collections.Generic;
using System.Linq;
using MVC.Utils;

namespace MVC.Views
{
    class CommonView
    {
        public IComputation GetComputation(List<IComputation> computations)
        {
            Console.WriteLine("Расчёты:");
            int n = 1;
            foreach (var computation in computations)
            {
                Console.WriteLine("{0} - {1}", n++, computation.Title);
            }

            int choice;
            do
            {
                choice = ConsoleHelper.ReadInt("Выберите расчёт: ");
            } while (choice < 1 || choice > computations.Count);

            return computations[choice - 1];
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
