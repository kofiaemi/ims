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
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kaitline\Documents\imsdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from Customertable";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                customerGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        private void customerGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IDtextbox.Text = customerGV.SelectedRows[0].Cells[0].Value.ToString();
            Fullntextbox.Text = customerGV.SelectedRows[0].Cells[1].Value.ToString();
            Emailtextbox.Text = customerGV.SelectedRows[0].Cells[2].Value.ToString();
            Phonetextbox.Text = customerGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into Customertable values('" + IDtextbox.Text + "','" + Fullntextbox.Text + "','" + Emailtextbox.Text + "','" + Phonetextbox.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Successfully Added");
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
                SqlCommand cmd = new SqlCommand("update Customertable set CID='" + IDtextbox.Text + "',CName='" + Fullntextbox.Text + "',CEmail='" + Emailtextbox.Text + "',CPhonenumber='" + Phonetextbox.Text + "'where UUsername='" + IDtextbox.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Details Successfully Updated");
                Con.Close();
                populate();

            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IDtextbox.Text == "")
            {
                MessageBox.Show("Enter ID");
            }
            else
            {
                Con.Open();
                string Myquery = "delete from Customertable where CID='" + IDtextbox.Text + "';";
                SqlCommand cmd = new SqlCommand(Myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Sucessfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
