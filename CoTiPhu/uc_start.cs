using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTiPhu
{
    public partial class uc_start : UserControl
    {
        public uc_start()
        {
            InitializeComponent();
        }
        Color color_choose = Color.DarkCyan;
        Color color_origin = Color.White;
        int time_sleep = 500;
        public void choose()
        {
            BackColor = color_choose;
        }
        public void unchoose()
        {
            BackColor = color_origin;
        }
        public void set_color_user(Color color0, Color color1, Color color2, Color color3)
        {
            bt_user0.BackColor = color0;
            bt_user1.BackColor = color1;
            bt_user2.BackColor = color2;
            bt_user3.BackColor = color3;
        }
        public void update_user(int id)
        {
            switch (id)
            {
                case 0:
                    bt_user0.Visible ^= true;
                    break;
                case 1:
                    bt_user1.Visible ^= true;
                    break;
                case 2:
                    bt_user2.Visible ^= true;
                    break;
                case 3:
                    bt_user3.Visible ^= true;
                    break;
                default:
                    break;
            }
        }

        private void bt_user2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
