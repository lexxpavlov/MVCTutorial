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

        public double Calc()
        {
            switch (Model.Operation)
            {
                case Operation.Add:
                    return Model.X + Model.Y;
                case Operation.Sub:
                    return Model.X - Model.Y;
                case Operation.Mul:
                    return Model.X * Model.Y;
                case Operation.Div:
                    return Model.X / Model.Y;
            }
            throw new ArgumentException(string.Format("Неизвестная операция: {0}", Model.Operation));
        }
    }
}
