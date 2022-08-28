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
    public partial class productcategories : Form
    {
        public productcategories()
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
                string Myquery = "select * from Categorytable";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                CategoryGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PCIDtextbox.Text = CategoryGV.SelectedRows[0].Cells[0].Value.ToString();
            Categorytextbox.Text = CategoryGV.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into Categorytable values('" + PCIDtextbox.Text + "','" + Categorytextbox.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Added");
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
                SqlCommand cmd = new SqlCommand("update Categorytable set CID='" + PCIDtextbox.Text + "',CName='" + Categorytextbox.Text + "'where UUsername='" + PCIDtextbox.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Updated");
                Con.Close();
                populate();

            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PCIDtextbox.Text == "")
            {
                MessageBox.Show("Enter ID");
            }
            else
            {
                Con.Open();
                string Myquery = "delete from Categorytable where CategoryID='" + PCIDtextbox.Text + "';";
                SqlCommand cmd = new SqlCommand(Myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Sucessfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void productcategories_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void Categorytextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
