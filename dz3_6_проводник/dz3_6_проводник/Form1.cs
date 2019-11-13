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
                DirectoryInfo[] dir = dirInfo.GetDirectories();
                foreach (DirectoryInfo fileName in dir)
                {
                    listBox1.Items.Add(fileName.FullName);
                }
            }
            toolStripStatusLabel1.Text = "This PC";

        }


        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if(listBox1.SelectedIndex!=-1)
            {
                if(Directory.Exists(listBox1.SelectedItem.ToString()))
                {
                    DirectoryInfo[] drInfo = new DirectoryInfo(listBox1.SelectedItem.ToString()).GetDirectories();
                    foreach (DirectoryInfo fileName in drInfo)
                    {
                        listBox2.Items.Add(fileName.FullName);
                    }
                }
            }
            */
            ListBox_Changed(listBox1.SelectedIndex, listBox1.SelectedItem.ToString());

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (listBox2.SelectedIndex != -1)
            {
                if (Directory.Exists(listBox2.SelectedItem.ToString()))
                {
                    DirectoryInfo[] drInfo = new DirectoryInfo(listBox2.SelectedItem.ToString()).GetDirectories();
                    // FileSystemInfo[] files = (DirectoryInfo)listBox1.SelectedIndex;
                    if(drInfo.Count()>0)
                    {
                        listBox1.Items.Clear();
                        foreach (DirectoryInfo fileName in drInfo)
                            listBox1.Items.Add(fileName.FullName);
                        FileInfo[] fileInfo = new DirectoryInfo(listBox2.SelectedItem.ToString()).GetFiles();
                        listBox2.Items.Clear();
                        foreach (FileInfo file in fileInfo)
                            listBox2.Items.Add(file.Name);

                    }
                    else
                    {
                        FileInfo[] fileInfo = new DirectoryInfo(listBox2.SelectedItem.ToString()).GetFiles();
                        if(fileInfo.Count()>0)
                        {
                            listBox2.Items.Clear();
                            foreach (FileInfo file in fileInfo)
                                listBox2.Items.Add(file.Name);
                            
                        }
                    }
                }
                
            }
            */

            ListBox_Changed(listBox2.SelectedIndex, listBox2.SelectedItem.ToString());
        }

        private void ListBox_Changed(int listBoxSelectedIndex, string listBoxSelectedItem)
        {
            toolStripStatusLabel1.Text = listBoxSelectedItem;
            if (listBoxSelectedIndex != -1)
            {
                if (Directory.Exists(listBoxSelectedItem))
                {
                    DirectoryInfo[] drInfo = new DirectoryInfo(listBoxSelectedItem).GetDirectories();
                    // FileSystemInfo[] files = (DirectoryInfo)listBox1.SelectedIndex;
                    if (drInfo.Count() > 0)
                    {
                        listBox1.Items.Clear();
                        foreach (DirectoryInfo fileName in drInfo)
                            listBox1.Items.Add(fileName.FullName);
                        FileInfo[] fileInfo = new DirectoryInfo(listBoxSelectedItem).GetFiles();
                        listBox2.Items.Clear();
                        foreach (FileInfo file in fileInfo)
                            listBox2.Items.Add(file.Name);

                    }
                    else
                    {
                        FileInfo[] fileInfo = new DirectoryInfo(listBoxSelectedItem).GetFiles();
                        if (fileInfo.Count() > 0)
                        {
                            listBox2.Items.Clear();
                            foreach (FileInfo file in fileInfo)
                                listBox2.Items.Add(file.Name);

                        }
                    }
                }

            }

        }

    }
}
