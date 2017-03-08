using System;
using MVC.Models;

namespace MVC.Calculation
{
    public static class Calculator
    {
        public static IDataModel Calc(IDataModel model)
        {
            if (model is SimpleModel)
            {
                return new SimpleCalculator((SimpleModel)model).Calc();
            }
            if (model is DoubleModel)
            {
                return new SquareRootCalculator((DoubleModel)model).Calc();
            }
            if (model is ListModel)
            {
                return new ListStatisticCalculator((ListModel)model).Calc();
            }
            throw new ArgumentException("Неизвестный тип модели!");
        }
    }
}
