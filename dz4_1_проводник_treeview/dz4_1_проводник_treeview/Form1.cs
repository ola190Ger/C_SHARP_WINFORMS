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

namespace dz4_1_проводник_treeview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillDriveNodes();//add all tom`s on this PC
        }

        private void FillDriveNodes()//get discs on pc
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode { Text = drive.Name };// create Node == disk
                    FillTreeNode(driveNode, drive.Name);//get child nodes for disk
                    treeView1.Nodes.Add(driveNode);// add node in treeview
                }
            }
            catch (Exception e) { }
        }

        private void FillTreeNode(TreeNode driveNode, string name)//name==path of disk, create and add child node
        {
            try
            {
                string[] dirs = Directory.GetDirectories(name);
                foreach (string dir in dirs)
                {
                    TreeNode dirNode = new TreeNode();
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);// delete last / if his 2
                    driveNode.Nodes.Add(dirNode);
                }
            }
            catch (Exception e)
            { }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
    
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)// event before open node
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            try
            {
                if(Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    if(dirs.Length!=0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);// create new node for each dir
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                }
            }
            catch(Exception ex) { }
        }
    }
}
