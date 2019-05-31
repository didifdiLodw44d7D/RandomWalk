using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation
{
    public partial class Form1 : Form
    {
        Timer timer;
        Bitmap canvas;
        Graphics g;
        int x;
        int y;
        int repeat;

        public Form1()
        {
            InitializeComponent();

            x = y = 0;
            repeat = 0;

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            x += 10;
            y += 10;

            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            g = Graphics.FromImage(canvas);

            draw(g, x, y, repeat++);

            g.Dispose();

            pictureBox1.Image = canvas;
        }

        private void draw(Graphics g, int x, int y, int repeat)
        {

            Pen p = new Pen(Color.Black, 1);
            int t_x = 0;
            int t_y = 0;

            for (int t = 0; t < repeat; t+=10)
            {
                Random r = new Random(t);
                int odds = r.Next(5);

                //if (0 == ( t % 20))
                if(0 == odds)
                {
                    p = new Pen(Color.Red, 3);
                    x = -5;
                }
                else if(1 == odds)
                {
                    p = new Pen(Color.Black, 3);
                    x = 5;
                }
                else if (2 == odds)
                {
                    p = new Pen(Color.OrangeRed, 3);
                    x = 10;
                }
                else if (3 == odds)
                {
                    p = new Pen(Color.Blue, 3);
                    x = -10;
                }
                else if (4 == odds)
                {
                    p = new Pen(Color.Green, 3);
                    x = 0;
                }


                g.DrawLine(p, t_x, t_y, 100 + x, 50 + t);

                t_x = 100 + x;
                t_y = 50 + t;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
