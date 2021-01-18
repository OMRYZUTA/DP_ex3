using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp
{
    interface ISortStrategy
    {
        void SortPostsList<T>(T i_List);
    }
}
