using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookApp
{
    public class DownloadCommand : ICommand
    {
        private Folder m_Folder;

        public DownloadCommand(Folder i_Folder)
        {
            m_Folder = i_Folder;
        }

        public void Execute()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Custom Description" };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = fbd.SelectedPath;
                m_Folder.DownloadMe(selectedPath);
                MessageBox.Show("Download completed");
            }
        }
    }
}
