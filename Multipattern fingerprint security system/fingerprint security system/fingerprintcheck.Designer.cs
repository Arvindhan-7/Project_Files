namespace fingerprint_security_system
{
    partial class fingerprintcheck
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idcodebox = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.databox = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.idcodebox);
            this.groupBox1.Controls.Add(this.submit);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.databox);
            this.groupBox1.Location = new System.Drawing.Point(-2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 446);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BIOMETRIC DATA";
            // 
            // idcodebox
            // 
            this.idcodebox.Location = new System.Drawing.Point(116, 0);
            this.idcodebox.Name = "idcodebox";
            this.idcodebox.Size = new System.Drawing.Size(100, 20);
            this.idcodebox.TabIndex = 13;
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.submit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.submit.Location = new System.Drawing.Point(197, 378);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(118, 55);
            this.submit.TabIndex = 12;
            this.submit.Text = "SUBMIT";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(478, 215);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 33);
            this.button4.TabIndex = 11;
            this.button4.Text = "SCAN";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(330, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 33);
            this.button3.TabIndex = 10;
            this.button3.Text = "SCAN";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(187, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 33);
            this.button2.TabIndex = 9;
            this.button2.Text = "SCAN";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel4.Location = new System.Drawing.Point(449, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(103, 111);
            this.panel4.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(30, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "SCAN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Location = new System.Drawing.Point(312, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(103, 111);
            this.panel3.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Location = new System.Drawing.Point(171, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(103, 111);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(16, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 111);
            this.panel1.TabIndex = 3;
            // 
            // databox
            // 
            this.databox.Location = new System.Drawing.Point(571, 19);
            this.databox.Multiline = true;
            this.databox.Name = "databox";
            this.databox.Size = new System.Drawing.Size(220, 413);
            this.databox.TabIndex = 2;
            this.databox.TextChanged += new System.EventHandler(this.databox_TextChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // fingerprintcheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "fingerprintcheck";
            this.Text = "fingerprintcheck";
            this.Load += new System.EventHandler(this.fingerprintcheck_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox idcodebox;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox databox;
        private System.IO.Ports.SerialPort serialPort1;
    }
}