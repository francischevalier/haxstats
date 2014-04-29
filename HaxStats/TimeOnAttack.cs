using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Timers;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;

namespace HaxStats
{
    class TimeOnAttack
    {
        System.Timers.Timer aTimer;

        GameZone gameZone = new GameZone();
        ScoreBoard scoreBoard;

        // Game state enumeration
        public enum GameState { Lagtest, Regulation, Overtime, Pause, GoalScored };

        // Game State
        public GameState gameState;

        Bitmap GameZonePic { get; set; }
        BlobCounter BlobCounter { get; set; }
        Blob[] Blobs { get; set; }

        public TimeOnAttack(ScoreBoard sb)
        {
            gameState = GameState.Regulation; // Initial game state

            scoreBoard = sb;
            Start();
        }

        private void GetGameZonePic()
        {
            GameZonePic = new Bitmap(gameZone.SizeGameZone.Width,
                                     gameZone.SizeGameZone.Height,
                                     PixelFormat.Format32bppArgb);

            Graphics gfxScreenshot = Graphics.FromImage(GameZonePic);
            gfxScreenshot.CopyFromScreen(gameZone.LocGameZone.X,
                                         gameZone.LocGameZone.Y,
                                         0,
                                         0,
                                         gameZone.SizeGameZone,
                                         CopyPixelOperation.SourceCopy);
        }

        private void GetPicBlobs()
        {
            // create filter
            ColorFiltering filter = new ColorFiltering();
            // set color ranges to keep
            filter.Red = new IntRange(190, 255);
            filter.Green = new IntRange(200, 255);
            filter.Blue = new IntRange(180, 255);
            // apply the filter
            filter.ApplyInPlace(GameZonePic);

            // locate objects using blob counter
            BlobCounter = new BlobCounter();
            BlobCounter.ProcessImage(GameZonePic);
            Blobs = BlobCounter.GetObjectsInformation();
        }

        private String GetBallTerritory()
        {
            float posLeftPoles = 0;
            float posRightPoles = 0;
            float posBall = 0;
            String zone = "Undefined";

            // check each object and find the ball and poles if visible
            for (int i = 0, n = Blobs.Length; i < n; i++)
            {
                List<IntPoint> edgePoints = BlobCounter.GetBlobsEdgePoints(Blobs[i]);

                AForge.Point center;
                float radius;

                SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

                if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                {
                    if (radius > 5 && radius < 10)
                    {
                        Color circleColor = GameZonePic.GetPixel((int)center.X, (int)center.Y);

                        if (circleColor.GetBrightness() > 0.85F)
                        {
                            if (circleColor.GetBrightness() < 0.95F)
                            {
                                if (circleColor.GetHue() < 100)
                                    posLeftPoles = center.X; // Left poles
                                else
                                    posRightPoles = center.X; // Right poles
                            }
                            else
                                posBall = center.X; // Ball
                        }
                    }
                }
            }

            // check in which territory is the ball and if there's a goal.
            if ((posLeftPoles != 0 || posRightPoles != 0) && posBall != 0)
            {
                if (posLeftPoles != 0)
                {
                    zone = "Left";

                    if (posBall < posLeftPoles && gameState != GameState.GoalScored)
                    {
                        // Right team scores
                        if (scoreBoard.TeamSide1 == "left")
                            scoreBoard.TeamScore2 += 1;
                        else
                            scoreBoard.TeamScore1 += 1;

                        updateLabelText(scoreBoard.gameScore,
                                (scoreBoard.TeamSide1 == "left")
                                ? scoreBoard.TeamScore1 + " - " + scoreBoard.TeamScore2
                                : scoreBoard.TeamScore2 + " - " + scoreBoard.TeamScore1);

                        gameState = GameState.GoalScored;
                    }
                }
                else
                {
                    zone = "Right";

                    if (posBall > posRightPoles && gameState != GameState.GoalScored)
                    {
                        // Left team scores
                        if (scoreBoard.TeamSide1 == "left")
                            scoreBoard.TeamScore1 += 1;
                        else
                            scoreBoard.TeamScore2 += 1;

                        updateLabelText(scoreBoard.gameScore,
                                (scoreBoard.TeamSide1 == "left")
                                ? scoreBoard.TeamScore1 + " - " + scoreBoard.TeamScore2
                                : scoreBoard.TeamScore2 + " - " + scoreBoard.TeamScore1);

                        gameState = GameState.GoalScored;
                    }
                }
            }
            else if (gameState == GameState.GoalScored && posBall != 0)
                gameState = GameState.Regulation;

            return zone;
        }

        delegate void updateLabelTextDelegate(Label label, string newText);
        private void updateLabelText(Label label, string newText)
        {
            if (label.InvokeRequired)
            {
                // this is worker thread
                updateLabelTextDelegate del = new updateLabelTextDelegate(updateLabelText);
                label.Invoke(del, new object[] { label, newText });
            }
            else
            {
                // this is UI thread
                label.Text = newText;
            }
        }

        // function to test
        private void AddTimeOnAttack(String territory)
        {
            if (territory != "Undefined" && gameState != GameState.GoalScored)
            {
                if (territory == "Right")
                {
                    if (scoreBoard.TeamSide1 == "left")
                    {
                        scoreBoard.TeamPossession1 += 0.5;
                        updateLabelText(scoreBoard.chronoTeam1, scoreBoard.FormatTimeFromSeconds(
                            scoreBoard.TeamPossession1));
                    }
                    else
                    {
                        scoreBoard.TeamPossession2 += 0.5;
                        updateLabelText(scoreBoard.chronoTeam2, scoreBoard.FormatTimeFromSeconds(
                            scoreBoard.TeamPossession2));
                    }
                }
                else if (territory == "Left")
                {
                    if (scoreBoard.TeamSide1 == "right")
                    {
                        scoreBoard.TeamPossession1 += 0.5;
                        updateLabelText(scoreBoard.chronoTeam1, scoreBoard.FormatTimeFromSeconds(
                            scoreBoard.TeamPossession1));
                    }
                    else
                    {
                        scoreBoard.TeamPossession2 += 0.5;
                        updateLabelText(scoreBoard.chronoTeam2, scoreBoard.FormatTimeFromSeconds(
                            scoreBoard.TeamPossession2));
                    }
                }
            }
        }

        // function to test
        private void Testing(object source, ElapsedEventArgs e)
        {
            GetGameZonePic();
            GetPicBlobs();
            AddTimeOnAttack(GetBallTerritory());
        }

        public void Start()
        {
            /*Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();*/

            if (aTimer == null)
            {
                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(Testing);
                aTimer.Interval = 500;
                aTimer.Enabled = true;
            }
            else
                aTimer.Start();

            /*stopwatch.Stop();
            Debug.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);*/
        }

        public void Stop()
        {
            if (aTimer != null)
                aTimer.Stop();
        }
    }
}
