using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class Timkiem : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLCHS;User ID=minhtrong;Password=quynhon");
        SqlCommand cmd,cmd1;
        SqlDataAdapter adapt,adapt1,adapt2;
        DataTable tblUser = new DataTable();
        DataTable tblUser1 = new DataTable();
        DataTable tblUser2 = new DataTable();
        DataTable tblUser3 = new DataTable();
        public Timkiem()
        {
            InitializeComponent();
           LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            user_dgv.Visible = false;
            dataGridView1.Visible = false;
        } 

            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
      
        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            cmd = con.CreateCommand();
            user_dgv.Visible=true; dataGridView1.Visible=false; dataGridView2.Visible = false;
            int i = 0;
            int.TryParse(tb_timkiem.Text, out i);
            adapt = new SqlDataAdapter(" select * from tblUser where Name ='"+tb_timkiem.Text+"' or IDuser="+i+"", con);
            tblUser.Clear();
            adapt.Fill(tblUser);
            user_dgv.DataSource = tblUser;
            user_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            user_dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void user_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd1 = con.CreateCommand();
            user_dgv.Visible = false; dataGridView1.Visible = false; dataGridView2.Visible = true;
            int i = 0;
            int.TryParse(tb_timkiem.Text, out i);
            adapt2 = new SqlDataAdapter(" select * from tblBills where clientname ='" + tb_timkiem.Text + "' or IDbills=" + i + "", con);
            tblUser2.Clear();
            adapt2.Fill(tblUser2);
            dataGridView2.DataSource = tblUser2;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void Timkiem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd1 = con.CreateCommand();
            user_dgv.Visible = false; dataGridView1.Visible = true; dataGridView2.Visible = false;
            int i = 0;
            int.TryParse(tb_timkiem.Text, out i);
            adapt1 = new SqlDataAdapter(" select * from tblNhapSach where Booktitle ='" + tb_timkiem.Text + "' or IDimport=" + i + "", con);
            tblUser1.Clear();
            adapt1.Fill(tblUser1);
            dataGridView1.DataSource = tblUser1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
