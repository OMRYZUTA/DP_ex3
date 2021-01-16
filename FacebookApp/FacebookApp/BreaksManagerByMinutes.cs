namespace FacebookApp
{
    public class BreaksManagerByMinutes : IBreaksManager
    {
        public int m_BreakTime { get; set; }

        public int m_Seconds { get; set; }

        public int m_Minutes { get; set; }

        public void CreateBreaksManager(int i_BreakTimeInMinutes)
        {
            InitBreakTime(i_BreakTimeInMinutes);
            InitMinutes();
            InitSeconds();
        }

        public void InitBreakTime(int i_BreakTimeInMinutes)
        {
            m_BreakTime = i_BreakTimeInMinutes;
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
