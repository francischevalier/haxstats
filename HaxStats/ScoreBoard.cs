using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HaxStats
{
    public partial class ScoreBoard : Form
    {
        private bool dragging;
        private Point dragAt = Point.Empty;

        public void Pick(Control control, int x, int y)
        {
            dragging = true;
            dragAt = new Point(x, y);
            control.Capture = true;
        }

        public void Drop(Control control)
        {
            dragging = false;
            control.Capture = false;
        }

        TimeOnAttack timeOnAttack;
        GameZone gameZone = new GameZone();

        // all infos displayed on the scoreboard
        public int TeamScore1 { get; set; }
        public int TeamScore2 { get; set; }

        String Period { get; set; }
        
        public double TeamPossession1 { get; set; } // time on attack
        public double TeamPossession2 { get; set; } // "

        public String TeamSide1 { get { return team1.Side; } }

        public struct Team
        {
            public Team(String name, Color color, String side) : this()
            {
                Name = name;
                Color = color;
                Side = side;
            }

            public String Name { get; set; }
            public Color Color { get; set; }
            public String Side { get; set; }
        }

        // Teams creation with default settings.
        Team team1 = new Team("Red", Color.FromArgb(229, 110, 86), "left");
        Team team2 = new Team("Blue", Color.FromArgb(86, 137, 229), "right");

        // time of possession labels
        public Label chronoTeam1 = new Label();
        public Label chronoTeam2 = new Label();

        // game score label
        public Label gameScore = new Label();

        Font fontScoreBoard = new Font("Arial", 12, FontStyle.Bold);

        public ScoreBoard()
        {
            Period = "Pre";

            InitializeComponent();

            // "Team One" time of possession label
            chronoTeam1.ForeColor = Color.LightGray;
            chronoTeam1.BackColor = Color.Transparent;
            chronoTeam1.Location = new Point(45, 18); // find position
            chronoTeam1.Font = fontScoreBoard;
            chronoTeam1.Text = FormatTimeFromSeconds(0);
            chronoTeam1.AutoSize = true;

            // "Team Two" time of possession label
            chronoTeam2.ForeColor = Color.LightGray;
            chronoTeam2.BackColor = Color.Transparent;
            chronoTeam2.Location = new Point(255, 18); // find position
            chronoTeam2.Font = fontScoreBoard;
            chronoTeam2.Text = FormatTimeFromSeconds(0);
            chronoTeam2.AutoSize = true;

            // Game score label
            gameScore.ForeColor = Color.White;
            gameScore.BackColor = Color.Transparent;
            gameScore.Location = new Point(155, 0); // find position
            gameScore.Font = fontScoreBoard;
            gameScore.Text = TeamScore1 + " - " + TeamScore2;
            gameScore.AutoSize = true;

            this.Controls.Add(chronoTeam1);
            this.Controls.Add(chronoTeam2);
            this.Controls.Add(gameScore);
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            // background
            // teams degraded backgrounds
            DrawTeamDegraded(e.Graphics, team1.Color,
                             (team1.Side == "left") ? 0 : (this.Size.Width / 5) * 3);
            DrawTeamDegraded(e.Graphics, team2.Color,
                             (team2.Side == "right") ? (this.Size.Width / 5) * 3 : 0);

            // black border around the scoreboard
            e.Graphics.DrawRectangle(System.Drawing.Pens.Black,
                                     new Rectangle(0, 0, this.Size.Width -1,
                                                   this.Size.Height - 1));
            
            // team names
            DrawInfoScoreBoard(e.Graphics, team1.Name, Color.Black,
                               (team1.Side == "left") ? 0.5F : 3.5F, true);
            DrawInfoScoreBoard(e.Graphics, team2.Name, Color.Black,
                               (team2.Side == "right") ? 3.5F : 0.5F, true);

            // period
            DrawInfoScoreBoard(e.Graphics, Period, Color.White, 2, false);

            e.Dispose();
        }

        private void DrawTeamDegraded(Graphics g, Color color, int start)
        {
            System.Drawing.Drawing2D.LinearGradientBrush bkgBrush1 =
                new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(0, 0, (this.Size.Width / 5) * 2, this.Size.Height),
                    color, Color.Black,
                    System.Drawing.Drawing2D.LinearGradientMode.Vertical
                );

            g.FillRectangle(bkgBrush1,
                new Rectangle(start, 0, (this.Size.Width / 5) * 2, this.Size.Height));
        }

        private void DrawInfoScoreBoard(Graphics g, String info,
                                       Color color, float fifth, bool top)
        {
            SizeF sizeOfInfo = g.MeasureString(info, fontScoreBoard);
            float height = (top) ? 0 : ((this.Size.Height / 2) - sizeOfInfo.Height) / 2
                                         + (this.Size.Height / 2);

            g.DrawString(info, fontScoreBoard, new SolidBrush(color),
            new PointF(
                (this.Size.Width / 5) * fifth + ((this.Size.Width / 5) - sizeOfInfo.Width) / 2,
                 height)
            );
        }

        public String FormatTimeFromSeconds(double seconds) {
            return TimeSpan.FromSeconds(seconds).ToString().Substring(3, 5);
        }

        public void SwitchTeamSide()
        {
            // we switch both chrono location
            Point posChrono1 = chronoTeam1.Location;

            chronoTeam1.Location = new Point(chronoTeam2.Location.X,
                                             chronoTeam1.Location.Y);

            chronoTeam2.Location = posChrono1;

            // we change team Side property
            if (team1.Side == "left")
            {
                team1.Side = "right";
                team2.Side = "left";
            }
            else
            {
                team1.Side = "left";
                team2.Side = "right";
            }

            // switch score
            gameScore.Text = (team1.Side == "left")
                             ? TeamScore1 + " - " + TeamScore2
                             : TeamScore2 + " - " + TeamScore1;

            Invalidate();
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            Pick((Control)sender, e.X, e.Y);
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            Drop((Control)sender);
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Left = e.X + Left - dragAt.X;
                Top = e.Y + Top - dragAt.Y;
            }
            else dragAt = new Point(e.X, e.Y);
        }

        private void Form3_DoubleClick(object sender, EventArgs e)
        {
            Point mousePos = new Point(MousePosition.X - Location.X,
                                       MousePosition.Y - Location.Y);

            if (mousePos.Y > (Size.Height / 2))
            {
                ColorDialog colorDialog1 = new ColorDialog();

                if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (mousePos.X < ((Size.Width / 5) * 2))
                    {
                        if (team1.Side == "left")
                            team1.Color = colorDialog1.Color;
                        else
                            team2.Color = colorDialog1.Color;
                    }
                    else if (mousePos.X > ((Size.Width / 5) * 3))
                    {
                        if (team2.Side == "right")
                            team2.Color = colorDialog1.Color;
                        else
                            team1.Color = colorDialog1.Color;
                    }
                    else
                        this.BackColor = colorDialog1.Color;

                    Invalidate();
                }
            }
            else
            {
                SimpleInputDialog inputDialog = new SimpleInputDialog();

                if (inputDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (inputDialog.TextInBox != "")
                    {
                        if (mousePos.X < ((Size.Width / 5) * 2))
                            team1.Name = inputDialog.TextInBox;
                        else if (mousePos.X > ((Size.Width / 5) * 3))
                            team2.Name = inputDialog.TextInBox;
                            
                        Invalidate();
                    }
                }
            }
        }

        private void ScoreBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(PointToScreen(e.Location));
        }

        private void switchTeamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchTeamSide();
        }

        private void reinitializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timeOnAttackToolStripMenuItem.Checked)
            {
                timeOnAttackToolStripMenuItem.Checked = false;
                timeOnAttack.Stop();
            }

            // default settings
            team1.Name = "Red";
            team1.Color = Color.FromArgb(229, 110, 86);
            team1.Side = "left";
            TeamScore1 = 0;
            TeamPossession1 = 0;
            chronoTeam1.Text = FormatTimeFromSeconds(0);

            team2.Name = "Blue";
            team2.Color = Color.FromArgb(86, 137, 229);
            team2.Side = "right";
            TeamScore2 = 0;
            TeamPossession2 = 0;
            chronoTeam2.Text = FormatTimeFromSeconds(0);

            gameScore.Text = (team1.Side == "left")
                             ? TeamScore1 + " - " + TeamScore2
                             : TeamScore2 + " - " + TeamScore1;

            // default period
            listToolStripMenuItem.SelectedIndex = 0;
            Period = "Pre";

            Invalidate();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void topmostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool topMostChecked = topmostToolStripMenuItem.Checked;

            // switch
            topmostToolStripMenuItem.Checked = !topMostChecked;
            TopMost = !topMostChecked;
        }

        private void defineGameZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameZone.ShowDialog();

            defineGameZoneToolStripMenuItem.Checked = true;
        }

        private void timeOnAttackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!timeOnAttackToolStripMenuItem.Checked)
            {
                if (timeOnAttack == null)
                    timeOnAttack = new TimeOnAttack(this);
                else
                    timeOnAttack.Start();

                timeOnAttackToolStripMenuItem.Checked = true;
            }
            else
            {
                timeOnAttack.Stop();
                timeOnAttackToolStripMenuItem.Checked = false;
            }
        }

        private void resetChronosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamPossession1 = 0;
            chronoTeam1.Text = FormatTimeFromSeconds(0);

            TeamPossession2 = 0;
            chronoTeam2.Text = FormatTimeFromSeconds(0);
        }

        private void listToolStripMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listToolStripMenuItem.Text == "Pregame")
                Period = "Pre";
            else if (listToolStripMenuItem.Text == "First half")
                Period = "1st";
            else if (listToolStripMenuItem.Text == "Second half")
                Period = "2nd";
            else
                Period = "OT";

            // to refresh the period in scoreboard
            Invalidate();

            // reduce manually the menu
            contextMenuStrip1.Hide();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamScore1 = 0;
            TeamScore2 = 0;

            gameScore.Text = (team1.Side == "left")
                             ? TeamScore1 + " - " + TeamScore2
                             : TeamScore2 + " - " + TeamScore1;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScoreChanger scoreChanger = new ScoreChanger();

             if (scoreChanger.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                if (team1.Side == "left")
                {
                    TeamScore1 = scoreChanger.ScoreLeft;
                    TeamScore2 = scoreChanger.ScoreRight;
                }
                else
                {
                    TeamScore1 = scoreChanger.ScoreRight;
                    TeamScore2 = scoreChanger.ScoreLeft;
                }

                gameScore.Text = (team1.Side == "left")
                                ? TeamScore1 + " - " + TeamScore2
                                : TeamScore2 + " - " + TeamScore1;
            }
        }
    }
}

/*
    Priorities for the beta version :
 * 
 * - Switch teams side
 * - Reset score
 * - Set score manually
 * - Show/Hide scoreboard
 * - Reset scoreboard position
 * - Stop counting when a goal is scored, and only count 1 goal
 * 
 * Bonus :
 * 
 * - Switch sides automatically after half-change detection
 * - Also update the game state (period) (Lagtest, 1st, 2nd, and then
 * verify if the score is tied, if yes then OT, otherwise auto-reset all
 * detect when the game is paused (stop counting)
*/