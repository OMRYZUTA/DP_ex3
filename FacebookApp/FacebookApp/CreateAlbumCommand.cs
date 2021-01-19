using System;
using System.Windows.Forms;

namespace FacebookApp
{
    public class CreateAlbumCommand : ICommand
    {
        private readonly Folder m_Folder;
        private readonly AlbumCreator m_AlbumCreator;
        private readonly TextBox m_TextBoxSelectedFriend;

        public CreateAlbumCommand(Folder i_Folder, AlbumCreator i_AlbumCreator, TextBox i_TextBoxSelectedFriend)
        {
            m_Folder = i_Folder;
            m_AlbumCreator = i_AlbumCreator;
            m_TextBoxSelectedFriend = i_TextBoxSelectedFriend;
        }

        public void Execute()
        {
            try
            {
                Folder newAlbum = m_AlbumCreator.GetAlbumWith(m_TextBoxSelectedFriend.Text);
                m_Folder.Nodes.Add(newAlbum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
