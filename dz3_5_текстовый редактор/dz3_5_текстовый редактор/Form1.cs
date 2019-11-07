﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dz3_5_текстовый_редактор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            OpenTxt();
        }

        private void OpenTxt()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                textBox1.Lines = File.ReadAllLines(ofd.FileName);
            }
        }
    }
}
