﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFMutualFriendSuggetionHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ServiceHost sh = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            sh = new ServiceHost(typeof(WCFMutualFriendSuggetionService.Service1));
            sh.Open();
            label1.Text = "Service Running";
        }
    }
}