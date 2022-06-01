using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using rfidsinfo;
using DBconnection;
using Microsoft.AspNet.SignalR.Client;

namespace Reader
{
    public partial class DetectFood : Form
    {
        List<rfidinfo> detectedRFID = 
            new List<rfidinfo>(); // <rfid_tag, category, latest_seen_time, check_time>
        List<rfidinfo> tobeConfig =
            new List<rfidinfo>(); // <rfid_tag, category, latest_seen_time, check_time>
        Dictionary<string, Tuple<string, DateTime>> DB = 
            new Dictionary<string, Tuple<string, DateTime>>(); // <rfid_tag, <category, (time_get_from_DB)>>
        private readonly Form2 _parent;
        int countFood = 0;

        public DetectFood(Form2 parent)
        {
            InitializeComponent();
            DB = MyConnection.GetDict("select * from RFIDtbl");
            _parent = parent;
            pic_logo.Location = new Point(10, 10);
            pic_logo.Size = new Size(82, 84);
            pic_food.Location = new Point(10, (this.Height+pic_food.Height) / 2);
            pic_food.Hide();
            lbl_countFood.Location = new Point((this.Width - lbl_countFood.Width - 160), 
                (this.Height - lbl_countFood.Height - 150));
            pictureBox1.Location = new Point((this.Width - pictureBox1.Width - 10), 10);
            lbl_detecting.Location = new Point((this.Width) / 2, 170);
        }

        public bool isNotAllowed(string type, string notAllowedType)
        {
            if (type == notAllowedType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Scan()
        {
            try
            {
                var connection = new HubConnection("http://192.168.30.121:5501/signalr");
                var myHub = connection.CreateHubProxy("connectionHub");

                connection.Start().Wait();

                myHub.On("ListenToData", (string Tag, string Ant) =>
                {
                    try
                    {
                        if (DB.ContainsKey(Tag))
                        {
                            if (!detectedRFID.Any(x => x.RFID == Tag)) // added to the detected list
                            {
                                rfidinfo info = new rfidinfo();
                                info.RFID = Tag;
                                info.Type = DB[Tag].Item1;
                                info.SeenTime = DateTime.Now;
                                info.CheckTime = DateTime.Now;
                                detectedRFID.Add(info);
                            }
                            else // update existing rfid seen time in detected list
                            {
                                var found = detectedRFID.FirstOrDefault(x => x.RFID == Tag);
                                found.Type = DB[Tag].Item1;
                                found.SeenTime = DateTime.Now;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            countFood = 0;
            lbl_message.Text = String.Empty;
            string messageshown = String.Empty;
            string tags = string.Empty;
            foreach(rfidinfo item in detectedRFID.ToList())
            {
                if ((DateTime.Now - item.SeenTime).Seconds > 10)
                {
                    detectedRFID.Remove(item);
                    tobeConfig.Add(item);
                }
                else
                {
                    if (isNotAllowed(item.Type, "LunchBox") && item.SeenTime >= item.CheckTime)
                    {
                        countFood++;
                        tags += item.RFID + ", ";
                    }
                    listView1.Items.Add(new ListViewItem(new string[] { item.RFID, item.Type, item.SeenTime.ToLongTimeString(), item.CheckTime.ToLongTimeString() }));
                    item.CheckTime = DateTime.Now;
                }
            }
            if (countFood > 0)
            {
                messageshown = "Food is not allowed! Please remove Food!";
                pic_food.Show();
            } else
            {
                messageshown = "Clear!";
                pic_food.Hide();
            }
            lbl_message.Text = messageshown;
            lbl_countFood.Text = "# of LunchBox(es): " + countFood;
        }

        

        private void Detect_Load(object sender, EventArgs e)
        {
            Scan();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
