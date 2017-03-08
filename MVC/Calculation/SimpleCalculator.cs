using System;
using MVC.Models;

namespace MVC.Calculation
{
    public class SimpleCalculator : ICalculator
    {
        public SimpleModel Model { get; private set; }

        public SimpleCalculator(SimpleModel model)
        {
            Model = model;
        }

        public IDataModel Calc()
        {
            double result = 0;
            switch (Model.Operation)
            {
                case Operation.Add:
                    result = Model.X + Model.Y;
                    break;
                case Operation.Sub:
                    result = Model.X - Model.Y;
                    break;
                case Operation.Mul:
                    result = Model.X * Model.Y;
                    break;
                case Operation.Div:
                    result = Model.X / Model.Y;
                    break;
                default:
                    throw new ArgumentException(string.Format("Неизвестная операция: {0}", Model.Operation));
            }
            return new DoubleModel(result);
        }
    }
}
