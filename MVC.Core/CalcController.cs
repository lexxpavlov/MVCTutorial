using System.Collections.Generic;
using MVC.Core.Views;

namespace MVC.Core
{
    public class CalcController
    {
        private readonly ICommonView _commonView;
        private readonly List<IComputation> _computations;

        public CalcController(ICommonView commonView, List<IComputation> computations)
        {
            _commonView = commonView;
            _computations = computations;
        }

        public bool Run()
        {
            var computation = _commonView.GetComputation(_computations);
            var view = computation.View;
            var model = view.GetModel();
            var result = computation.GetCalculator(model).Calc();
            view.PrintResult(result);
            return _commonView.RunAgain();
        }
    }
}
