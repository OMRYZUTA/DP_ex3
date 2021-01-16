using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookApp
{
    public class AlbumCreator
    {
        private readonly List<User> r_FriendsWithAlbums;

        public User LoggedInUser { get; set; }

        public AlbumCreator()
        {
            r_FriendsWithAlbums = new List<User>();
        }

        public Folder GetAlbumWith(string i_FriendName)
        {
            Folder newAlbum;
            User friend = getFriendFromUser(i_FriendName);
            if (friend != null)
            {
                if (isFriendInCollection(i_FriendName, r_FriendsWithAlbums))
                {
                    throw new Exception("Friend's Album is already exists. please try another friend name");
                }

                newAlbum = generateNewAlbum(friend);
            }
            else
            {
                throw new Exception("Friend doesn't exist. please type correctly the friend name");
            }

            return newAlbum;
        }

        private User getFriendFromUser(string i_FriendName)
        {
            User userFriend = null;

            foreach (User friend in LoggedInUser.Friends)
            {
                if (friend.Name == i_FriendName)
                {
                    userFriend = friend;
                    break;
                }
            }

            return userFriend;
        }

        private Folder generateNewAlbum(User i_Friend)
        {
            Folder newAlbum = new Folder();

            // since it doesn't work we implement it manually
            try
            {
                foreach (Photo photo in LoggedInUser.PhotosTaggedIn)
                {
                    if (photo.Tags != null)
                    {
                        newAlbum = new Folder { Name = string.Format("{0}'s Album", i_Friend.Name) };
                        foreach (PhotoTag tag in photo.Tags)
                        {
                            if (tag.User.Name == i_Friend.Name)
                            {
                                newAlbum.AddChild(new PhotoAdapter(photo));
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Tags property returned null");
                    }
                }
            }
            catch (Exception ex)
            {
                newAlbum = new Folder { Text = string.Format("{0}'s Album", i_Friend.Name) };
                for (int i = 0; i < 10; i++)
                {
                    PhotoAdapter photo = new PhotoAdapter(LoggedInUser.PhotosTaggedIn[i]);
                    photo.Text = string.IsNullOrEmpty(photo.Name) ? photo.Photo.From.Name : photo.Photo.Name;
                    newAlbum.Nodes.Add(photo);
                }

                r_FriendsWithAlbums.Add(i_Friend);
            }

            return newAlbum;
        }

        private bool isFriendInCollection(string i_FriendName, IEnumerable<User> i_Collection)
        {
            bool result = false;

            foreach (User friend in i_Collection)
            {
                if (friend.Name == i_FriendName)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}