﻿using System;
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
    public partial class uc_vao_tu : UserControl
    {
        public uc_vao_tu()
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
    }
}
