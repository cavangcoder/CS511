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
    public partial class main : Form
    {
        int time_dice = 0;
        int dice = 6;
        int money_start = 400;
        const int COE_VILLA = 2;
        DataTable lands_info = new DataTable();

        struct User
        {
            public int money;
            public int position; 
            public bool prison;
            public bool machine;
            public Color color;

            //public void set_info(int Money = 400, int Position = 0, bool Prison = false, bool Machine = false, Color Color_)
            public void set_info(int Money, int Position , bool Prison , bool Machine , Color Color_)
            {
                money = Money;
                position = Position;
                prison = Prison;
                machine = Machine;
                color = Color_;
            }
        }

        struct Land
        {
            public int owner;
            public int house;
            public int villa;

            public void set_info(int Owner = 4, int House = 0, int Villa = 0)
            {
                owner = Owner;
                house = House;
                villa = Villa;
            }


        }
        public main()
        {
            InitializeComponent();
            Land[] lands = new Land[22];

            lands_info.Columns.Add("id", typeof(int));
            lands_info.Columns.Add("name", typeof(string));
            lands_info.Columns.Add("price", typeof(int));
            lands_info.Columns.Add("fee", typeof(int));
            lands_info.Columns.Add("cost_house", typeof(int));
            lands_info.Columns.Add("fee_house", typeof(int));
            lands_info.Columns.Add("fee_villa", typeof(int));

            lands_info.Rows.Add(1, "NGUYỄN HUỆ", 150, 30, 75, 75, 450);
            lands_info.Rows.Add(3, "LƯƠNG ĐỊNH CỦA", 170, 34, 85, 85, 510);
            lands_info.Rows.Add(5, "HAI BÀ TRƯNG", 350, 70, 175, 175, 1050);
            lands_info.Rows.Add(7, "AN DƯƠNG VƯƠNG", 200, 40, 100, 100, 600);
            lands_info.Rows.Add(9, "HẬU GIANG", 270, 54, 135, 135, 810);
            lands_info.Rows.Add(10, "HUỲNH TẤN PHÁT", 150, 30, 75, 75, 450);
            lands_info.Rows.Add(12, "PHẠM THẾ HIỂN", 270, 54, 135, 135, 810);
            lands_info.Rows.Add(14, "TRƯỜNG CHINH", 140, 28, 70, 70, 420);
            lands_info.Rows.Add(16, "HOÀNG VĂN THỤ", 280, 56, 140, 140, 840);
            lands_info.Rows.Add(18, "CỘNG HÒA", 260, 52, 130, 130, 780);
            lands_info.Rows.Add(20, "LŨY BÁN BÍCH", 300, 60, 150, 150, 900);
            lands_info.Rows.Add(21, "TÂN KÌ TÂN QUÝ", 150, 30, 75, 75, 450);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pn_parking_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pn_top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uc_pland_up1_Load(object sender, EventArgs e)
        {

        }

        private void uc_co_hoi2_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void uc_start4_Load(object sender, EventArgs e)
        {
            
        }

        private void pb_dice_Click(object sender, EventArgs e)
        {
            time_dice = 0;
            tm_dice.Start();
        }

        private void tm_dice_Tick(object sender, EventArgs e)
        {
            time_dice += 1;

            if (time_dice > 40)
            {
                tm_dice.Stop();
                return;

            }
            
            Random rd = new Random();
            dice = rd.Next(1, 7);
            switch (dice)
            {
                case 1:
                    pb_dice.BackgroundImage = Properties.Resources.M1;
                    break;
                case 2:
                    pb_dice.BackgroundImage = Properties.Resources.M2;
                    break;
                case 3:
                    pb_dice.BackgroundImage = Properties.Resources.M3;
                    break;
                case 4:
                    pb_dice.BackgroundImage = Properties.Resources.M4;
                    break;
                case 5:
                    pb_dice.BackgroundImage = Properties.Resources.M5;
                    break;
                case 6:
                    pb_dice.BackgroundImage = Properties.Resources.M6;
                    break;
                default:
                    break;
            }
        }
    }
}
