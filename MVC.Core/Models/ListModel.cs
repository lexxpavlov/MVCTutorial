using System.Collections.Generic;

namespace MVC.Core.Models
{
    public class ListModel : IDataModel
    {
        public List<double> List { get; private set; }

        public ListModel(List<double> list)
        {
            List = list;
        }
    }
}
