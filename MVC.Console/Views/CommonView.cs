using System.Collections.Generic;
using MVC.Console.Utils;
using MVC.Core;
using MVC.Core.Views;

namespace MVC.Console.Views
{
    class CommonView : ICommonView
    {
        public IComputation GetComputation(List<IComputation> computations)
        {
            System.Console.WriteLine("Расчёты:");
            int n = 1;
            foreach (var computation in computations)
            {
                System.Console.WriteLine("{0} - {1}", n++, computation.Title);
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
                System.Console.WriteLine("Запустить ещё раз? [Enter - да, Esc - выход]");
                switch (System.Console.ReadKey(true).Key)
                {
                    case System.ConsoleKey.Enter:
                        return true;
                    case System.ConsoleKey.Escape:
                        return false;
                }
            } while (true);
        }
    }
}
