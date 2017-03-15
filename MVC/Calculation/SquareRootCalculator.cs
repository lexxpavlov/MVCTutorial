using System;
using MVC.Models;

namespace MVC.Calculation
{
    public class SquareRootCalculator : AbstractCalculator<DoubleModel, DoubleModel>
    {
        public override DoubleModel Model { get; protected set; }

        public SquareRootCalculator(DoubleModel model)
        {
            Model = model;
        }

        public override DoubleModel Calc()
        {
            return new DoubleModel(Math.Sqrt(Model.Number));
        }
    }
}
