﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void tbnLogin_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD:QuanLyCuaHangSach_chuan/Login.cs
            SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_Cua_Hang_Sach;Persist Security Info=True;User ID=sa;Password=1234");
=======
            SqlConnection con = new SqlConnection(@"Data Source=admin;Initial Catalog=Test;Integrated Security=True");
>>>>>>> 2b2784368ad7f42ff301269e3f5799e24017dbfe:QuanLyCuaHangSach/QuanLyCuaHangSach/Login.cs
            try
            {
                con.Open();
                string sql = "Select * from tblUser where Name = '"+txbUser.Text+"' and Password = '"+txbPass.Text+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read())
                {
                    BookShop f = new BookShop();
                    f.Show();
                    this.Hide();
                    MessageBox.Show("Đăng nhập thành công");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void tbnExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }
<<<<<<< HEAD:QuanLyCuaHangSach_chuan/Login.cs

        private void Login_Load(object sender, EventArgs e)
        {

        }
=======
>>>>>>> 2b2784368ad7f42ff301269e3f5799e24017dbfe:QuanLyCuaHangSach/QuanLyCuaHangSach/Login.cs
    }
}
