namespace Reader
{
    partial class Detect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_type = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.lbl_rfid = new System.Windows.Forms.Label();
            this.txt_rfid = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_type
            // 
            this.lbl_type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_type.AutoSize = true;
            this.lbl_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_type.Location = new System.Drawing.Point(120, 177);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(63, 26);
            this.lbl_type.TabIndex = 0;
            this.lbl_type.Text = "Type";
            // 
            // cb_type
            // 
            this.cb_type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Items.AddRange(new object[] {
            "TLD",
            "LunchBox"});
            this.cb_type.Location = new System.Drawing.Point(211, 179);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(168, 34);
            this.cb_type.TabIndex = 1;
            // 
            // lbl_rfid
            // 
            this.lbl_rfid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_rfid.AutoSize = true;
            this.lbl_rfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rfid.Location = new System.Drawing.Point(120, 78);
            this.lbl_rfid.Name = "lbl_rfid";
            this.lbl_rfid.Size = new System.Drawing.Size(67, 26);
            this.lbl_rfid.TabIndex = 2;
            this.lbl_rfid.Text = "RFID";
            // 
            // txt_rfid
            // 
            this.txt_rfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rfid.Location = new System.Drawing.Point(211, 80);
            this.txt_rfid.Name = "txt_rfid";
            this.txt_rfid.Size = new System.Drawing.Size(168, 32);
            this.txt_rfid.TabIndex = 3;
            this.txt_rfid.TextChanged += new System.EventHandler(this.txt_rfid_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(432, 141);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(0, 20);
            this.lbl_message.TabIndex = 5;
            // 
            // Detect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 446);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.txt_rfid);
            this.Controls.Add(this.lbl_rfid);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.lbl_type);
            this.Name = "Detect";
            this.Text = "Detect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label lbl_rfid;
        private System.Windows.Forms.TextBox txt_rfid;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_message;
    }
}