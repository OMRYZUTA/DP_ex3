using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookApp
{
    internal abstract class AbstractListBoxSorter : ISortStrategy
    {
        private void sortPostsListBox(ListBox i_List)
        {
            List<Post> m_Posts = new List<Post>();
            foreach (Post post in i_List.Items)
            {
                m_Posts.Add(post);
            }

            List<Post> sortedPosts = SortBySpecificKey(m_Posts);
            i_List.Items.Clear();
            foreach (var item in sortedPosts)
            {
                i_List.Items.Add(item);
            }
        }

        public void SortPostsList<T>(T i_List)
        {
            sortPostsListBox(i_List as ListBox);
        }

        protected abstract List<Post> SortBySpecificKey(List<Post> i_Posts);
    }
}
