using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Information
{
    public partial class Winer : UserControl
    {
        public Winer()
        {
            InitializeComponent();
        }
        int t = -10;
        private void Winer_Load(object sender, EventArgs e)
        {
            t = -10;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += 10;
            if (t <= 170) lb_Winner.Location = new Point(66, t);
            else timer1.Stop();
        }
        int k = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            k += 1;
            if (k % 2 == 0)
            {
                panel1.BackColor = Color.Red;
                panel2.BackColor = Color.Blue;
            }
            else
            {
                panel1.BackColor = Color.Orange;
                panel2.BackColor = Color.Green;
            }
        }
    }
}
