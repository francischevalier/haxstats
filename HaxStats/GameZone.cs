using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace HaxStats
{
    public partial class GameZone : Form
    {
        public Point LocGameZone { get; set; }
        public Size SizeGameZone { get; set; }

        bool isSet = false;

        public GameZone()
        {
            LocGameZone = new Point(0, 0);
            SizeGameZone = new Size(Screen.PrimaryScreen.Bounds.Width,
                                    Screen.PrimaryScreen.Bounds.Height);

            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocGameZone = new Point(Location.X, Location.Y);
            SizeGameZone = new Size(Size.Width, Size.Height);

            isSet = true;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            if (isSet)
            {
                Location = LocGameZone;
                Size = SizeGameZone;
            }
        }
    }
}