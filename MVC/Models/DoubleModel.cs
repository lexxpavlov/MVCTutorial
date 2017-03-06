namespace MVC.Models
{
    public class DoubleModel : IDataModel
    {
        public double Number { get; private set; }

        public DoubleModel(double number)
        {
            Number = number;
        }
    }
}
