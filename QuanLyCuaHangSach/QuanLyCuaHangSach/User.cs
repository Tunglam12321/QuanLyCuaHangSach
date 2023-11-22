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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLCHS;User ID=minhtrong;Password=quynhon");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        private void User_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            save.Enabled = false;
            edit.Enabled = false;
            delete.Enabled = false;
            reset.Enabled = false;
        }

        private void LoadDataGridView()
        {
            con.Open();
            DataTable tblUser = new DataTable();
            adapt = new SqlDataAdapter("select * from tblUser", con);
            adapt.Fill(tblUser);
            user_dgv.DataSource = tblUser;
            user_dgv.Columns[0].HeaderText = "ID";
            user_dgv.Columns[1].HeaderText = "User name";
            user_dgv.Columns[2].HeaderText = "Phone";
            user_dgv.Columns[3].HeaderText = "Address";
            user_dgv.Columns[4].HeaderText = "Password";
            user_dgv.Columns[0].Width = 100;
            user_dgv.Columns[1].Width = 150;
            user_dgv.Columns[2].Width = 150;
            user_dgv.Columns[3].Width = 200;
            user_dgv.Columns[4].Width = 200;
            user_dgv.AllowUserToAddRows = false;
            user_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
            con.Close();

            
        }

        private void save_Click(object sender, EventArgs e)
        {

        }

        private void user_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
