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
    public partial class ScoreChanger : Form
    {
        public int ScoreLeft { get; set; }
        public int ScoreRight { get; set; }

        public ScoreChanger()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ScoreLeft = int.Parse(textBox1.Text);
                ScoreRight = int.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Invalid score");
            }
        }
    }
}