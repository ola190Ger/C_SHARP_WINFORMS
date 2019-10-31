using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessBox_resume
{
    public partial class Form1 : Form
    {
        int countSimbol = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("Name:\n\tOlga", "Rezume", MessageBoxButtons.OK);
            countSimbol = "Name:\n\tOlga".Length;
            if (result==DialogResult.OK)
            {
                countSimbol += "Education:\n\tChernivtsi National University, Department of Physics".Length;
                result = MessageBox.Show("Education:\n\tChernivtsi National University, Department of Physics", "Rezume", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    countSimbol += "Status:\n\tHave work now".Length;
                    result = MessageBox.Show("Status:\n\tHave work now", $"Average: {countSimbol.ToString()}/3 = {countSimbol / 3} simb", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                        Application.Exit();
                }

            }

        }
    }
}
