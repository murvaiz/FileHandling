using System.Windows.Forms;

namespace FileUpDownLoad
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.lst_Files = new System.Windows.Forms.ListBox();
            this.lbl_FileList = new System.Windows.Forms.Label();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_UploadFilename = new System.Windows.Forms.Label();
            this.lbl_UploadResult = new System.Windows.Forms.Label();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.btn_Dialog = new System.Windows.Forms.Button();
            this.btn_UploadFile = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.lbl_DownloadFilename = new System.Windows.Forms.Label();
            this.lbl_DownloadResult = new System.Windows.Forms.Label();
            this.btn_Download = new System.Windows.Forms.Button();
            this.txt_TargetFilename = new System.Windows.Forms.TextBox();
            this.lbl_TargetFolder = new System.Windows.Forms.Label();
            this.txt_TargetFolder = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(800, 443);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbl_Error);
            this.tabPage1.Controls.Add(this.lst_Files);
            this.tabPage1.Controls.Add(this.lbl_FileList);
            this.tabPage1.Controls.Add(this.btn_Refresh);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbl_Error
            // 
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_Error.Location = new System.Drawing.Point(383, 61);
            this.lbl_Error.MaximumSize = new System.Drawing.Size(400, 0);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(0, 15);
            this.lbl_Error.TabIndex = 3;
            // 
            // lst_Files
            // 
            this.lst_Files.FormattingEnabled = true;
            this.lst_Files.ItemHeight = 15;
            this.lst_Files.Location = new System.Drawing.Point(9, 43);
            this.lst_Files.Name = "lst_Files";
            this.lst_Files.Size = new System.Drawing.Size(346, 364);
            this.lst_Files.TabIndex = 2;
            this.toolTip1.SetToolTip(this.lst_Files, "Szerveren tárolt file-ok listája");
            // 
            // lbl_FileList
            // 
            this.lbl_FileList.AutoSize = true;
            this.lbl_FileList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_FileList.Location = new System.Drawing.Point(9, 12);
            this.lbl_FileList.Name = "lbl_FileList";
            this.lbl_FileList.Size = new System.Drawing.Size(94, 15);
            this.lbl_FileList.TabIndex = 1;
            this.lbl_FileList.Text = "Mappa tartalma";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(383, 12);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(124, 35);
            this.btn_Refresh.TabIndex = 0;
            this.btn_Refresh.Text = "Filelista frissités";
            this.toolTip1.SetToolTip(this.btn_Refresh, "Filelista frissítése");
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_UploadFilename);
            this.tabPage2.Controls.Add(this.lbl_UploadResult);
            this.tabPage2.Controls.Add(this.txt_FilePath);
            this.tabPage2.Controls.Add(this.btn_Dialog);
            this.tabPage2.Controls.Add(this.btn_UploadFile);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbl_UploadFilename
            // 
            this.lbl_UploadFilename.AutoSize = true;
            this.lbl_UploadFilename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_UploadFilename.Location = new System.Drawing.Point(5, 12);
            this.lbl_UploadFilename.Name = "lbl_UploadFilename";
            this.lbl_UploadFilename.Size = new System.Drawing.Size(92, 15);
            this.lbl_UploadFilename.TabIndex = 4;
            this.lbl_UploadFilename.Text = "Feltöltendő file";
            // 
            // lbl_UploadResult
            // 
            this.lbl_UploadResult.AutoSize = true;
            this.lbl_UploadResult.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_UploadResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_UploadResult.Location = new System.Drawing.Point(4, 118);
            this.lbl_UploadResult.Name = "lbl_UploadResult";
            this.lbl_UploadResult.Size = new System.Drawing.Size(0, 20);
            this.lbl_UploadResult.TabIndex = 3;
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FilePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_FilePath.Location = new System.Drawing.Point(5, 30);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.PlaceholderText = "Feltöltendő file";
            this.txt_FilePath.Size = new System.Drawing.Size(545, 23);
            this.txt_FilePath.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txt_FilePath, "Feltöltendő file");
            // 
            // btn_Dialog
            // 
            this.btn_Dialog.Image = ((System.Drawing.Image)(resources.GetObject("btn_Dialog.Image")));
            this.btn_Dialog.Location = new System.Drawing.Point(559, 28);
            this.btn_Dialog.Name = "btn_Dialog";
            this.btn_Dialog.Size = new System.Drawing.Size(28, 25);
            this.btn_Dialog.TabIndex = 1;
            this.btn_Dialog.Text = "\r\n";
            this.toolTip1.SetToolTip(this.btn_Dialog, "Feltöltendő file kiválasztása");
            this.btn_Dialog.UseVisualStyleBackColor = true;
            this.btn_Dialog.Click += new System.EventHandler(this.btn_Dialog_Click);
            // 
            // btn_UploadFile
            // 
            this.btn_UploadFile.Location = new System.Drawing.Point(5, 71);
            this.btn_UploadFile.Name = "btn_UploadFile";
            this.btn_UploadFile.Size = new System.Drawing.Size(117, 31);
            this.btn_UploadFile.TabIndex = 0;
            this.btn_UploadFile.Text = "File feltöltés";
            this.btn_UploadFile.UseVisualStyleBackColor = true;
            this.btn_UploadFile.Click += new System.EventHandler(this.btn_UploadFile_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_SelectFolder);
            this.tabPage3.Controls.Add(this.lbl_DownloadFilename);
            this.tabPage3.Controls.Add(this.lbl_DownloadResult);
            this.tabPage3.Controls.Add(this.btn_Download);
            this.tabPage3.Controls.Add(this.txt_TargetFilename);
            this.tabPage3.Controls.Add(this.lbl_TargetFolder);
            this.tabPage3.Controls.Add(this.txt_TargetFolder);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 415);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectFolder.Image")));
            this.btn_SelectFolder.Location = new System.Drawing.Point(434, 38);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Size = new System.Drawing.Size(27, 23);
            this.btn_SelectFolder.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btn_SelectFolder, "Célmappa kiválasztása");
            this.btn_SelectFolder.UseVisualStyleBackColor = true;
            this.btn_SelectFolder.Click += new System.EventHandler(this.btn_SelectFolder_Click);
            // 
            // lbl_DownloadFilename
            // 
            this.lbl_DownloadFilename.AutoSize = true;
            this.lbl_DownloadFilename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_DownloadFilename.Location = new System.Drawing.Point(9, 72);
            this.lbl_DownloadFilename.Name = "lbl_DownloadFilename";
            this.lbl_DownloadFilename.Size = new System.Drawing.Size(120, 15);
            this.lbl_DownloadFilename.TabIndex = 5;
            this.lbl_DownloadFilename.Text = "Letöltendő file neve";
            // 
            // lbl_DownloadResult
            // 
            this.lbl_DownloadResult.AutoSize = true;
            this.lbl_DownloadResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_DownloadResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_DownloadResult.Location = new System.Drawing.Point(9, 181);
            this.lbl_DownloadResult.Name = "lbl_DownloadResult";
            this.lbl_DownloadResult.Size = new System.Drawing.Size(0, 15);
            this.lbl_DownloadResult.TabIndex = 4;
            // 
            // btn_Download
            // 
            this.btn_Download.Location = new System.Drawing.Point(9, 141);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(120, 37);
            this.btn_Download.TabIndex = 3;
            this.btn_Download.Text = "File letöltés";
            this.btn_Download.UseVisualStyleBackColor = true;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // txt_TargetFilename
            // 
            this.txt_TargetFilename.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_TargetFilename.Location = new System.Drawing.Point(8, 90);
            this.txt_TargetFilename.Name = "txt_TargetFilename";
            this.txt_TargetFilename.PlaceholderText = "Letöltendő file neve";
            this.txt_TargetFilename.Size = new System.Drawing.Size(408, 23);
            this.txt_TargetFilename.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txt_TargetFilename, "Letöltendő file neve");
            // 
            // lbl_TargetFolder
            // 
            this.lbl_TargetFolder.AutoSize = true;
            this.lbl_TargetFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_TargetFolder.Location = new System.Drawing.Point(9, 21);
            this.lbl_TargetFolder.Name = "lbl_TargetFolder";
            this.lbl_TargetFolder.Size = new System.Drawing.Size(61, 15);
            this.lbl_TargetFolder.TabIndex = 1;
            this.lbl_TargetFolder.Text = "Célmappa";
            // 
            // txt_TargetFolder
            // 
            this.txt_TargetFolder.Location = new System.Drawing.Point(9, 39);
            this.txt_TargetFolder.Name = "txt_TargetFolder";
            this.txt_TargetFolder.PlaceholderText = "Célmappa";
            this.txt_TargetFolder.Size = new System.Drawing.Size(407, 23);
            this.txt_TargetFolder.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txt_TargetFolder, "Célmappa");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem5.Text = "File";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem7.Text = "Kilépés";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(40, 20);
            this.toolStripMenuItem6.Text = "Info";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lbl_FileList;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.ListBox lst_Files;
        private System.Windows.Forms.Label lbl_Error;
        private System.Windows.Forms.Button btn_UploadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_Dialog;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Label lbl_UploadResult;
        private System.Windows.Forms.Button btn_Download;
        private System.Windows.Forms.TextBox txt_TargetFilename;
        private System.Windows.Forms.Label lbl_TargetFolder;
        private System.Windows.Forms.TextBox txt_TargetFolder;
        private System.Windows.Forms.Label lbl_DownloadResult;
        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.Label lbl_DownloadFilename;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_UploadFilename;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
    }
}

