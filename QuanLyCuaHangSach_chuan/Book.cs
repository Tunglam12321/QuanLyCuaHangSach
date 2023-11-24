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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyCuaHangSach
{
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }
        string con = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=QL_Cua_Hang_Sach;Persist Security Info=True;User ID=sa;Password=1234";
        int id = 0;
        private void loadform()
        {
            List<string> cate1=new List<string> { "Chính trị-PL", "Khoa học CN -Kinh tế", "Văn học nghệ thuật", "VHXH- Lịch sử","Giáo trình","Truyện, tiểu thuyết","Tâm lý, tâm linh, tôn giáo","Sách thiếu nhi" };
            List<string> cate2 = new List<string> { "Chính trị-PL", "Khoa học CN -Kinh tế", "Văn học nghệ thuật", "VHXH- Lịch sử", "Giáo trình", "Truyện, tiểu thuyết", "Tâm lý, tâm linh, tôn giáo", "Sách thiếu nhi" };

            string query = "select * from NhapSach";
            // Thêm dữ liệu vào ComboBox
            categories_cb.DataSource=cate1;
            // hoặc
            booklist_cb.DataSource=cate2;
            book_dgv.Columns[0].HeaderText = "ID";
            book_dgv.Columns[1].HeaderText = "Title";
            book_dgv.Columns[2].HeaderText = "Author";
            book_dgv.Columns[3].HeaderText = "Categories";
            book_dgv.Columns[4].HeaderText = "Quan";
            book_dgv.Columns[5].HeaderText = "PriceImport";
            book_dgv.Columns[6].HeaderText = "PriceSell";
            book_dgv.Columns[7].HeaderText = "Store";
            book_dgv.Columns[8].HeaderText = "NXB";
            book_dgv.Columns[9].HeaderText = "Date";
            book_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            using (SqlConnection connection=new SqlConnection(con))
            {
                connection.Open();
                book_dgv.ClearSelection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            book_dgv.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                        }
                    }
                }
            }


        }
        private void Book_Load(object sender, EventArgs e)
        {
            loadform();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            booktitle.Text = "";
            author.Text = "";
            categories_cb.Text = "";
            quantity.Text = "";
            price_sell.Text = "";
            price_im.Text = "";
            store.Text = "";
            NXB.Text = "";
        }

        private void refesh_Click(object sender, EventArgs e)
        {
            book_dgv.Rows.Clear();
            loadform();
        }

        private void booklist_cb_SelectedValueChanged(object sender, EventArgs e)
        {
            book_dgv.Rows.Clear();
            string bo=booklist_cb.SelectedItem.ToString();
            using(SqlConnection connection=new SqlConnection(con))
            {
                connection.Open();
                string query = "select * from NhapSach where categories=@cate";
                using(SqlCommand command=new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cate", bo);
                    using(SqlDataReader reader=command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            book_dgv.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));

                        }
                    }
                }
            }
           
        }

        private void delete_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection=new SqlConnection(con))
            {
                connection.Open();
                string query = "delete from NhapSach where Booktitle=@title";
                using(SqlCommand command=new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", booktitle.Text);
                    int i=command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Xóa thành công sách");
                        loadform();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại, kiểm tra lại ô nhập tên sách");
                    }
                }
            }
        }

        private void book_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ dòng được click
                DataGridViewRow selectedRow = book_dgv.Rows[e.RowIndex];
                booktitle.Text = selectedRow.Cells[1].Value.ToString();
                author.Text = selectedRow.Cells[2].Value.ToString();
                categories_cb.Text = selectedRow.Cells[3].Value.ToString();
                quantity.Text = selectedRow.Cells[4].Value.ToString();
                price_sell.Text = selectedRow.Cells[6].Value.ToString();
                price_im.Text = selectedRow.Cells[5].Value.ToString();
                store.Text = selectedRow.Cells[7].Value.ToString();
                NXB.Text = selectedRow.Cells[8].Value.ToString();

                id = Convert.ToInt32(selectedRow.Cells[0].Value);
            }
        }
        
        private void edit_Click(object sender, EventArgs e)
        {
            if(id!=0)
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    string query = "update NhapSach set Booktitle=@title,author=@author,categories=@cate,quantity=@quan,priceimport=@priceim,pricesell=@pricesell,store=@store,NXB=@nxb,dateimport=@date where IDimport=@id";
                    using (SqlCommand command = new SqlCommand(query, connection)) {

                        int quan = 0, priceim = 0, pricesell = 0;
                        int.TryParse(quantity.Text, out quan);
                        int.TryParse(price_im.Text, out priceim);
                        int.TryParse(price_sell.Text, out pricesell);
                        command.Parameters.AddWithValue("@title", booktitle.Text);
                        command.Parameters.AddWithValue("@author", author.Text);
                        command.Parameters.AddWithValue("@cate", categories_cb.Text);
                        command.Parameters.AddWithValue("@quan", quan);
                        command.Parameters.AddWithValue("@priceim", priceim);
                        command.Parameters.AddWithValue("@pricesell", pricesell);
                        command.Parameters.AddWithValue("@store", store.Text);
                        command.Parameters.AddWithValue("@nxb", NXB.Text);
                        command.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());
                        command.Parameters.AddWithValue("@id", id);
                        int i=command.ExecuteNonQuery();
                        if(i > 0)
                        {
                            id = 0;
                            MessageBox.Show("Sửa thông tin thành công");
                            loadform();
                        }
                        else
                        {
                            MessageBox.Show("Sửa thông tin thất bại");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn sách để sửa thông tin");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "insert into NhapSach(Booktitle,author,categories,quantity,priceimport,pricesell,store,NXB,dateimport) values(@title,@author,@cate,@quan,@priceim,@pricesell,@store,@nxb,@date)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    int quan = 0, priceim = 0, pricesell = 0;
                    int.TryParse(quantity.Text, out quan);
                    int.TryParse(price_im.Text, out priceim);
                    int.TryParse(price_sell.Text, out pricesell);
                    command.Parameters.AddWithValue("@title", booktitle.Text);
                    command.Parameters.AddWithValue("@author", author.Text);
                    command.Parameters.AddWithValue("@cate", categories_cb.Text);
                    command.Parameters.AddWithValue("@quan", quan);
                    command.Parameters.AddWithValue("@priceim", priceim);
                    command.Parameters.AddWithValue("@pricesell", pricesell);
                    command.Parameters.AddWithValue("@store", store.Text);
                    command.Parameters.AddWithValue("@nxb", NXB.Text);
                    command.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        id = 0;
                        MessageBox.Show("Thêm sách thành công");
                        loadform();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sách thất bại");
                    }
                }
            }
        }
    }
}
