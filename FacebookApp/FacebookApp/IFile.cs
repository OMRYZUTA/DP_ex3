namespace FacebookApp
{
    public interface IFile
    {
        bool Selected { set; }

        void DownloadMe(string i_Path);
    }
}
