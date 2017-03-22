using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trap
{
    public partial class Form1 : Form
    {
        Versh trap=new Trap1();
        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBoxTrap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawPolygon(new Pen(Color.Black, 2), trap.points);

        }
        private void pictureBoxClear_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
        }

        private void pictureBoxFill_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.FillPolygon(new SolidBrush(Color.Aqua), trap.points);
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            pictureBox1.Paint += pictureBoxTrap_Paint;
            Graphics g = pictureBox1.CreateGraphics();
            Rectangle rec = new Rectangle();
            PaintEventArgs es = new PaintEventArgs(g, rec);
            pictureBoxTrap_Paint(pictureBox1, es);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Paint += pictureBoxClear_Paint;
            Graphics g = pictureBox1.CreateGraphics();
            Rectangle rec = new Rectangle();
            PaintEventArgs es = new PaintEventArgs(g, rec);
            pictureBoxClear_Paint(pictureBox1, es);
        }

        private void buttonTurn_Click(object sender, EventArgs e)
        {
          trap.Turn();
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            pictureBox1.Paint += pictureBoxFill_Paint;
            Graphics g = pictureBox1.CreateGraphics();
            Rectangle rec = new Rectangle();
            PaintEventArgs es = new PaintEventArgs(g, rec);
            pictureBoxFill_Paint(pictureBox1, es);
        }
    }

   abstract class Versh
    {
        public Point[] points = new Point[4];

        public Versh()
        {
            points[0] = new Point(10, 50);
            points[1] = new Point(10, 100);
            points[2] = new Point(100, 150);
            points[3] = new Point(100, 0);
        }

        public abstract void Turn();
    }

    class Trap1:Versh
    {
        public override void Turn()
        {
            for (int i = 0; i < 4; ++i)
            {
                int x = points[i].X;
                points[i].X = points[i].Y;
                points[i].Y = x;
            }
        }
    }
}
