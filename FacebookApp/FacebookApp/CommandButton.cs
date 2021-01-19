using System;
using System.Windows.Forms;

namespace FacebookApp
{
    public class CommandButton : Button
    {
        public ICommand m_Command { get; set; }

        public CommandButton()
        {
            Click += CommandButton_Click;
        }

        private void CommandButton_Click(object sender, EventArgs e)
        {
            if (m_Command != null)
            {
                selected();
            }
        }

        private void selected()
        {
            m_Command.Execute();
        }
    }
}
