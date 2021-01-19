using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookApp
{
    public class PhotoAdapter : TreeNode, IFile
    {
        public PhotoAdapter(Photo i_Photo)
        {
            Photo = i_Photo;
            Name = i_Photo.Name;
        }

        public Photo Photo { get; }

        private const string FileName = "Photo.jpg";

        public bool Selected { get; set; }

        public void DownloadMe(string i_Path)
        {
            using (WebClient client = new WebClient())
            {
                int i = 1;
                StringBuilder fileName = new StringBuilder();

                string imageURL = Photo.PictureNormalURL;
                fileName.Append(i_Path);
                fileName.Append("\\");
                fileName.Append(DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"));
                fileName.Append(i.ToString());
                fileName.Append(Photo.Id);
                fileName.Append(FileName);
                client.DownloadFile(imageURL, fileName.ToString());
                fileName.Clear();
            }
        }
    }
}
