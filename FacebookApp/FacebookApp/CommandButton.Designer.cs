namespace FacebookApp
{
    partial class CommandButton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCommand
            // 
            this.buttonCommand.Location = new System.Drawing.Point(0, 0);
            this.buttonCommand.Name = "buttonCommand";
            this.buttonCommand.Size = new System.Drawing.Size(75, 23);
            this.buttonCommand.TabIndex = 0;
            this.buttonCommand.Text = "button1";
            this.buttonCommand.UseVisualStyleBackColor = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCommand;
    }
}
