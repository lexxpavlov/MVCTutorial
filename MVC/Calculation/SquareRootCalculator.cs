using System;
using MVC.Models;

namespace MVC.Calculation
{
    public class SquareRootCalculator : ICalculator
    {
        public DoubleModel Model { get; private set; }

        public SquareRootCalculator(DoubleModel model)
        {
            Model = model;
        }

        public double Calc()
        {
            return Math.Sqrt(Model.Number);
        }
    }
}
