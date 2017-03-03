using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace inno_DebtorMatch_Reminder
{
    public partial class Main : Form
    {
        string sAlertday = "";
        DateTime dtNextAlert;
        string salertduration;

        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            sAlertday = ConfigurationManager.AppSettings["alertday"].ToString();
            salertduration = ConfigurationManager.AppSettings["alertduration"].ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Hide();
            if (DateTime.Now.ToString("dddd") == sAlertday)
            {
                timer1.Start();
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= dtNextAlert)
            {
                dtNextAlert = DateTime.Now.AddHours(double.Parse(salertduration));
                MessageBox.Show("Please match the debtor for IISG-INNO");
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }
    }
}
