using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rfidsinfo;
using DBconnection;

namespace Reader
{
    public partial class Detect : Form
    {
        public Detect()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txt_rfid.Text = string.Empty;
            cb_type.SelectedIndex = -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_rfid.Text))
            {
                try
                {
                    rfidinfo info = new rfidinfo();
                    info.RFID = txt_rfid.Text;
                    info.Type = cb_type.Text;
                    bool isFound = MyConnection.Check(info);
                    if (isFound)
                    {
                        lbl_message.Text = cb_type.Text + " " + txt_rfid.Text + " " + "is not suppose to be here!";
                    }
                    else
                    {
                        lbl_message.Text = "You are clear!";
                    }
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
