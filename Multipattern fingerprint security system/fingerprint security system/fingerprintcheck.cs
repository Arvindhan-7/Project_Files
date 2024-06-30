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

namespace fingerprint_security_system
{
    public partial class fingerprintcheck : Form
    {
        string path = @"Data Source=DESKTOP-72L218V\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        String id1, id2, id3, id4;
        String recievedata;
        String recievedata1;
        int count = 1;
        Form1 fo2 = new Form1();

        

        public fingerprintcheck(String data)
        {
            InitializeComponent();
           
            idcodebox.Text = data;
            con = new SqlConnection(path);
            serialPort1.Open();


        }
        public void check(String name)
        {
            serialPort1.WriteLine("2");
            serialPort1.WriteLine(name);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                check(id2);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                check(id3);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                check(id4);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            recievedata = serialPort1.ReadLine();
            recievedata1 = recievedata.Trim();
            // databox.Text = recievedata.ToString() + Environment.NewLine;




            this.Invoke(new Action(proccessingdata));
        }

        private void fingerprintcheck_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            submit.Enabled = false;
            panel1.BackColor=Color.Yellow;
            panel2.BackColor=Color.Yellow;
            panel3.BackColor = Color.Yellow;
            panel4.BackColor = Color.Yellow;
            


        }

        private void submit_Click(object sender, EventArgs e)
        {
            
            serialPort1.Close();
            fo2.change.BackColor = Color.White;
            this.Close();
            
        }

        private void databox_TextChanged(object sender, EventArgs e)
        {

        }

        public void proccessingdata()
        {
            databox.AppendText(Environment.NewLine);
            databox.AppendText(recievedata);
            if (recievedata1.Equals("true"))
            {

               MessageBox.Show("PROCCED");
                execution_order();
            }
            if (recievedata1.Equals("false"))
            {

                MessageBox.Show("biometric data does not match!!");
               // serialPort1.Close();
                
               // this.Close();
                
            }
        }
        public void execution_order()
        {
            if (count == 1)
            {
                button2.Enabled = true;
                count = count + 1;
                panel1.BackColor = Color.Green;
                button1.Enabled = false;
                return;

            }

            if (count == 2)
            {
                button3.Enabled = true;
                count = count + 1;
                panel2.BackColor = Color.Green;
                button2.Enabled = false;
                return;

            }

            if (count == 3)
            {
                button4.Enabled = true;
                count = count + 1;
                panel3.BackColor = Color.Green;
                button3.Enabled = false;
                return;

            }

            if (count == 4)
            {
                submit.Enabled = true;
                count = count + 1;
                panel4.BackColor = Color.Green;
                button4.Enabled = false;
                return;

            }
        }




            private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
                con.Open();
                cmd = new SqlCommand("select f_id1,f_id2,f_id3,f_id4 from fingerdata where f_idcode=@id", con);
                cmd.Parameters.AddWithValue("id", idcodebox.Text);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    id1 = reader["f_id1"].ToString();
                    id2 = reader["f_id2"].ToString();
                    id3 = reader["f_id3"].ToString();
                    id4 = reader["f_id4"].ToString();
                    


                }
                else
                {
                    MessageBox.Show("no data found");
                }
                con.Close();
                check(id1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
   

    }
}
