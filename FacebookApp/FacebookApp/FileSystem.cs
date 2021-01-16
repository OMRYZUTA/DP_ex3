using System;
using System.Windows.Forms;

namespace FacebookApp
{
    public partial class FileSystem : UserControl
    {
        public AlbumCreator AlbumCreator { get; set; }

        private readonly Folder r_HomeFolder;

        public FileSystem()
        {
            
            r_HomeFolder = new Folder { Text = "Albums Home" };
            InitializeComponent();
            treeViewFiles.Nodes.Add(r_HomeFolder);
        }

        private void buttonCreateAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                Folder newAlbum = AlbumCreator.GetAlbumWith(textBoxSelectedFriend.Text);
                r_HomeFolder.Nodes.Add(newAlbum);
                treeViewFiles.SelectedNode = r_HomeFolder;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeViewFiles_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                ((IFile)e.Node).Selected = e.Node.Checked;
                if (e.Node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                ((IFile)node).Selected = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
           
        }

        private void treeViewFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PhotoAdapter adapter = e.Node as PhotoAdapter;
            if (adapter != null)
            {
                pictureBoxCreateAlbum.LoadAsync(adapter.Photo.PictureNormalURL);
                if(adapter.Photo.CreatedTime != null)
                {
                    createdTimeDateTimePicker.Value = (DateTime)adapter.Photo.CreatedTime;
                }
            }
            else
            {
                pictureBoxCreateAlbum.Image = Properties.Resources.folderIcon;
            }
        }
    }
}
