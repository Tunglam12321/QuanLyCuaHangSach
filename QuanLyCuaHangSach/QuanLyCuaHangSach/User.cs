using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyCuaHangSach
{
    public partial class txtUser : Form
    {
        public txtUser()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("server=ADMIN\\SLTP;" + "uid=tk1;pwd=1;" + "database = QL_Cua_Hang_Sach");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;

        private void User_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            //save.Enabled = false;
            //edit.Enabled = false;
            //delete.Enabled = false;
            //reset.Enabled = false;
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
            if (txtUsername.Text != "" && txtPhone.Text != "" && txtAddress.Text != "" && txtPassword.Text != "")
            {
                cmd = new SqlCommand("insert into tblUser(Name,Phone,Address,Password) values(@name,@phone,@address,@password)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", txtUsername.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Lưu thông tin thành công !");
                LoadDataGridView();
                ClearData();
            }
            else
            {   
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
        }

        private void ClearData()
        {
            txtUsername.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtPassword.Text = "";
            ID = 0;
        }

        private void user_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(user_dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtUsername.Text = user_dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = user_dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAddress.Text = user_dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPassword.Text = user_dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPhone.Text != "" && txtAddress.Text != "" && txtPassword.Text != "")
            {
                cmd = new SqlCommand("update tblUser set Name=@name,Phone=@phone,Address=@address,Password=@password where IDuser=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", txtUsername.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công");
                con.Close();
                LoadDataGridView();
                ClearData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bản ghi để cập nhật");
            }
        }
    }
}
