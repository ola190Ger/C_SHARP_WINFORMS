using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dz3_6_проводник
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach(DriveInfo drive in driveInfo)
            {
                listBox1.Items.Add(drive.Name);
                DirectoryInfo dirInfo = new DirectoryInfo(drive.Name);
                FileSystemInfo[] files = dirInfo.GetFileSystemInfos();
                foreach (FileSystemInfo fileName in files)
                {
                    listBox1.Items.Add(fileName.FullName);
                }

            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                if(Directory.Exists(listBox1.SelectedItem.ToString()))
                {
                    DirectoryInfo drInfo = new DirectoryInfo(listBox1.SelectedIndex.ToString());
                    FileSystemInfo[] files = drInfo.GetFileSystemInfos();
                    foreach (FileSystemInfo fileName in files)
                    {
                        listBox2.Items.Add(fileName.FullName);
                    }
                }
            }
        }
    }
}
