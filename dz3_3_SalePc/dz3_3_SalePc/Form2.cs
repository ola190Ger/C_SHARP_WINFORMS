using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz3_3_SalePc
{
    public partial class Form2 : Form
    {
        //public List<Components> Catalog_Components= new List<Components>();
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f1)
        {
            InitializeComponent();
           // Catalog_Components.AddRange(f1.components_list);
            foreach (Components cp in f1.components_list)
                listBox1.Items.Add($"{cp.name}  {cp.price}");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void TextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;

        }
    }
}
