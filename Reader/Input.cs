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
    public partial class Input : Form
    {
        private readonly Form1 _parent;
        public string RFID, Type;
        Dictionary<string, Tuple<string, DateTime>> detectedID =
            new Dictionary<string, Tuple<string, DateTime>>(); // dict<RFID, <type, DateTime>>

        
        public Input(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
            detectedID = MyConnection.GetDict("select * from RFIDtbl");
        }

        public void EditInfo()
        {
            txt_rfid.Text = RFID;
            cb_type.Text = Type;
        }

        public void Clear()
        {
            if (txt_rfid.InvokeRequired)
                txt_rfid.Invoke(new MethodInvoker(() => txt_rfid.Text = String.Empty));
            else
                txt_rfid.Text = String.Empty;
            if (cb_type.InvokeRequired)
                cb_type.Invoke(new MethodInvoker(() => cb_type.SelectedIndex = -1));
            else
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
                detectedID[txt_rfid.Text] = new Tuple<string, DateTime>(info.Type, DateTime.Now);
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
                this.Invoke((MethodInvoker)delegate
                {
                    // close the form on the forms thread
                    this.Close();
                });
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                MyConnection.Delete(txt_rfid.Text);
                detectedID.Remove(txt_rfid.Text);
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
                this.Invoke((MethodInvoker)delegate
                {
                    // close the form on the forms thread
                    this.Close();
                });
            }
        }

        
        private void WriteTextSafe(Control ctrl, string tag)
        {
            if (ctrl.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { WriteTextSafe(ctrl, $"{tag} "); };
                ctrl.Invoke(safeWrite);
            }
            else
                ctrl.Text = tag;
        }

        private string ReadTextSafe(Control ctrl)
        {
            string text;
            if (ctrl.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { ReadTextSafe(ctrl); };
                text = (string)ctrl.Invoke(safeWrite);
            }
            else
                text = ctrl.Text;
            return text;
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
                        if (txt_rfid.InvokeRequired)
                            txt_rfid.Invoke(new MethodInvoker(() => txt_rfid.Text = Tag));
                        else
                            txt_rfid.Text = Tag;
                        if (detectedID.ContainsKey(Tag))
                        {
                            if (cb_type.InvokeRequired)
                                cb_type.Invoke(new MethodInvoker(() => cb_type.Text = detectedID[txt_rfid.Text].Item1));
                            else
                                cb_type.Text = detectedID[txt_rfid.Text].Item1;
                        } 
                        
                        //else
                        //{
                        //    if (cb_type.InvokeRequired)
                        //        cb_type.Invoke(new MethodInvoker(() => cb_type.SelectedIndex = -1));
                        //    else
                        //        cb_type.SelectedIndex = -1;
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                });
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                
            }
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                string cbtext; // temp store combobox value, should be optimized later
                if (cb_type.InvokeRequired)
                    cb_type.Invoke(new MethodInvoker(() => cbtext = cb_type.Text));
                else
                    cbtext = cb_type.Text;
                // date time is always the first time seen this tag with its category
                if (detectedID.ContainsKey(txt_rfid.Text))
                {
                    cb_type.Text = detectedID[txt_rfid.Text].Item1;
                }
                else
                {
                    rfidinfo info = new rfidinfo();
                    info.RFID = txt_rfid.Text;
                    if (cb_type.InvokeRequired)
                        cb_type.Invoke(new MethodInvoker(() => info.Type = cb_type.Text));
                    else
                        info.Type = cb_type.Text;
                    MyConnection.Add(info);
                    MessageBox.Show("RFID Added Successfully!");
                    detectedID[info.RFID] = new Tuple<string, DateTime>(info.Type, DateTime.Now);
                    
                    info.Clear();
                }
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                
                _parent.Display();
                this.Invoke((MethodInvoker)delegate
                {
                        // close the form on the forms thread
                        this.Close();
                });
                
            }
        }
    }
}
