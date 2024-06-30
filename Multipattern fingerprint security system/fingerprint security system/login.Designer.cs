namespace fingerprint_security_system
{
    partial class login
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
            this.u_nam12 = new System.Windows.Forms.Label();
            this.u_name = new System.Windows.Forms.TextBox();
            this.pass_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // u_nam12
            // 
            this.u_nam12.AutoSize = true;
            this.u_nam12.Location = new System.Drawing.Point(57, 193);
            this.u_nam12.Name = "u_nam12";
            this.u_nam12.Size = new System.Drawing.Size(68, 13);
            this.u_nam12.TabIndex = 0;
            this.u_nam12.Text = "USERNAME";
            // 
            // u_name
            // 
            this.u_name.Location = new System.Drawing.Point(133, 190);
            this.u_name.Name = "u_name";
            this.u_name.Size = new System.Drawing.Size(227, 20);
            this.u_name.TabIndex = 1;
            this.u_name.TextChanged += new System.EventHandler(this.u_name_TextChanged);
            // 
            // pass_name
            // 
            this.pass_name.Location = new System.Drawing.Point(133, 239);
            this.pass_name.Name = "pass_name";
            this.pass_name.Size = new System.Drawing.Size(227, 20);
            this.pass_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PASSWORD";
            // 
            // logbtn
            // 
            this.logbtn.BackColor = System.Drawing.Color.IndianRed;
            this.logbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logbtn.Location = new System.Drawing.Point(114, 322);
            this.logbtn.Name = "logbtn";
            this.logbtn.Size = new System.Drawing.Size(160, 49);
            this.logbtn.TabIndex = 4;
            this.logbtn.Text = "login";
            this.logbtn.UseVisualStyleBackColor = false;
            this.logbtn.Click += new System.EventHandler(this.logbtn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 491);
            this.Controls.Add(this.logbtn);
            this.Controls.Add(this.pass_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.u_name);
            this.Controls.Add(this.u_nam12);
            this.Name = "login";
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label u_nam12;
        private System.Windows.Forms.TextBox u_name;
        private System.Windows.Forms.TextBox pass_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logbtn;
    }
}