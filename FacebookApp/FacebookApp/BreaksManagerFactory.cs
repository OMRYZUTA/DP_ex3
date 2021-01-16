namespace FacebookApp
{
    public static class BreaksManagerFactory
    {
        public static IBreaksManager CreateBreaksManager(string i_TimeUnitSelection, int i_UnitNumber)
        {
            IBreaksManager m_NewBreaksManager;

            if(i_TimeUnitSelection == "Hours")
            {
                m_NewBreaksManager = new BreaksManagerByHours();
            }
            else if(i_TimeUnitSelection == "Days")
            {
                m_NewBreaksManager = new BreaksManagerByDays();
            }
            else
            {
                m_NewBreaksManager = new BreaksManagerByMinutes();
            }

            m_NewBreaksManager.CreateBreaksManager(i_UnitNumber);

            return m_NewBreaksManager;
        }
    }
}
