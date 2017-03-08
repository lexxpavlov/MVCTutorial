using System.Linq;
using MVC.Models;

namespace MVC.Calculation
{
    public class ListStatisticCalculator : ICalculator
    {
        public ListModel Model { get; private set; }

        public ListStatisticCalculator(ListModel model)
        {
            Model = model;
        }

        public IDataModel Calc()
        {
            double min = Model.List.Min();
            double max = Model.List.Max();
            double average = Model.List.Average();
            return new ListStatisticModel(min, max, average);
        }
    }
}
