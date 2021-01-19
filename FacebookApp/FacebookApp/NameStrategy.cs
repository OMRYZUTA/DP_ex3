using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace FacebookApp
{
    internal class NameStrategy : AbstractListBoxSorter
    {
        protected override List<Post> SortBySpecificKey(List<Post> posts)
        {
            return posts.OrderBy(
                o => o.Message).ToList();
        }
    }
}
