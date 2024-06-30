using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace fingerprint_security_system
{
    public partial class login : Form
    {
        string path = @"Data Source=DESKTOP-72L218V\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True";
        SqlConnection con;
  
        public login()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void logbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (u_name.Text=="" &&  pass_name.Text=="")
                {
                    MessageBox.Show("please enter username and password");

                }
                else
                {

                    SqlCommand cmd = new SqlCommand("select * from loginusers where u_name=@name and u_pass=@pass", con);
                    cmd.Parameters.Add("@name", u_name.Text);
                    cmd.Parameters.Add("@pass", pass_name.Text);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        MessageBox.Show("you have successfullu logged in");
                        Form1 ob = new Form1();
                        ob.Show();                    }
                    else
                    {
                        MessageBox.Show("please check user name and password");
                    }
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void u_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
