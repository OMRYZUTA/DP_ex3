using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookApp
{
    class CreateAlbumCommand : ICommand
    {
        private Folder m_Folder;
        private AlbumCreator m_albumCreator;
        private TextBox m_TextBoxSelectedFriend;

        public CreateAlbumCommand(Folder i_Folder, AlbumCreator i_AlbumCreator, TextBox i_TextBoxSelectedFriend)
        {
            m_Folder = i_Folder;
            m_albumCreator = i_AlbumCreator;
            m_TextBoxSelectedFriend = i_TextBoxSelectedFriend;
        }

        public void Execute()
        {
            try
            {
                Folder newAlbum = m_albumCreator.GetAlbumWith(m_TextBoxSelectedFriend.Text);
                m_Folder.Nodes.Add(newAlbum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
