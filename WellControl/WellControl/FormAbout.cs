using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WellControl
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 单击公司网址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files\Internet Explorer\iexplore.exe";
            p.StartInfo.Arguments = LinkUrl.Text;
            p.Start();
            p.Close();
        }
    }
}
