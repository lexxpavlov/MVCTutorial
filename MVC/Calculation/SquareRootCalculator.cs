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

        public IDataModel Calc()
        {
            double result = Math.Sqrt(Model.Number);
            return new DoubleModel(result);
        }
    }
}
