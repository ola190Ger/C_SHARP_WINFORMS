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
    public partial class Form1 : Form
    {
        public List<Components> components_list = new List<Components>
        {
                new Components { name = "Mather Board", price = 1250 },
                new Components { name = "Processor", price = 4500 },
                new Components { name = "Video Card", price = 800 },
                new Components { name = "HDD", price = 300 },
                new Components { name = "SDD", price = 450 },
                new Components { name = "Ram", price = 200 }
        };
        Components SelectedComp;
        int total = 0;
        public Form1()
        {
            InitializeComponent();
          
            comboBox1.DataSource = components_list;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "price";

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedComp = (Components)comboBox1.SelectedItem;
            textBox1.Text = SelectedComp.price.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            total += SelectedComp.price;
            listBox1.Items.Add($"{SelectedComp.name} - {SelectedComp.price.ToString()}");
            label2.Text = total.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заказ оформлен..");
            listBox1.Items.Clear();
            label2.Text = "0";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
    }

    public class Components
    {
       public string name { set; get;}
       public int price { set; get;}
    }
}
