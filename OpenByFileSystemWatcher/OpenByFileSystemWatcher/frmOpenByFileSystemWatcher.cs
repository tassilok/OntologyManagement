using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_ShellWork;

namespace OpenByFileSystemWatcher
{
    public partial class frmOpenByFileSystemWatcher : Form
    {
        private clsShellWork objShellWork = new clsShellWork();

        public frmOpenByFileSystemWatcher()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_GetFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_Folder.ShowDialog(this) == DialogResult.OK)
            {
                textBox_Folder.Text = folderBrowserDialog_Folder.SelectedPath;
                ConfigureWatchButton();
            }
        }

        private void button_GetApplication_Click(object sender, EventArgs e)
        {
            if (openFileDialog_Application.ShowDialog(this) == DialogResult.OK)
            {
                textBox_Application.Text = openFileDialog_Application.FileName;
                ConfigureWatchButton();
            }
        }

        private void ConfigureWatchButton()
        {
            toolStripButton_Watch.Enabled = false;

            if (Directory.Exists(textBox_Folder.Text) && File.Exists(textBox_Application.Text))
            {
                toolStripButton_Watch.Enabled = true;
            }
        }

        private void fileSystemWatcher_Main_Changed(object sender, FileSystemEventArgs e)
        {
            if (!objShellWork.start_Process(textBox_Application.Text, e.FullPath, null, false, false))
            {
                MessageBox.Show(this, "Die Datei " + e.FullPath + " konnte nicht geöffnet werden!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void fileSystemWatcher_Main_Created(object sender, FileSystemEventArgs e)
        {
            if (!objShellWork.start_Process(textBox_Application.Text, e.FullPath, null, false, false))
            {
                MessageBox.Show(this, "Die Datei " + e.FullPath + " konnte nicht geöffnet werden!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButton_Watch_CheckStateChanged(object sender, EventArgs e)
        {
            fileSystemWatcher_Main.Path = textBox_Folder.Text;
            fileSystemWatcher_Main.EnableRaisingEvents = toolStripButton_Watch.Checked;
        }

        private void notifyIcon_Watcher_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void frmOpenByFileSystemWatcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon_Watcher = null;
        }
    }
}
