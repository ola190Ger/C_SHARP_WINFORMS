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
        
        List<string> formats= new List<string> { ".jpg", ".jpeg", ".tiff", ".tif", ".gif", ".bmp", ".png", ".bat" };
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList1;
            FillDriveNodes();//add all tom`s on this PC

        }

        private void FillDriveNodes()//get discs on pc
        {
            listView1.Items.Clear();
           // ClearImage();
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode { Text = drive.Name };// create Node == disk
                    ListViewItem viewItem = new ListViewItem { Text = drive.Name };
                    FillTreeNode(driveNode, drive.Name);//get child nodes for disk
                    treeView1.Nodes.Add(driveNode);// add node in treeview
                    viewItem.ImageIndex = 0;// picture for disk
                    listView1.Items.Add(viewItem);
                }
            }
            catch (Exception e) { }
        }

        private void FillTreeNode(TreeNode driveNode, string name)//name==path of disk, create and add child node
        {
            
            try
            {
                string[] dirs = Directory.GetDirectories(name);
               // string[] files = Directory.GetFiles(name);
                
                foreach (string dir in dirs)
                {
                    
                    TreeNode dirNode = new TreeNode();
                    //ListViewItem viewItem = new ListViewItem() ;
                    //AddFileInListView(dir, viewItem);
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);// delete last / if his 2
                    driveNode.Nodes.Add(dirNode);
                    //listView1.Items.Add(viewItem);
                }
                
            }
            catch (Exception e)
            { }
        }

        private void AddFileInListView(string dirName,ListViewItem list)
        {
            string[] files = Directory.GetFiles(dirName);
            foreach(string file in files)
            {
                
                string ext = Path.GetExtension(file);
                if (formats.Contains(ext))
                {
                    try
                    {
                        Image img = Image.FromFile(file);
                        imageList1.Images.Add(img);
                        list.ImageIndex = imageList1.Images.Count - 1;
                        list.Text = Path.GetFileNameWithoutExtension(file);
                    }
                    catch
                    {
                        list.ImageIndex = 2;
                        list.Text = Path.GetFileNameWithoutExtension(file);

                    }
                }
                else
                {
                    list.ImageIndex = 2;
                    list.Text = Path.GetFileNameWithoutExtension(file);

                }
            }
        }
        
        private void ClearImage()
        {
            while (imageList1.Images.Count > 3) imageList1.Images.RemoveAt(imageList1.Images.Count - 1);
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            listView1.Items.Clear();
            //ClearImage();
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
                            string Namedir = new DirectoryInfo(dirs[i]).Name;
                            TreeNode dirNode = new TreeNode(Namedir);
                            ListViewItem viewItem = new ListViewItem { Text = Namedir };
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                            viewItem.ImageIndex = 1;
                            listView1.Items.Add(viewItem);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
    
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)// event before open node
        {
            e.Node.Nodes.Clear();
            listView1.Items.Clear();
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
                            string Namedir = new DirectoryInfo(dirs[i]).Name;
                            TreeNode dirNode = new TreeNode(Namedir);// create new node for each dir
                            ListViewItem viewItem = new ListViewItem { Text = Namedir };
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                            viewItem.ImageIndex = 1;
                            listView1.Items.Add(viewItem);
                        }
                    }
                }
            }
            catch(Exception ex) { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.ActiveControl = menuStrip1;
        }
    }
}
