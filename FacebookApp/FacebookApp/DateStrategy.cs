using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace FacebookApp
{
    internal class DateStrategy : AbstractListBoxSorter
    {
        protected override List<Post> SortBySpecificKey(List<Post> posts)
        {
            return posts.OrderByDescending(
                o => o.UpdateTime).ToList();
        }
    }
}
