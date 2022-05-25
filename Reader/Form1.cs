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
    public partial class Form1 : Form
    {
        Input finput;
        public Form1()
        {
            InitializeComponent();
            finput = new Input(this);
        }

        public void Display()
        {
            List<rfidinfo> list = new List<rfidinfo>();
            list = MyConnection.GetTable("select * from RFIDtbl");
            BindingSource bd = new BindingSource();
            bd.DataSource = list;
            dgv_rfid.DataSource = bd;
            dgv_rfid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            finput.ShowDialog();
            finput.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dgv_rfid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_rfid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                finput.RFID = dgv_rfid.Rows[e.RowIndex].Cells["RFID"].FormattedValue.ToString();
                finput.Type = dgv_rfid.Rows[e.RowIndex].Cells["Type"].FormattedValue.ToString();
                finput.EditInfo();
                finput.ShowDialog();
            }
                
        }
    }
}
