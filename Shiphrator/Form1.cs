using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Shiphrator
{
    public partial class Form1 : Form
    {
        Engine engine;
        delegate void EncryptDel();
        int countFilesProgress = 0;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Multiselect = true;
            engine = new Engine();
            engine.DeleteFilesAfterConvert = false;
            engine.FileEncrypted += new FileEncryptedDelegate(engine_FileEncrypted);
            engine.FilesEncryptedFinished += new FilesEncryptedFinishedDelegate(engine_FilesEncryptedFinished);
        }
        void FilesEncryptedFinished()
        {
            fpbProgress.Value = fpbProgress.Maximum;
            flProgress.Text = "Готово!";
            EnableAll(true);
        }
        void engine_FilesEncryptedFinished(object sender)
        {
            this.BeginInvoke(new Action(FilesEncryptedFinished));
        }
        void FileEncrypted()
        {
            fpbProgress.Value++;
            countFilesProgress++;
            flProgress.Text = countFilesProgress.ToString() + " / " + flbFiles.Items.Count.ToString();
        }
        void engine_FileEncrypted(object sender)
        {
            this.BeginInvoke(new Action(FileEncrypted));
        }
        void EnableAll(bool Enable)
        {
            ftbKey.Enabled = Enable;
            ftbOutputDirectory.Enabled = Enable;
            fbAddFiles.Enabled = Enable;
            fbStart.Enabled = Enable;
            fbClearFiles.Enabled = Enable;
            fcbDeleteFiles.Enabled = Enable;
            frbDecrypt.Enabled = Enable;
            frbEncrypt.Enabled = Enable;
            fbOutputDirectory.Enabled = Enable;
        }
        private void fbStart_Click(object sender, EventArgs e)
        {
            if (ftbKey.Text==string.Empty)
            {
                MessageBox.Show("Введите ключ!");
                return;
            }
            if (flbFiles.Items.Count==0)
            {
                MessageBox.Show("Выберите файлы!");
                return;
            }
            if (!Directory.Exists(ftbOutputDirectory.Text))
            {
                Directory.CreateDirectory(ftbOutputDirectory.Text);
            }
            EnableAll(false);
            countFilesProgress = 0;
            fpbProgress.Value = 0; fpbProgress.Minimum = 0; fpbProgress.Maximum = flbFiles.Items.Count;
            flProgress.Text = countFilesProgress.ToString()+" / " + flbFiles.Items.Count.ToString();
            engine.ChangeOptions(
                openFileDialog1.FileNames,
                openFileDialog1.SafeFileNames,
                folderBrowserDialog1.SelectedPath,
                ftbKey.Text);
            if (frbEncrypt.Checked)
            {
                EncryptDel ed = new EncryptDel(engine.Encrypt);
                ed.BeginInvoke(null,null);
            }
            if (frbDecrypt.Checked)
            {
                EncryptDel ed = new EncryptDel(engine.Decrypt);
                ed.BeginInvoke(null, null);
            }
        }

        private void fbAddFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            flbFiles.Items.AddRange(openFileDialog1.FileNames);
            
        }

        private void fbClearFiles_Click(object sender, EventArgs e)
        {
            flbFiles.Items.Clear();
        }

        private void fbOutputDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            ftbOutputDirectory.Text = folderBrowserDialog1.SelectedPath;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (fcbDeleteFiles.Checked)
                engine.DeleteFilesAfterConvert = true;
            else
                engine.DeleteFilesAfterConvert = false;
        }


    }
}
