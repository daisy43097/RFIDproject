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
    public partial class Detect : Form
    {
        List<rfidinfo> detectedRFID = 
            new List<rfidinfo>(); // <rfid_tag, category, latest_seen_time>
        Dictionary<string, Tuple<string, DateTime>> DB = 
            new Dictionary<string, Tuple<string, DateTime>>(); // <rfid_tag, <category, (time_get_from_DB)>>
        
        public Detect()
        {
            InitializeComponent();
            DB = MyConnection.GetDict("select * from RFIDtbl");
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_message.Text = String.Empty;
            string messageshown = "Clear!";
            foreach(rfidinfo item in detectedRFID.ToList())
            {
                if (item.Type == "LunchBox" && item.SeenTime >= item.CheckTime) 
                {
                    messageshown = item.RFID + "Food is not allowed!";
                }
                listView1.Items.Add(new ListViewItem(new string[] { item.RFID, item.Type, item.SeenTime.ToLongTimeString(), item.CheckTime.ToLongTimeString() }));
                item.CheckTime = DateTime.Now;
            }
            lbl_message.Text = messageshown;
        }

        private void btn_scan_Click(object sender, EventArgs e)
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
                            if (!detectedRFID.Any(x => x.RFID == Tag)) // added to the list
                            {
                                rfidinfo info = new rfidinfo();
                                info.RFID = Tag;
                                info.Type = DB[Tag].Item1;
                                info.SeenTime = DateTime.Now;
                                info.CheckTime = DateTime.Now;
                                detectedRFID.Add(info);
                            }
                            else // update existing rfid info
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
    }
}
