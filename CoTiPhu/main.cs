using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace CoTiPhu
{
    public partial class main : Form
    {
        int time_dice = 0;
        int dice = 6;
        public int money_start = 400;
        bool lock_dice = false;
        int current_user = 0;
        const int COE_VILLA = 2;
        int step;
        SoundPlayer sound_dice  = new SoundPlayer(@"C:\\ThanhLuan\\C#\\CoTiPhu\\CS511\\CoTiPhu\\Resources\\sound_dice.wav");
        SoundPlayer sound_buy   = new SoundPlayer(@"C:\\ThanhLuan\\C#\\CoTiPhu\\CS511\\CoTiPhu\\Resources\\buy.wav");
        SoundPlayer sound_money = new SoundPlayer(@"C:\\ThanhLuan\\C#\\CoTiPhu\\CS511\\CoTiPhu\\Resources\\money.wav");
        SoundPlayer sound_move  = new SoundPlayer(@"C:\\ThanhLuan\\C#\\CoTiPhu\\CS511\\CoTiPhu\\Resources\\move.wav");


        DataTable lands_info = new DataTable();

        struct User
        {
            public int money;
            public int money_start;
            public int position; 
            public bool prison;
            public bool machine;
            public Color color;

            //public void set_info(int Money = 400, int Position = 0, bool Prison = false, bool Machine = false, Color Color_)
            public void set_info(int Money, int Position , bool Prison , bool Machine , Color Color_)
            {
                money_start = money = Money;
                position = Position;
                prison = Prison;
                machine = Machine;
                color = Color_;
            }
            public void move()
            {
                position = (position + 1) % 22;
                if (position == 0)
                {
                    money += money_start;
                }
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
        Land[] lands = new Land[22];
        User[] users = new User[4];

        public main()
        {
            InitializeComponent();
           
            database();
            rename();
            set_users();
            set_colors_uc();
            start();
            
        }
        private void start()
        {
            uc_0.update_user(0);
            uc_0.update_user(1);
            uc_0.update_user(2);
            uc_0.update_user(3);
        }
        public void set_colors_uc()
        {
            uc_0.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_1.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_2.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_3.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_4.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_5.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_6.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_7.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_8.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_9.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_10.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_11.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_12.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_13.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_14.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_15.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_16.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_18.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_19.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_20.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);
            uc_21.set_color_user(users[0].color, users[1].color, users[2].color, users[3].color);

        }
        public void set_users()
        {
            users[0].set_info(money_start, 0, false, false, Color.Red);
            users[1].set_info(money_start, 0, false, false, Color.Green);
            users[2].set_info(money_start, 0, false, false, Color.Blue);
            users[3].set_info(money_start, 0, false, false, Color.Yellow);
        }
        public void rename()
        {
            uc_1.rename("NGUYỄN HUỆ");
            uc_3.rename("LƯƠNG ĐỊNH CỦA");
            uc_5.rename("HAI BÀ TRƯNG");
            uc_7.rename("AN\nDƯƠNG VƯƠNG");
            uc_9.rename("HẬU GIANG");
            uc_10.rename("HUỲNH\nTẤN PHÁT");
            uc_12.rename("PHẠM THẾ HIỂN");
            uc_14.rename("TRƯỜNG CHINH");
            uc_16.rename("HOÀNG VĂN THỤ");
            uc_18.rename("CỘNG HÒA");
            uc_20.rename("LŨY BÁN BÍCH");
            uc_21.rename("TÂN KÌ TÂN QUÝ");
        }
        public void database()
        {
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
        private void choose_land( int id_land)
        {
            switch (id_land)
            {
                case 0:
                    uc_0.choose();
                    break;
                case 1:
                    uc_1.choose();
                    break ; 
                case 2: 
                    uc_2.choose();
                    break;
                case 3:
                    uc_3.choose();
                    break;
                case 4:
                    uc_4.choose();
                    break;
                case 5:
                    uc_5.choose();
                    break;
                case 6:
                    uc_6.choose();
                    break;
                case 7:
                    uc_7.choose();
                    break;
                case 8:
                    uc_8.choose();
                    break;
                case 9:
                    uc_9.choose();
                    break;
                case 10:
                    uc_10.choose();
                    break;
                case 11:
                    uc_11.choose();
                    break;
                case 12:
                    uc_12.choose();
                    break;
                case 13:
                    uc_13.choose();
                    break;
                case 14:
                    uc_14.choose();
                    break;
                case 15:
                    uc_15.choose();
                    break;
                case 16:
                    uc_16.choose();
                    break;
                case 17:
                    uc_17.choose();
                    break;
                case 18:
                    uc_18.choose();
                    break;
                case 19:
                    uc_19.choose();
                    break;
                case 20:
                    uc_20.choose();
                    break;
                case 21:
                    uc_21.choose();
                    break;
                default:
                    break;
            }

        }
        private void unchoose_land(int id_land)
        {
            switch (id_land)
            {
                case 0:
                    uc_0.unchoose();
                    break;
                case 1:
                    uc_1.unchoose();
                    break;
                case 2:
                    uc_2.unchoose();
                    break;
                case 3:
                    uc_3.unchoose();
                    break;
                case 4:
                    uc_4.unchoose();
                    break;
                case 5:
                    uc_5.unchoose();
                    break;
                case 6:
                    uc_6.unchoose();
                    break;
                case 7:
                    uc_7.unchoose();
                    break;
                case 8:
                    uc_8.unchoose();
                    break;
                case 9:
                    uc_9.unchoose();
                    break;
                case 10:
                    uc_10.unchoose();
                    break;
                case 11:
                    uc_11.unchoose();
                    break;
                case 12:
                    uc_12.unchoose();
                    break;
                case 13:
                    uc_13.unchoose();
                    break;
                case 14:
                    uc_14.unchoose();
                    break;
                case 15:
                    uc_15.unchoose();
                    break;
                case 16:
                    uc_16.unchoose();
                    break;
                case 17:
                    uc_17.unchoose();
                    break;
                case 18:
                    uc_18.unchoose();
                    break;
                case 19:
                    uc_19.unchoose();
                    break;
                case 20:
                    uc_20.unchoose();
                    break;
                case 21:
                    uc_21.unchoose();
                    break;
                default:
                    break;
            }

        }
        //void move_a2b(int a, int b)
        //{
        //    for (int i = a; i<=b; ++i)
        //    {
        //        choose_land(i);
        //    }
        //}

        private void pb_dice_Click(object sender, EventArgs e)
        {
            if (lock_dice) return;
            time_dice = 0;
            lock_dice = true;
            tm_dice.Start();
            //sound_dice = new SoundPlayer(@"C:\\ThanhLuan\\C#\\CoTiPhu\\CS511\\CoTiPhu\\Resources\\dice.wav");
            //sound_dice.Load();
            sound_dice.Play();
        }

        private void tm_dice_Tick(object sender, EventArgs e)
        {
            time_dice += 1;

            if (time_dice > 20)
            {
                tm_dice.Stop();
                sound_dice.Stop();
                step = dice;
                //now_state  = users[current_user].position;
                //next_state = (now_state + dice) % 22;
                //users[current_user].position = next_state;
                tm_choose.Start();
               
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
        private void update_money()
        {
            lb_money0.Text = users[0].money.ToString();
            lb_money1.Text = users[1].money.ToString();
            lb_money2.Text = users[2].money.ToString();
            lb_money3.Text = users[3].money.ToString();
        }

        private void pn_main_game_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uc_0_Load(object sender, EventArgs e)
        {

        }

        private void uc_start2_Load(object sender, EventArgs e)
        {

        }

        private void uc_start1_Load(object sender, EventArgs e)
        {

        }

        private void tb_info_TextChanged(object sender, EventArgs e)
        {

        }

        private void uc_10_Load(object sender, EventArgs e)
        {

        }

        private void uc_6_Load(object sender, EventArgs e)
        {

        }

        private void uc_17_Load(object sender, EventArgs e)
        {

        }

        private void uc_11_Load(object sender, EventArgs e)
        {

        }

        private void uc_15_Load(object sender, EventArgs e)
        {

        }

        private void uc_8_Load(object sender, EventArgs e)
        {

        }

        private void uc_2_Load(object sender, EventArgs e)
        {

        }

        private void uc_4_Load(object sender, EventArgs e)
        {

        }

        private void uc_7_Load(object sender, EventArgs e)
        {

        }

        private void uc_9_Load(object sender, EventArgs e)
        {

        }

        private void uc_5_Load(object sender, EventArgs e)
        {

        }

        private void uc_3_Load(object sender, EventArgs e)
        {

        }

        private void uc_1_Load(object sender, EventArgs e)
        {

        }

        private void uc_21_Load(object sender, EventArgs e)
        {

        }

        private void uc_20_Load(object sender, EventArgs e)
        {

        }

        private void uc_18_Load(object sender, EventArgs e)
        {

        }

        private void uc_16_Load(object sender, EventArgs e)
        {

        }

        private void uc_14_Load(object sender, EventArgs e)
        {

        }

        private void uc_12_Load(object sender, EventArgs e)
        {

        }

        private void pn_user0_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb_money0_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb_money1_Click(object sender, EventArgs e)
        {

        }

        private void lb_money2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb_money3_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bt_cai_dat_Click(object sender, EventArgs e)
        {

        }

        private void bt_trang_chu_Click(object sender, EventArgs e)
        {

        }

        private void bt_sound_Click(object sender, EventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void uc_land_left2_Load(object sender, EventArgs e)
        {

        }

        private void uc_land_up2_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sound_buy.Stop();
            sound_buy.Play();
        }

        private void bt_end_step_Click(object sender, EventArgs e)
        {
            lock_dice = false;
            current_user = (current_user + 1) % 4;
        }

        private void land_load_info(string str_id)
        {
            DataRow[] result = lands_info.Select("id =" + str_id);

            foreach (DataRow row in result)
            {
                int id = row.Field<int>(0);
                string name = row.Field<string>(1);
                int MuaDat  = row.Field<int>(2);
                int ThueDat = row.Field<int>(3);
                int XayNha  = row.Field<int>(4);
                int ThueNha = row.Field<int>(5);
                int ThueKS  = row.Field<int>(6);
                uc_info_land.Load_Data(id, name, MuaDat, ThueDat, XayNha, ThueNha, ThueKS);
                break;
            }
        }

       

        private void uc_1_Click(object sender, EventArgs e)
        {   
            //if (uc_info_land.Visible)
            //{
            //    uc_info_land.Visible = false;
            //    return;
            //}
            //string str_id = "1";
            //land_load_info(str_id);
            //uc_info_land.Visible = true;
            
        }
        void vo_tu()
        {
            users[current_user].prison = true;
            users[current_user].position = 7;
            
        }
        void land_user_update(int id_land, int user)
        {
            switch (id_land)
            {
                case  0: uc_0.update_user(user); break;
                case  1: uc_1.update_user(user); break;
                case  2: uc_2.update_user(user); break;
                case  3: uc_3.update_user(user); break;
                case  4: uc_4.update_user(user); break;
                case  5: uc_5.update_user(user); break;
                case  6: uc_6.update_user(user); break;
                case  7: uc_7.update_user(user); break;
                case  8: uc_8.update_user(user); break;
                case  9: uc_9.update_user(user); break;
                case 10: uc_10.update_user(user); break;
                case 11: uc_11.update_user(user); break;
                case 12: uc_12.update_user(user); break;
                case 13: uc_13.update_user(user); break;
                case 14: uc_14.update_user(user); break;
                case 15: uc_15.update_user(user); break;
                case 16: uc_16.update_user(user); break;
                case 17: vo_tu(); break;
                case 18: uc_18.update_user(user); break;
                case 19: uc_19.update_user(user); break;
                case 20: uc_20.update_user(user); break;
                case 21: uc_21.update_user(user); break;
              
                default:
                    break;
            }

        }
        private void tm_choose_Tick(object sender, EventArgs e)
        {
            unchoose_land(users[current_user].position);
            sound_move.Stop();
            if (step-- <= 0)
            {
                tm_choose.Stop();
                update_money();
                return;
            }
            sound_move.Play();
            land_user_update(users[current_user].position, current_user);
            users[current_user].move();
            land_user_update(users[current_user].position, current_user);
            
            choose_land(users[current_user].position);
        }

        private void bt_buy_Click(object sender, EventArgs e)
        {
            sound_buy.Stop();
            sound_buy.Play();

        }
    }
}
