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
using System.CodeDom;
using System.IO;
using System.Drawing.Imaging;
//using static System.Net.Mime.MediaTypeNames;

namespace fingerprint_security_system
{
    public partial class Form1 : Form
    {
        string path = @"Data Source=DESKTOP-72L218V\SQLEXPRESS;Initial Catalog=registration;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID;
        public DialogResult response;
        public DialogResult response1;
        public static Form1 instance;
        public  String imgloc = "";

       



    public Form1()

        {
            con = new SqlConnection(path);

            InitializeComponent();
            display();
            instance = this;
           

           
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (response == DialogResult.OK)
            {
                if (name.Text == "" || fathername.Text == "" || email.Text == "" || design.Text == "" || id.Text == "")
                {
                    MessageBox.Show("please fill the required details");
                }
                else
                {
                    try
                    {

                        String gender;
                        if (male.Checked)
                        {
                            gender = "male";

                        }
                        else
                        {
                            gender = "female";
                        }
                        Image image = picbox.Image;
                        byte[] imageBytes;
                        using (MemoryStream stream = new MemoryStream())
                        {
                            image.Save(stream, ImageFormat.Jpeg);
                            imageBytes = stream.ToArray();
                        }
                        con.Open();
                        cmd = new SqlCommand("insert into persondata(p_name,p_fname,p_email,gender,p_designation,p_idcode,pic)values('" + name.Text + "','" + fathername.Text + "','" + email.Text + "','" + gender + "','" + design.Text + "','" + id.Text + "',@image);",con);
                        cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageBytes;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("successfully saved!!");
                        clear();
                        display();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            else
            {
                MessageBox.Show("inavalid or re enter biometric data");

            
            }
        }
        
        public void clear()
        {
            name.Text = "";
            fathername.Text = "";
            id.Text = "";
            email.Text = "";
            design.Text = "";
            picbox.Image=null;
        }
        public void display()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from persondata ", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           fathername.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            email.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            design.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            id.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            byte[] imageBytes = new byte[0];
           
                cmd = new SqlCommand("SELECT pic FROM persondata WHERE p_id=@Id", con);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ID;

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    if (reader.Read())
                    {
                        long bytesCount = reader.GetBytes(0, 0, null, 0, 0);
                        imageBytes = new byte[bytesCount];
                        reader.GetBytes(0, 0, imageBytes, 0, (int)bytesCount);
                    }
                }
            

           
            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(stream);

              
                picbox.Image = image;
            }

            // picbox.Image = getimage((byte[])dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            male.Checked = true;
            female.Checked = false;
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "female")
            {
                male.Checked = false;
                female.Checked = true;

            }
            button2.Enabled = true;
            button3.Enabled = true;

        }
        
       

        private void button2_Click(object sender, EventArgs e)
        {
           

            if (response1 == DialogResult.OK) {
                try
                {
                

                    String gender;
                    if (male.Checked)
                    {
                        gender = "male";

                    }
                    else
                    {
                        gender = "female";
                    }
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("delete from persondata where p_id='" + ID + "'; ",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                   
                    
                    
                    
                    Image image1= picbox.Image;
                    byte[] imageBytes1;
                    using (MemoryStream stream = new MemoryStream())
                    {
                        image1.Save(stream, ImageFormat.Jpeg);
                        imageBytes1= stream.ToArray();
                    }
                    con.Open();
                    cmd = new SqlCommand("insert into persondata(p_name,p_fname,p_email,gender,p_designation,p_idcode,pic)values('" + name.Text + "','" + fathername.Text + "','" + email.Text + "','" + gender + "','" + design.Text + "','" + id.Text + "',@image);", con);
                    cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageBytes1;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("successfully updated!!");
                    clear();
                    display();



                    /*
                    Image image = picbox.Image;
                    byte[] imageBytes;
                    using (MemoryStream stream = new MemoryStream())
                    {
                        image.Save(stream, ImageFormat.Jpeg);
                        imageBytes = stream.ToArray();
                    }
                    
                    con.Open();
                   
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update persondata set p_name='" + name.Text + "',p_fname='" + fathername.Text + "',p_email='" + email.Text + "',gender='" + gender + "',p_designation='" + design.Text + "',p_idcode='" + id.Text + "',pic=@image where p_id='" + ID + "';", con);
                    cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageBytes;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("updated successfully!!!");
                    display();*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                MessageBox.Show("inavalid or re enter biometric data");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (response1 ==DialogResult.OK) {
                try
                {
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("delete from persondata where p_id='" + ID + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("record deleted!!");
                    con.Close();
                    display();

                    con.Open();
                    cmd = new SqlCommand("delete from fingerdata where f_idcode='" + id.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("fingerprint successfully deleted!!");
                    con.Close();

    ;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("inavalid or re enter biometric data");
            }
           

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from persondata where p_idcode like  '%" + textBox.Text + "%'", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            fingerscan fgsc = new fingerscan(id.Text);
            
            
            response = fgsc.ShowDialog();
            fgsc.idcodebox.Text = id.Text;



        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                fingerprintcheck fgch = new fingerprintcheck(id.Text);
                response1=fgch.ShowDialog();
                fgch.idcodebox.Text = id.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        { OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                imgloc = openfile.FileName.ToString();
                picbox.Image = new Bitmap(openfile.FileName);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
       
}
}
