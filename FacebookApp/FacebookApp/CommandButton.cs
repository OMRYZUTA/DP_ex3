using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookApp
{
    public partial class CommandButton : Button
    {
        public ICommand m_Command { get; set; }

        public CommandButton(ICommand command)
        {
            m_Command = command;
            InitializeComponent();
            Click += CommandButton_Click;
        }

        private void CommandButton_Click(object sender, EventArgs e)
        {
            Selected();
        }

        public CommandButton(IContainer container, ICommand command)
        {
            m_Command = command;
            container.Add(this);

            InitializeComponent();
        }

        public void Selected()
        {
            m_Command.Execute();
        }
    }
}
