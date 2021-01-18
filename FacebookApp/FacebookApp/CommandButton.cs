using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookApp
{
    class CommandButton : Button
    {
        public ICommand m_Command { get; set; }

        public CommandButton()
        {
            Click += CommandButton_Click;
        }

        private void CommandButton_Click(object sender, EventArgs e)
        {
            if(m_Command != null)
            {
                Selected();
            }
        }

        public void Selected()
        {
            m_Command.Execute();
        }
    }

}
