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
    public partial class uc_pland_right : UserControl
    {
        int count_house = 0;
        int count_villa = 0;
        public uc_pland_right()
        {
            InitializeComponent();
        }

        public void rename(string name)
        {
            bt_name.Text = name;
        }
        public void update_house(int count)
        {
            count_house += count;
            if (count_house < 1)
            {
                pn_house.Visible = false;
            }

        }
        public void update_villa(int count)
        {
            count_villa += count;
            if (count_villa < 1)
            {
                pn_house.Visible = false;
            }

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
    }
}
