using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Ccao_big_homework_core;

namespace FuckTest
{
    public partial class Form1 : Form , IWindow
    {
        private CompositeGraphic cg = new CompositeGraphic();


        public Form1()
        {
            InitializeComponent();
            cg.BackColor = new SolidBrush(Color.White);
            cg.Width = 500;
            cg.Height = 400;
            cg.Draw(this, 40, 40);
        }

        public void DrawPath(Pen pen, GraphicsPath path)
        {
            Graphics g = this.CreateGraphics();
            g.DrawPath(pen, path);
            g.Dispose();
        }
        public void FillPath(Brush brush, GraphicsPath path)
        {
            Graphics g = this.CreateGraphics();
            g.FillPath(brush, path);
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cg.Draw(this, 40, 40);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //妈蛋，还是VB最好用，就问你服不服
            int h = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("number required"));
            int w = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("number required"));
            int l = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("number required"));
            int t = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("number required"));

            cg.Add(new MyEllipse(h, w), l, t);
        }
    }
}
