using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HaxStats
{
    public partial class SimpleInputDialog : Form
    {
        public String TextInBox { get; set; }

        public SimpleInputDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextInBox = textBox1.Text;
        }
    }
}