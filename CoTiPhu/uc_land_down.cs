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
    public partial class uc_land_down : UserControl
    {
        int count_house = 0;
        int count_villa = 0;
        Color color_choose = Color.DarkCyan;
        Color color_origin = Color.LightGoldenrodYellow;
        //bool user0 = false;
        //bool user1 = false;
        //bool user2 = false;
        //bool user3 = false;

        public uc_land_down()
        {
            InitializeComponent();
        }
        
        public void choose()
        {
            BackColor = color_choose;
        }
        public void unchoose()
        {
            BackColor = color_origin;
        }

        public void buy(int id)
        {
            switch (id)
            {
                case 0:
                    bt_name.ForeColor = bt_user0.BackColor;
                    break;
                case 1:
                    bt_name.ForeColor = bt_user1.BackColor;
                    break;
                case 2:
                    bt_name.ForeColor = bt_user2.BackColor;
                    break;
                case 3:
                    bt_name.ForeColor = bt_user3.BackColor;
                    break;
                default:
                    break;
            }
          
        }

        public void unbuy()
        {
            bt_name.ForeColor = Color.Black;
        }

        public void rename(string name)
        {
            bt_name.Text = name;
        }
        public void update_house(int count)
        {
            count_house = count;
            lb_house.Text = "x" + count_house.ToString();
            if (count_house < 1)
            {
                pn_house.Visible = false;
            }
            else
            {
                pn_house.Visible = true;
            }

        }
        public void update_villa(int count)
        {
            count_villa = count;
            lb_villa.Text = "x" + count_villa.ToString();
            if (count_villa < 1)
            {
                pn_house.Visible = false;
            }
            else
            {
                pn_house.Visible = true;
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


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
