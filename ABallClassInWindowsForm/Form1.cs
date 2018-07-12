using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABallClassInWindowsForm
{
    public partial class Form1 : Form
    {
        private readonly Pingpong theBall = new Pingpong();
        private readonly BlockPanel blockPanel;
        readonly Collider _collider = new Collider();

        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None; // remove any border

            Bounds = Screen.PrimaryScreen.Bounds; //make it fullscreen


            blockPanel = new BlockPanel
            {
                BackgroundColor = new SolidBrush(Color.Black),
                Width = ClientSize.Width / 5,
                Height = ClientSize.Height / 40,
                HorizontalCoordinate = ClientSize.Width / 2 - Width / 2,
                VerticalCoordiante = ClientSize.Height - ClientSize.Height / 40
            };
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PrintTheBall(e);
            PrintThePanel(e);
        }

        private void PrintTheBall(PaintEventArgs e)
        {
            Rectangle circle = new Rectangle(theBall.HorizontalCoordinate, theBall.VerticalCoordinate, theBall.Width, theBall.Height);
            e.Graphics.FillEllipse(theBall.BackgroundColor, circle);
        }

        private void PrintThePanel(PaintEventArgs e)
        {
            Rectangle blockPanelShape = new Rectangle(blockPanel.HorizontalCoordinate, blockPanel.VerticalCoordiante, blockPanel.Width, blockPanel.Height);
            e.Graphics.FillRectangle(blockPanel.BackgroundColor, blockPanelShape);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BallMove();

            blockPanel.HorizontalCoordinate = Cursor.Position.X - blockPanel.Width / 2;

            if (_collider.IsCollided(theBall, blockPanel))
            {
                int verticalCoordinateUpdated = theBall.VerticalCoordinate + theBall.VerticalSpeed;
                int bounceAmount = verticalCoordinateUpdated + theBall.Height - blockPanel.VerticalCoordiante;
                theBall.VerticalCoordinate = blockPanel.VerticalCoordiante - bounceAmount - theBall.Height;
                theBall.VerticalSpeed = -theBall.VerticalSpeed;
            }
            

            Invalidate();
        }

        private void BallMove()
        {
            int horizontalCoordinateUpdated = theBall.HorizontalCoordinate + theBall.HorizontalSpeed;
            int verticalCoordinateUpdated = theBall.VerticalCoordinate + theBall.VerticalSpeed;

            bool isWallHit = false;
            bool isGameOver = false;

            if (horizontalCoordinateUpdated + theBall.Width > ClientSize.Width)
            {
                int bounceAmount = horizontalCoordinateUpdated + theBall.Width - ClientSize.Width;
                theBall.HorizontalCoordinate = ClientSize.Width - bounceAmount - theBall.Width;
                theBall.HorizontalSpeed = -theBall.HorizontalSpeed;
                isWallHit = true;
            }
            else if (horizontalCoordinateUpdated <= 0)
            {
                int bounceAmount = -horizontalCoordinateUpdated;
                theBall.HorizontalCoordinate = bounceAmount;
                theBall.HorizontalSpeed = -theBall.HorizontalSpeed;
                isWallHit = true;
            }
            else
            {
                theBall.HorizontalCoordinate = horizontalCoordinateUpdated;
            }


            if (verticalCoordinateUpdated + theBall.Height > ClientSize.Height)
            {
                //                int bounceAmount = verticalCoordinateUpdated + theBall.Height - ClientSize.Height;
                //                theBall.VerticalCoordinate = ClientSize.Height - bounceAmount - theBall.Height;
                //                theBall.VerticalSpeed = -theBall.VerticalSpeed;
                //     isWallHit = true;
                timer1.Enabled = false;
                MessageBox.Show(@"GGWP");
                MessageBox.Show("Trash");
            }
            else if (verticalCoordinateUpdated <= 0)
            {
                int bounceAmount = -verticalCoordinateUpdated;
                theBall.VerticalCoordinate = bounceAmount;
                theBall.VerticalSpeed = -theBall.VerticalSpeed;
                isWallHit = true;
            }
            else
            {
                theBall.VerticalCoordinate = verticalCoordinateUpdated;
            }

            if (isWallHit)
            {
                Random random = new Random();
                theBall.BackgroundColor = new SolidBrush(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }
    }
}
