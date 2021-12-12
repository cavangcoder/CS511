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
    public partial class Information : UserControl
    {
        public Information()
        {
            InitializeComponent();
        }
        public void Load_Data(int id, string name, int MuaDat, int ThueDat, int XayNha, int ThueNha, int ThueKS)
        {
            //string name = info["Name"];
            //int MuaDat  = in
            //int ThueDat, int XayNha, int ThueNha, int ThueKS
            //lb_Name.Text = name;
            //lb_ThueDat.Text = "$" + ThueDat.ToString();
            //lb_Thue1.Text = "$" + ThueNha.ToString();
            //lb_Thue2.Text = "$" + (ThueNha * 2).ToString();
            //lb_Thue3.Text = "$" + (ThueNha * 3).ToString();
            //lb_Thue4.Text = "$" + (ThueNha * 4).ToString();
            //lb_ThueKS.Text = "$" + ThueKS.ToString();
            //lb_MuaDat.Text = "$" + MuaDat.ToString();
            //lb_XayNha.Text = "$" + XayNha.ToString();
            //lb_XayKS.Text = "$" + (XayNha * 2).ToString();
        }

        private void Information_Load(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
