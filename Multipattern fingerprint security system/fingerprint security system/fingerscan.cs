using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;


namespace fingerprint_security_system
{
    public partial class fingerscan : Form
    {
        string path = @"Data Source=DESKTOP-72L218V\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        String recievedata;
        String recievedata1;


        int count = 1;
        Form1 fo1 = new Form1();

        public String data;

        public fingerscan(String data)
        {
            InitializeComponent();
            con = new SqlConnection(path);
            this.data = data;
            idcodebox.Text = data;
         


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // String[] values = { id_1.Text, id_2.Text, id_3.Text, id_4.Text };

                
                enroll(id_1.Text);
               





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error..!");

            }

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            recievedata = serialPort1.ReadLine();
            recievedata1 = recievedata.Trim();
            // databox.Text = recievedata.ToString() + Environment.NewLine;
           
              


                this.Invoke(new Action(proccesingdata));
        }
        private void proccesingdata()
        {    
            databox.AppendText(Environment.NewLine);
            databox.AppendText(recievedata);
            if (recievedata1.Equals("true"))
            {
                
                //MessageBox.Show("PROCCED");
                execution_order();

            }
            if (recievedata1.Equals("false"))
            {
              
                MessageBox.Show("INVALID ...TRY AGAIN!!");
            }

            // databox.Text = recievedata.ToString() + Environment.NewLine;

        }
        public void execution_order()
        {
            if (count == 1)
            {
                button2.Enabled = true;
                count = count + 1;
                panel1.BackColor=Color.Green;
                return;

            }

            if (count == 2)
            {
                button3.Enabled = true;
                count = count + 1;
                panel2.BackColor = Color.Green;
                return;

            }

            if (count ==3)
            {
                button4.Enabled = true;
                count = count + 1;
                panel3.BackColor = Color.Green;
                return;

            }

            if (count == 4)
            {
                submit.Enabled = true;
                count = count + 1;
                panel4.BackColor = Color.Green;
                return;

            }


        }

        public void enroll(String name)
        {
            serialPort1.WriteLine("1");
            serialPort1.WriteLine(name);

        }
        public void delete(String name)
        {
            serialPort1.WriteLine("3");
            serialPort1.WriteLine(name);


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


                enroll(id_2.Text);
               




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                enroll(id_3.Text);
               




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


                enroll(id_4.Text);
               





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void fingerscan_Load(object sender, EventArgs e)
        {
          
           
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            // submit.Enabled = false;
            serialPort1.Open();
           
        }

        private void submit_Click(object sender, EventArgs e)
        {   
            try
            {
                
                con.Open();
                cmd = new SqlCommand("insert into fingerdata(f_idcode,f_id1,f_id2,f_id3,f_id4)values('" + idcodebox.Text + "','" + id_1.Text + "','" + id_2.Text + "','" + id_3.Text + "','" + id_4.Text + "');", con);
                cmd.ExecuteNonQuery();
                con.Close();
                serialPort1.Close();
                

                

              
                

                this.Close();
               
               
               

                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        
    }
}
