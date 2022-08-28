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

namespace ims
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kaitline\Documents\imsdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void populate()
        {
            try
            {
                Con.Open();
                string Myquery="select * from usertable";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                UserGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Usernametextbox.Text == "")
            {
                MessageBox.Show("Enter Username");
            }
            else
            {
                Con.Open();
                string Myquery = "delete from usertable where UUsername='" + Usernametextbox.Text + "';";
                SqlCommand cmd = new SqlCommand(Myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Sucessfully Deleted");
                Con.Close();
                populate();
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into usertable values('" + Fntextbox.Text + "','" + Lntextbox.Text + "','" + Emailtextbox.Text + "','" + Pntextbox.Text + "','" + Usernametextbox.Text + "','" + Passwordtextbox.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added");
                Con.Close();
                populate();

            }
            catch
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update usertable set UFirstname='" + Fntextbox.Text + "',ULastname='" + Lntextbox.Text + "',UEmail='" + Emailtextbox.Text + "',UPhonenumber='" + Pntextbox.Text + "',UUsername='" + Usernametextbox.Text + "',UPassword='" + Passwordtextbox.Text + "'where UUsername='"+Usernametextbox.Text+"')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Credentials Successfully Updated");
                Con.Close();
                populate();

            }
            catch
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void UsersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    
      

        private void Passwordtextbox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Usernametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pntextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ontextbox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Fntextbox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Lntextbox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Emailtextbox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void UserGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Fntextbox.Text = UserGV.SelectedRows[0].Cells[0].Value.ToString();
            Lntextbox.Text = UserGV.SelectedRows[0].Cells[1].Value.ToString();
            Emailtextbox.Text = UserGV.SelectedRows[0].Cells[2].Value.ToString();
            Pntextbox.Text = UserGV.SelectedRows[0].Cells[3].Value.ToString();
            Usernametextbox.Text = UserGV.SelectedRows[0].Cells[4].Value.ToString();
            Passwordtextbox.Text = UserGV.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
}
