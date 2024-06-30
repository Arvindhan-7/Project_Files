using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fingerprint_security_system
{
    public partial class practicetest : Form
    {
        public practicetest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            content2.Text = content1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            content1.Text = content2.Text;
        }
    }
}
