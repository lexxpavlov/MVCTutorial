using System;
using MVC.Core.Models;

namespace MVC.Core.Calculation
{
    public class SimpleCalculator : AbstractCalculator<SimpleModel, DoubleModel>
    {
        public override SimpleModel Model { get; protected set; }

        public SimpleCalculator(SimpleModel model)
        {
            Model = model;
        }

        public override DoubleModel Calc()
        {
            double result;
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
