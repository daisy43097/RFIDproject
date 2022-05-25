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
    public partial class Input : Form
    {
        private readonly Form1 _parent;
        public string RFID, Type;
        public Input(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void EditInfo()
        {
            txt_rfid.Text = RFID;
            cb_type.Text = Type;
        }

        public void Clear()
        {
            txt_rfid.Text = string.Empty;
            cb_type.SelectedIndex = -1;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                rfidinfo info = new rfidinfo();
                info.RFID = txt_rfid.Text;
                info.Type = cb_type.Text;
                MyConnection.Edit(info, txt_rfid.Text);
                MessageBox.Show("RFID Edited Successfully!");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                _parent.Display();
                this.Close();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                MyConnection.Delete(txt_rfid.Text);
                MessageBox.Show("RFID Deleted Successfully!");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                _parent.Display();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                rfidinfo info = new rfidinfo();
                info.RFID = txt_rfid.Text;
                info.Type = cb_type.Text;
                MyConnection.Add(info);
                MessageBox.Show("RFID Added Successfully!");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                _parent.Display();
                this.Close();
                
            }
            
        }
    }
}
