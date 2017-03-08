using System.Collections.Generic;

namespace MVC.Models
{
    public class ListStatisticModel: IDataModel
    {
        public double Min { get; private set; }
        public double Max { get; private set; }
        public double Average { get; private set; }

        public ListStatisticModel(double min, double max, double average)
        {
            Min = min;
            Max = max;
            Average = average;
        }
    }
}
