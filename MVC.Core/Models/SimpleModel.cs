namespace MVC.Core.Models
{
    public class SimpleModel : IDataModel
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Operation Operation { get; private set; }

        public SimpleModel(double x, double y, Operation operation)
        {
            X = x;
            Y = y;
            Operation = operation;
        }
    }
}
