using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookApp
{
    public partial class FormMainFacebookApp : Form
    {
        private readonly TabsLoader r_TabsLoader;
        private readonly AlbumCreator r_AlbumCreator;
        private User m_LoggedInUser;
        private LoginResult m_LoginResult;
        private IBreaksManager m_BreakManager;
        private ISortStrategy m_SortStrategy;

        public FormMainFacebookApp()
        {
            r_TabsLoader = new TabsLoader();
            r_AlbumCreator = new AlbumCreator();
            InitializeComponent();
            FacebookService.s_CollectionLimit = 400;
            m_BreakManager = new BreaksManagerByMinutes();
            m_BreakManager.CreateBreaksManager(15);  // 15 default
        }

        private void loginAndInit()
        {
            if (m_LoginResult == null)
            {
                /// Owner: design.patterns
                ///EAAUm6cZC4eUEBALVbi9bZAb5VFs1ebDkmva0uhzXkgRRlMY8YVVBEjoJRw5e6fdxnbrHezOCBpqybBCglBWxpyaFlqSu98nqSpp3yXhgcDl6YoRH6zSKMIZA3em1D6LidH0mCgXzCjZBXW5HuZBTLVvUDNqDtd6HElosgjevktks5e09iRU0X
                /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
                /// You can then save the result.AccessToken for future auto-connect to this user:
                m_LoginResult = FacebookService.Login(
                    "361826995145957",
                    /// (desig patter's "Design Patterns Course App 2.4" app)

                    "public_profile",
                    "email",
                    "user_birthday",
                    "user_age_range",
                    "user_gender",
                    "user_link",
                    "user_tagged_places",
                    "user_videos",
                    "user_friends",
                    "user_events",
                    "user_likes",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_hometown");
                if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
                {
                    m_LoggedInUser = m_LoginResult.LoggedInUser;
                    r_TabsLoader.LoggedInUser = m_LoggedInUser;
                    breakManagerTimer.Start();
                    fileSystem.AlbumCreator = r_AlbumCreator;
                    fetchUserBasicInfo();
                }
                else
                {
                    MessageBox.Show(m_LoginResult.ErrorMessage);
                }
            }
        }

        private void fetchUserBasicInfo()
        {
            new Thread(fetchUserProfilePhoto).Start();
            new Thread(fetchUserCoverPhoto).Start();
            new Thread(fetchUserName).Start();
        }

        // since Cover property is broken we are using PhotosTaggedIn
        private void fetchUserCoverPhoto()
        {
            if (m_LoggedInUser.PhotosTaggedIn?[1] != null)
            {
                coverPhoto.Invoke(new Action(() => coverPhoto.LoadAsync(m_LoggedInUser.PhotosTaggedIn[1].PictureNormalURL)));
            }
        }

        private void fetchUserName()
        {
            StringBuilder userName = new StringBuilder();
            userName.Append(m_LoggedInUser.FirstName);
            userName.Append(" ");
            userName.Append(m_LoggedInUser.LastName);
            userNamePresentation.Invoke(new Action(() => userNamePresentation.Text = userName.ToString()));
        }

        private void fetchUserProfilePhoto()
        {
            profilePicture.Invoke(new Action(() => profilePicture.LoadAsync(m_LoggedInUser.PictureNormalURL)));
        }

        private void buttonLogin_Click(object i_Sender, EventArgs i_EventArgs)
        {
            Thread t = new Thread(loginAndInit);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private Dictionary<string, object> buildDictionaryForAboutTab()
        {
            Dictionary<string, object> objectsToInit = new Dictionary<string, object>
                                                       {
                                                           { birthDayBox.Name, birthDayBox },
                                                           { genderBox.Name, genderBox },
                                                           { livesInBox.Name, livesInBox },
                                                           { workPlacesList.Name, workPlacesList },
                                                           { educationList.Name, educationList },
                                                           { numberOfFriendsBox.Name, numberOfFriendsBox },
                                                           { numberOfPostsBox.Name, numberOfPostsBox },
                                                           { numberOfAlbumsBox.Name, numberOfAlbumsBox }
                                                       };
            return objectsToInit;
        }

        private void tabControlMain_Selected(object i_Sender, TabControlEventArgs i_EventArgs)
        {
            if (m_LoggedInUser != null)
            {
                Tab tab = new Tab();
                tab.ConvertStringToEnum(i_EventArgs.TabPage.Name);
                if (!r_TabsLoader.IsTabLoaded(tab))
                {
                    switch (tab.TabType)
                    {
                        case eTab.Posts:
                            loadPostsTab();
                            break;
                        case eTab.AboutUser:
                            loadAboutUserTab();
                            break;
                        case eTab.FriendsList:
                            loadFriendsListTab();
                            break;
                        case eTab.UserPhotos:
                            loadUserPhotosTab();
                            break;
                        case eTab.CreateAlbum:
                            loadCreateAlbumTab();
                            break;
                    }
                }
            }
        }

        private void loadCreateAlbumTab()
        {
            Tab tab = new Tab();
            tab.ConvertStringToEnum(createAlbumFeature.Name);
            r_TabsLoader.LoadTab(tab, r_AlbumCreator);
        }

        private void loadUserPhotosTab()
        {
            photoBindingSource.DataSource = m_LoggedInUser.PhotosTaggedIn;
        }

        private void loadFriendsListTab()
        {
            Tab tab = new Tab();
            tab.ConvertStringToEnum(tabFriendsList.Name);
            r_TabsLoader.LoadTab(tab, friendsListBox);
        }

        private void loadPostsTab()
        {
            Tab tab = new Tab();
            tab.ConvertStringToEnum(tabUserPosts.Name);
            try
            {
                r_TabsLoader.LoadTab(tab, userPostsList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadAboutUserTab()
        {
            Tab tab = new Tab();
            tab.ConvertStringToEnum(tabAboutUser.Name);
            Dictionary<string, object> objectsToInit = buildDictionaryForAboutTab();
            r_TabsLoader.LoadTab(tab, objectsToInit);
        }

        private void saveBreakManagerSettingsButton_Click(object sender, EventArgs e)
        {
            if (noBreaksCheckBox.Checked)
            {
                disableBreaksPrompts();
            }
            else
            {
                int inputNumberFromUser = (int)this.inputNumberFromUser.Value;
                string selectedTimeUnit = minutesOrHours.SelectedItem.ToString();

                m_BreakManager = BreaksManagerFactory.CreateBreaksManager(selectedTimeUnit, inputNumberFromUser);
                startNewBreakCount();
            }
        }

        private void startNewBreakCount()
        {
            m_BreakManager.InitMinutes();
            breakManagerTimer.Start();
        }

        private void disableBreaksPrompts()
        {
            breakManagerTimer.Stop();
            m_BreakManager.InitMinutes();
            m_BreakManager.InitSeconds();
            showTimer();
        }

        private void breakManagerTimer_Tick(object sender, EventArgs e)
        {
            m_BreakManager.m_Seconds += 1;
            if (m_BreakManager.m_Seconds % 60 == 0)
            {
                addMinuteToTimer();
            }

            showTimer();
            if (m_BreakManager.m_Minutes == m_BreakManager.m_BreakTime)
            {
                popUpTakeABreakMessage();
            }
        }

        private void popUpTakeABreakMessage()
        {
            breakManagerTimer.Stop();
            m_BreakManager.InitMinutes();
            MessageBox.Show(@"Take a break!");
            breakManagerTimer.Start();
        }

        private void addMinuteToTimer()
        {
            m_BreakManager.m_Seconds = 0;
            m_BreakManager.m_Minutes += 1;
        }

        private void showTimer()
        {
            string minutes;
            string seconds;

            if (m_BreakManager.m_Minutes < 10)
            {
                minutes = 0 + m_BreakManager.m_Minutes.ToString();
            }
            else
            {
                minutes = m_BreakManager.m_Minutes.ToString();
            }

            if (m_BreakManager.m_Seconds < 10)
            {
                seconds = 0 + m_BreakManager.m_Seconds.ToString();
            }
            else
            {
                seconds = m_BreakManager.m_Seconds.ToString();
            }

            timerPresentation.Text = minutes + @":" + seconds;
        }

        private void minutesOrHours_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedItem = minutesOrHours.SelectedItem.ToString();
            if (selectedItem == "Hours")
            {
                inputNumberFromUser.Maximum = 72;
            }
            else if (selectedItem == "Minutes")
            {
                inputNumberFromUser.Maximum = 150;
            }
            else
            {
                inputNumberFromUser.Maximum = 3;
            }
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBoxSort.SelectedItem.ToString();
            if (selectedItem == "Alphabetical")
            {
               m_SortStrategy = new NameStrategy();
            }
            else if (selectedItem == "Date")
            {
                m_SortStrategy = new DateStrategy();
            }
        }

        private void buttonSortPosts_Click(object sender, EventArgs e)
        {
            m_SortStrategy.SortPostsList(userPostsList);
        }
    }
}
