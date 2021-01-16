namespace FacebookApp
{
    public class Tab
    {
        public eTab TabType { get; private set; }

        private const string k_Posts = "tabUserPosts";
        private const string k_AboutUser = "tabAboutUser";
        private const string k_FriendsList = "tabFriendsList";
        private const string k_UserPhotos = "tabUserPhotos";
        private const string k_CreateAlbum = "createAlbumFeature";

        public Tab()
        {
            TabType = eTab.None;
        }

        public void ConvertStringToEnum(string i_TabName)
        {
            switch (i_TabName)
            {
                case k_Posts:
                    TabType = eTab.Posts;
                    break;
                case k_AboutUser:
                    TabType = eTab.AboutUser;
                    break;
                case k_FriendsList:
                    TabType = eTab.FriendsList;
                    break;
                case k_UserPhotos:
                    TabType = eTab.UserPhotos;
                    break;
                case k_CreateAlbum:
                    TabType = eTab.CreateAlbum;
                    break;
            }
        }
    }
}
