using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookApp
{
    class NameStrategy:ISortStrategy
    {
        public void SortList<T>(T i_List)
        {
            List<Post> posts = new List<Post>();
            foreach(var post in (i_List as ListBox).Items)
            {
                posts.Add(post as Post);   
            }

            posts.OrderBy(post => post.UpdateTime);
            (i_List as ListBox).Items.Clear();
            foreach(Post post in posts)
            {
                (i_List as ListBox).Items.Add(post);
            }
        }
    }
}
