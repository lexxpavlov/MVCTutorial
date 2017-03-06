using System;
using MVC.Models;

namespace MVC.Calculation
{
    public static class Calculator
    {
        public static double Calc(IDataModel model)
        {
            if (model is SimpleModel)
            {
                return new SimpleCalculator((SimpleModel)model).Calc();
            }
            if (model is DoubleModel)
            {
                return new SquareRootCalculator((DoubleModel)model).Calc();
            }
            throw new ArgumentException("Неизвестный тип модели!");
        }
    }
}
