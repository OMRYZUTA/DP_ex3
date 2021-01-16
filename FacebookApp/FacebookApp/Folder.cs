using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FacebookApp
{
    public class Folder : TreeNode, IFile, IEnumerable<IFile>
    {
        private List<IFile> Files { get; }

        private bool m_IsSelected;

        public Folder()
        {
            Files = new List<IFile>();
            m_IsSelected = false;
        }

        public bool Selected
        {
            get
            {
                return m_IsSelected;
            }

            set
            {
                m_IsSelected = true;
                if (value)
                {
                    if (Files.Count > 0)
                    {
                        foreach (IFile file in Files)
                        {
                            file.Selected = true;
                        }
                    }
                }
            }
        }

        public void DownloadMe(string i_Path)
        {
            string path = i_Path;

            // need to create here new folder
            if (Checked)
            {
                path = i_Path + string.Format("\\{0}", Text);
                Directory.CreateDirectory(path);
            }

            foreach (TreeNode file in Nodes)
            {
                if (file.Checked || file is Folder)
                {
                    (file as IFile)?.DownloadMe(path);
                }
            }
        }

        public void AddChild(IFile i_File)
        {
            Files.Add(i_File);
        }

        public IEnumerator<IFile> GetEnumerator()
        {
            return Files.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Files.GetEnumerator();
        }
    }
}
