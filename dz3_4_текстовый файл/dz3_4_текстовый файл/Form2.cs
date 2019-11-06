using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz3_4_текстовый_файл
{
    public partial class Form2 : Form
    {
        ReturnText Return;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string[] str,ReturnText rt)
        {
            InitializeComponent();
            textBox1.Lines = str;
            //foreach(string txt in str)
                //textBox1.Lines.Append(txt);
            this.Return = rt;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Return(textBox1.Lines);
            DialogResult res= MessageBox.Show("Продолжить редактирование?", "Что делаем...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
