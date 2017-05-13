using System.Linq;
using MVC.Core.Models;

namespace MVC.Core.Calculation
{
    public class ListStatisticCalculator : AbstractCalculator<ListModel, ListStatisticModel>
    {
        public override ListModel Model { get; protected set; }

        public ListStatisticCalculator(ListModel model)
        {
            Model = model;
        }

        public override ListStatisticModel Calc()
        {
            double min = Model.List.Min();
            double max = Model.List.Max();
            double average = Model.List.Average();
            return new ListStatisticModel(min, max, average);
        }
    }
}
