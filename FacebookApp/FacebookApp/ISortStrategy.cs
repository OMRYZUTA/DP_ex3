using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp
{
    interface ISortStrategy
    {
        List<T> SortList<T>(List<T> i_List);
    }
}
