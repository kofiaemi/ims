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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kaitline\Documents\imsdb.mdf;Integrated Security=True;Connect Timeout=30");

        void fillcategory()
        {
            string query = "select * from Categorytable";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            try
            {
                Con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("Categoryname", typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                Catcombo.ValueMember = "Categoryname";
                Catcombo.DataSource = dt;
                Searchcombo.ValueMember = "Categoryname";
                Searchcombo.DataSource = dt;
                Con.Close();
            }
            catch
            {

            }
        }

        
        private void label8_Click(object sender, EventArgs e)
        {

        }

        void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from Producttable";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                ProductGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        void filterbycategory()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from Producttable where ProductCat='"+ Searchcombo.SelectedValue.ToString() +"'";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                ProductGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Product_Load(object sender, EventArgs e)
        {
            fillcategory();
            populate();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into Producttabe values('" + PIDtextbox.Text + "','" + PNameextbox.Text + "','" + PQtytextbox.Text + "','" + PPricetextbox.Text + "','" + PDesctextbox.Text + "','"+ Catcombo.SelectedItem.ToString() +"')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Successfully Added");
                Con.Close();
                populate();

            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PIDtextbox.Text == "")
            {
                MessageBox.Show("Enter ID");
            }
            else
            {
                Con.Open();
                string Myquery = "delete from Producttable where ProductID='" + PIDtextbox.Text + "';";
                SqlCommand cmd = new SqlCommand(Myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Sucessfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PIDtextbox.Text = ProductGV.SelectedRows[0].Cells[0].Value.ToString();
            PNameextbox.Text = ProductGV.SelectedRows[0].Cells[1].Value.ToString();
            PQtytextbox.Text = ProductGV.SelectedRows[0].Cells[2].Value.ToString();
            PPricetextbox.Text = ProductGV.SelectedRows[0].Cells[3].Value.ToString();
            PDesctextbox.Text = ProductGV.SelectedRows[0].Cells[4].Value.ToString();
            Catcombo.SelectedValue = ProductGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update Producttable set ProductID='" + PIDtextbox.Text + "',Productname='" + PNameextbox.Text + "'Productqty='" + PQtytextbox.Text + "',Productprice='" + PPricetextbox.Text + "',Productdesc='" + PDesctextbox.Text + "',ProductCat='" + Catcombo.SelectedValue.ToString() + "'where ProductID='" + PIDtextbox.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Products Successfully Updated");
                Con.Close();
                populate();

            }
            catch
            {

            }
        }

        private void Searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            filterbycategory();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
        }
    }

   
}
