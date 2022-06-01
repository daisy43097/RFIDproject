namespace Reader
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btn_food = new System.Windows.Forms.Button();
            this.btn_tld = new System.Windows.Forms.Button();
            this.pic_name = new System.Windows.Forms.PictureBox();
            this.pic_contact = new System.Windows.Forms.PictureBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_demo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_contact)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_food
            // 
            this.btn_food.AutoSize = true;
            this.btn_food.BackColor = System.Drawing.SystemColors.Control;
            this.btn_food.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_food.ForeColor = System.Drawing.Color.Brown;
            this.btn_food.Location = new System.Drawing.Point(357, 446);
            this.btn_food.Name = "btn_food";
            this.btn_food.Size = new System.Drawing.Size(341, 112);
            this.btn_food.TabIndex = 0;
            this.btn_food.Text = "Food Container Control";
            this.btn_food.UseVisualStyleBackColor = false;
            this.btn_food.Click += new System.EventHandler(this.btn_food_Click);
            // 
            // btn_tld
            // 
            this.btn_tld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tld.AutoSize = true;
            this.btn_tld.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tld.ForeColor = System.Drawing.Color.Brown;
            this.btn_tld.Location = new System.Drawing.Point(625, 446);
            this.btn_tld.Name = "btn_tld";
            this.btn_tld.Size = new System.Drawing.Size(331, 112);
            this.btn_tld.TabIndex = 1;
            this.btn_tld.Text = "TLD Control Xray Gate";
            this.btn_tld.UseVisualStyleBackColor = true;
            this.btn_tld.Click += new System.EventHandler(this.btn_tld_Click);
            // 
            // pic_name
            // 
            this.pic_name.Image = ((System.Drawing.Image)(resources.GetObject("pic_name.Image")));
            this.pic_name.Location = new System.Drawing.Point(12, 12);
            this.pic_name.Name = "pic_name";
            this.pic_name.Size = new System.Drawing.Size(625, 53);
            this.pic_name.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_name.TabIndex = 2;
            this.pic_name.TabStop = false;
            // 
            // pic_contact
            // 
            this.pic_contact.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pic_contact.Image = ((System.Drawing.Image)(resources.GetObject("pic_contact.Image")));
            this.pic_contact.Location = new System.Drawing.Point(0, 680);
            this.pic_contact.Name = "pic_contact";
            this.pic_contact.Size = new System.Drawing.Size(1335, 68);
            this.pic_contact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_contact.TabIndex = 3;
            this.pic_contact.TabStop = false;
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.Brown;
            this.btn_exit.Location = new System.Drawing.Point(1229, 12);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(85, 47);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "EXIT";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_demo
            // 
            this.lbl_demo.AutoSize = true;
            this.lbl_demo.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_demo.ForeColor = System.Drawing.Color.Brown;
            this.lbl_demo.Location = new System.Drawing.Point(474, 177);
            this.lbl_demo.Name = "lbl_demo";
            this.lbl_demo.Size = new System.Drawing.Size(644, 74);
            this.lbl_demo.TabIndex = 5;
            this.lbl_demo.Text = "NVS RFID Gates Demo";
            this.lbl_demo.UseCompatibleTextRendering = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 748);
            this.Controls.Add(this.lbl_demo);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.pic_contact);
            this.Controls.Add(this.pic_name);
            this.Controls.Add(this.btn_tld);
            this.Controls.Add(this.btn_food);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pic_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_contact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_food;
        private System.Windows.Forms.Button btn_tld;
        private System.Windows.Forms.PictureBox pic_name;
        private System.Windows.Forms.PictureBox pic_contact;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lbl_demo;
    }
}