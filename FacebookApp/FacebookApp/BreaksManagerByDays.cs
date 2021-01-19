namespace FacebookApp
{
    public class BreaksManagerByDays : IBreaksManager
    {
        public int m_BreakTime { get; private set; }

        public int m_Seconds { get; set; }

        public int m_Minutes { get; set; }

        public void CreateBreaksManager(int i_BreakTimeInMinutes)
        {
            initBreakTime(i_BreakTimeInMinutes);
            InitMinutes();
            InitSeconds();
        }

        private void initBreakTime(int i_BreakTimeInMinutes)
        {
            m_BreakTime = i_BreakTimeInMinutes * 60 * 24;
        }

        public void InitMinutes()
        {
            m_Minutes = 0;
        }

        public void InitSeconds()
        {
            m_Seconds = 0;
        }
    }
}
