using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectangleIn
{
    public partial class Form1 : Form
    {
        RectangleF rect;
        Point point_click = Point.Empty;
        bool CTRL=false;
        public Form1()
        {
            InitializeComponent();
            rect = new RectangleF(10, 10, ClientSize.Width-10, ClientSize.Height-10);
        }

        private void MouseClickk(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                point_click.X = e.X;
                point_click.Y = e.Y;

                if(rect.Contains(point_click))
                {
                    //Text ="("+ point_click.X+";"+point_click.Y+")"+" in rectangle";
                    label1.Text = point_click.ToString() + " IN rectangle";
                }
                else
                {
                    label1.Text = point_click.ToString() + " OUTSIDE rectangle";

                }
            }
            if (e.Button == MouseButtons.Left && CTRL)
                Application.Exit();
            if(e.Button==MouseButtons.Right)
            {
                Text = rect.Size.ToString();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                CTRL = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
                CTRL = false;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "("+e.X.ToString() + " : "+e.Y.ToString()+")";
        }
    }
}
