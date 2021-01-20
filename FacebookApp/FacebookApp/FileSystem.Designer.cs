namespace FacebookApp
{
    partial class FileSystem
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label createdTimeLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeViewFiles = new System.Windows.Forms.TreeView();
            this.createdTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelCreateAlbumHeader = new System.Windows.Forms.Label();
            this.textBoxSelectedFriend = new System.Windows.Forms.TextBox();
            this.labelSelectedFriend = new System.Windows.Forms.Label();
            this.pictureBoxCreateAlbum = new System.Windows.Forms.PictureBox();
            this.commandButtonCreateAlbumPicture = new FacebookApp.CommandButton();
            this.commandButtonDownloadAll = new FacebookApp.CommandButton();
            this.commandButtonCreateAlbum = new FacebookApp.CommandButton();
            this.folderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            createdTimeLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCreateAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // createdTimeLabel
            // 
            createdTimeLabel.AutoSize = true;
            createdTimeLabel.Location = new System.Drawing.Point(317, 354);
            createdTimeLabel.Name = "createdTimeLabel";
            createdTimeLabel.Size = new System.Drawing.Size(97, 17);
            createdTimeLabel.TabIndex = 5;
            createdTimeLabel.Text = "Created Time:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeViewFiles);
            this.panel1.Location = new System.Drawing.Point(21, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 263);
            this.panel1.TabIndex = 1;
            // 
            // treeViewFiles
            // 
            this.treeViewFiles.CheckBoxes = true;
            this.treeViewFiles.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.folderBindingSource, "Name", true));
            this.treeViewFiles.DataBindings.Add(new System.Windows.Forms.Binding("CheckBoxes", this.folderBindingSource, "Selected", true));
            this.treeViewFiles.Location = new System.Drawing.Point(3, 3);
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.Size = new System.Drawing.Size(284, 260);
            this.treeViewFiles.TabIndex = 3;
            this.treeViewFiles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFiles_AfterCheck);
            this.treeViewFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFiles_AfterSelect);
            // 
            // createdTimeDateTimePicker
            // 
            this.createdTimeDateTimePicker.Location = new System.Drawing.Point(432, 354);
            this.createdTimeDateTimePicker.Name = "createdTimeDateTimePicker";
            this.createdTimeDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.createdTimeDateTimePicker.TabIndex = 6;
            // 
            // labelCreateAlbumHeader
            // 
            this.labelCreateAlbumHeader.AutoSize = true;
            this.labelCreateAlbumHeader.Location = new System.Drawing.Point(255, 12);
            this.labelCreateAlbumHeader.Name = "labelCreateAlbumHeader";
            this.labelCreateAlbumHeader.Size = new System.Drawing.Size(195, 17);
            this.labelCreateAlbumHeader.TabIndex = 10;
            this.labelCreateAlbumHeader.Text = "Create an album with a friend!";
            // 
            // textBoxSelectedFriend
            // 
            this.textBoxSelectedFriend.Location = new System.Drawing.Point(216, 48);
            this.textBoxSelectedFriend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSelectedFriend.Name = "textBoxSelectedFriend";
            this.textBoxSelectedFriend.Size = new System.Drawing.Size(100, 22);
            this.textBoxSelectedFriend.TabIndex = 8;
            this.textBoxSelectedFriend.TextChanged += new System.EventHandler(this.textBoxSelectedFriend_TextChanged);
            // 
            // labelSelectedFriend
            // 
            this.labelSelectedFriend.AutoSize = true;
            this.labelSelectedFriend.Location = new System.Drawing.Point(87, 48);
            this.labelSelectedFriend.Name = "labelSelectedFriend";
            this.labelSelectedFriend.Size = new System.Drawing.Size(109, 17);
            this.labelSelectedFriend.TabIndex = 7;
            this.labelSelectedFriend.Text = "selected Friend:";
            // 
            // pictureBoxCreateAlbum
            // 
            this.pictureBoxCreateAlbum.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxCreateAlbum.Image = global::FacebookApp.Properties.Resources.folderIcon;
            this.pictureBoxCreateAlbum.Location = new System.Drawing.Point(348, 120);
            this.pictureBoxCreateAlbum.Name = "pictureBoxCreateAlbum";
            this.pictureBoxCreateAlbum.Size = new System.Drawing.Size(246, 168);
            this.pictureBoxCreateAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCreateAlbum.TabIndex = 3;
            this.pictureBoxCreateAlbum.TabStop = false;
            // 
            // commandButtonCreateAlbumPicture
            // 
            this.commandButtonCreateAlbumPicture.Image = global::FacebookApp.Properties.Resources.addFolder;
            this.commandButtonCreateAlbumPicture.Location = new System.Drawing.Point(90, 80);
            this.commandButtonCreateAlbumPicture.m_Command = null;
            this.commandButtonCreateAlbumPicture.Name = "commandButtonCreateAlbumPicture";
            this.commandButtonCreateAlbumPicture.Size = new System.Drawing.Size(49, 43);
            this.commandButtonCreateAlbumPicture.TabIndex = 13;
            this.commandButtonCreateAlbumPicture.UseVisualStyleBackColor = true;
            // 
            // commandButtonDownloadAll
            // 
            this.commandButtonDownloadAll.Location = new System.Drawing.Point(348, 310);
            this.commandButtonDownloadAll.m_Command = null;
            this.commandButtonDownloadAll.Name = "commandButtonDownloadAll";
            this.commandButtonDownloadAll.Size = new System.Drawing.Size(132, 23);
            this.commandButtonDownloadAll.TabIndex = 12;
            this.commandButtonDownloadAll.Text = "Download All";
            this.commandButtonDownloadAll.UseVisualStyleBackColor = true;
            // 
            // commandButtonCreateAlbum
            // 
            this.commandButtonCreateAlbum.Location = new System.Drawing.Point(348, 48);
            this.commandButtonCreateAlbum.m_Command = null;
            this.commandButtonCreateAlbum.Name = "commandButtonCreateAlbum";
            this.commandButtonCreateAlbum.Size = new System.Drawing.Size(139, 23);
            this.commandButtonCreateAlbum.TabIndex = 11;
            this.commandButtonCreateAlbum.Text = "Create Album";
            this.commandButtonCreateAlbum.UseVisualStyleBackColor = true;
            // 
            // folderBindingSource
            // 
            this.folderBindingSource.DataSource = typeof(FacebookApp.Folder);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(FacebookApp.PhotoAdapter);
            // 
            // FileSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commandButtonCreateAlbumPicture);
            this.Controls.Add(this.commandButtonDownloadAll);
            this.Controls.Add(this.commandButtonCreateAlbum);
            this.Controls.Add(this.labelCreateAlbumHeader);
            this.Controls.Add(this.textBoxSelectedFriend);
            this.Controls.Add(this.labelSelectedFriend);
            this.Controls.Add(createdTimeLabel);
            this.Controls.Add(this.createdTimeDateTimePicker);
            this.Controls.Add(this.pictureBoxCreateAlbum);
            this.Controls.Add(this.panel1);
            this.Name = "FileSystem";
            this.Size = new System.Drawing.Size(706, 408);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCreateAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxCreateAlbum;
        private System.Windows.Forms.DateTimePicker createdTimeDateTimePicker;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource folderBindingSource;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Label labelCreateAlbumHeader;
        private System.Windows.Forms.Button buttonCreateAlbum;
        private System.Windows.Forms.TextBox textBoxSelectedFriend;
        private System.Windows.Forms.Label labelSelectedFriend;
        private System.Windows.Forms.TreeView treeViewFiles;
        private CommandButton commandButtonCreateAlbum;
        private CommandButton commandButtonDownloadAll;
        private CommandButton commandButtonCreateAlbumPicture;
    }
}
