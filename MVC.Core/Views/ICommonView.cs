using System.Collections.Generic;

namespace MVC.Core.Views
{
    public interface ICommonView
    {
        IComputation GetComputation(List<IComputation> computations);
        bool RunAgain();
    }
}