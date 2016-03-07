using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppTest.Commons.Utilities
{
    public static class Extentions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> original)
        {
            return new ObservableCollection<T>(original);
        }
    }
}
