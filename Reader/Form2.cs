using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reader
{
    public partial class Form2 : Form
    {
        DetectFood fdetectfood;
        DetectTLD fTLD;
        public Form2()
        {
            InitializeComponent();
            fdetectfood = new DetectFood(this);
            fTLD = new DetectTLD(this);
            btn_food.Location = new Point((this.Width) / 4, (this.Height ) / 3 * 2);
            btn_tld.Location = new Point((this.Width) / 2, (this.Height) / 3 * 2);
            pic_name.Location = new Point(10, 10);
            pic_name.Size = new Size(625, 84);
            btn_exit.Location = new Point((this.Width - btn_exit.Width - 10), 10);
            lbl_demo.Location = new Point((this.Width) / 2, 170);
        }

        private void btn_food_Click(object sender, EventArgs e)
        {
            fdetectfood.ShowDialog();
        }

        private void btn_tld_Click(object sender, EventArgs e)
        {
            fTLD.ShowDialog();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
