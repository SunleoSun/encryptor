namespace Shiphrator
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fbStart = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flbFiles = new System.Windows.Forms.ListBox();
            this.frbEncrypt = new System.Windows.Forms.RadioButton();
            this.fbOutputDirectory = new System.Windows.Forms.Button();
            this.ftbOutputDirectory = new System.Windows.Forms.TextBox();
            this.fbAddFiles = new System.Windows.Forms.Button();
            this.fbClearFiles = new System.Windows.Forms.Button();
            this.ftbKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.frbDecrypt = new System.Windows.Forms.RadioButton();
            this.fpbProgress = new System.Windows.Forms.ProgressBar();
            this.flProgress = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.fcbDeleteFiles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fbStart
            // 
            this.fbStart.Location = new System.Drawing.Point(176, 392);
            this.fbStart.Name = "fbStart";
            this.fbStart.Size = new System.Drawing.Size(525, 39);
            this.fbStart.TabIndex = 0;
            this.fbStart.Text = "Старт";
            this.fbStart.UseVisualStyleBackColor = true;
            this.fbStart.Click += new System.EventHandler(this.fbStart_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // flbFiles
            // 
            this.flbFiles.FormattingEnabled = true;
            this.flbFiles.HorizontalScrollbar = true;
            this.flbFiles.ItemHeight = 16;
            this.flbFiles.Location = new System.Drawing.Point(12, 12);
            this.flbFiles.Name = "flbFiles";
            this.flbFiles.Size = new System.Drawing.Size(689, 196);
            this.flbFiles.TabIndex = 2;
            // 
            // frbEncrypt
            // 
            this.frbEncrypt.AutoSize = true;
            this.frbEncrypt.Checked = true;
            this.frbEncrypt.Location = new System.Drawing.Point(15, 383);
            this.frbEncrypt.Name = "frbEncrypt";
            this.frbEncrypt.Size = new System.Drawing.Size(121, 21);
            this.frbEncrypt.TabIndex = 3;
            this.frbEncrypt.TabStop = true;
            this.frbEncrypt.Text = "Зашифровать";
            this.frbEncrypt.UseVisualStyleBackColor = true;
            // 
            // fbOutputDirectory
            // 
            this.fbOutputDirectory.Location = new System.Drawing.Point(610, 284);
            this.fbOutputDirectory.Name = "fbOutputDirectory";
            this.fbOutputDirectory.Size = new System.Drawing.Size(94, 31);
            this.fbOutputDirectory.TabIndex = 4;
            this.fbOutputDirectory.Text = "Обзор";
            this.fbOutputDirectory.UseVisualStyleBackColor = true;
            this.fbOutputDirectory.Click += new System.EventHandler(this.fbOutputDirectory_Click);
            // 
            // ftbOutputDirectory
            // 
            this.ftbOutputDirectory.Location = new System.Drawing.Point(12, 293);
            this.ftbOutputDirectory.Name = "ftbOutputDirectory";
            this.ftbOutputDirectory.Size = new System.Drawing.Size(589, 22);
            this.ftbOutputDirectory.TabIndex = 5;
            // 
            // fbAddFiles
            // 
            this.fbAddFiles.Location = new System.Drawing.Point(15, 220);
            this.fbAddFiles.Name = "fbAddFiles";
            this.fbAddFiles.Size = new System.Drawing.Size(145, 32);
            this.fbAddFiles.TabIndex = 6;
            this.fbAddFiles.Text = "Добавить файлы";
            this.fbAddFiles.UseVisualStyleBackColor = true;
            this.fbAddFiles.Click += new System.EventHandler(this.fbAddFiles_Click);
            // 
            // fbClearFiles
            // 
            this.fbClearFiles.Location = new System.Drawing.Point(176, 220);
            this.fbClearFiles.Name = "fbClearFiles";
            this.fbClearFiles.Size = new System.Drawing.Size(208, 32);
            this.fbClearFiles.TabIndex = 7;
            this.fbClearFiles.Text = "Очистить список файлов";
            this.fbClearFiles.UseVisualStyleBackColor = true;
            this.fbClearFiles.Click += new System.EventHandler(this.fbClearFiles_Click);
            // 
            // ftbKey
            // 
            this.ftbKey.Location = new System.Drawing.Point(12, 341);
            this.ftbKey.Name = "ftbKey";
            this.ftbKey.Size = new System.Drawing.Size(689, 22);
            this.ftbKey.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ключ:";
            // 
            // frbDecrypt
            // 
            this.frbDecrypt.AutoSize = true;
            this.frbDecrypt.Location = new System.Drawing.Point(15, 410);
            this.frbDecrypt.Name = "frbDecrypt";
            this.frbDecrypt.Size = new System.Drawing.Size(128, 21);
            this.frbDecrypt.TabIndex = 10;
            this.frbDecrypt.Text = "Расшифровать";
            this.frbDecrypt.UseVisualStyleBackColor = true;
            // 
            // fpbProgress
            // 
            this.fpbProgress.Location = new System.Drawing.Point(12, 474);
            this.fpbProgress.Name = "fpbProgress";
            this.fpbProgress.Size = new System.Drawing.Size(688, 47);
            this.fpbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.fpbProgress.TabIndex = 11;
            // 
            // flProgress
            // 
            this.flProgress.AutoSize = true;
            this.flProgress.Location = new System.Drawing.Point(585, 454);
            this.flProgress.Name = "flProgress";
            this.flProgress.Size = new System.Drawing.Size(0, 17);
            this.flProgress.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Выходная папка:";
            // 
            // fcbDeleteFiles
            // 
            this.fcbDeleteFiles.AutoSize = true;
            this.fcbDeleteFiles.Location = new System.Drawing.Point(17, 442);
            this.fcbDeleteFiles.Name = "fcbDeleteFiles";
            this.fcbDeleteFiles.Size = new System.Drawing.Size(511, 21);
            this.fcbDeleteFiles.TabIndex = 14;
            this.fcbDeleteFiles.Text = "Удалять исходные файлы после завершения зашифровки/расшифровки";
            this.fcbDeleteFiles.UseVisualStyleBackColor = true;
            this.fcbDeleteFiles.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 533);
            this.Controls.Add(this.fcbDeleteFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flProgress);
            this.Controls.Add(this.fpbProgress);
            this.Controls.Add(this.frbDecrypt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ftbKey);
            this.Controls.Add(this.fbClearFiles);
            this.Controls.Add(this.fbAddFiles);
            this.Controls.Add(this.ftbOutputDirectory);
            this.Controls.Add(this.fbOutputDirectory);
            this.Controls.Add(this.frbEncrypt);
            this.Controls.Add(this.flbFiles);
            this.Controls.Add(this.fbStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Шифратор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fbStart;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox flbFiles;
        private System.Windows.Forms.RadioButton frbEncrypt;
        private System.Windows.Forms.Button fbOutputDirectory;
        private System.Windows.Forms.TextBox ftbOutputDirectory;
        private System.Windows.Forms.Button fbAddFiles;
        private System.Windows.Forms.Button fbClearFiles;
        private System.Windows.Forms.TextBox ftbKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton frbDecrypt;
        private System.Windows.Forms.ProgressBar fpbProgress;
        private System.Windows.Forms.Label flProgress;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox fcbDeleteFiles;
    }
}

