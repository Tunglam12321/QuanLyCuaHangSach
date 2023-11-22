using System;
using System.Collections;
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
    public partial class Book : Form
    {
        string conn = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=QL_Cua_Hang_Sach;User ID=sa;Password=1234";

        public Book()
        {
            InitializeComponent();
        }
        private void loadform()
        {
            book_dgv.Rows.Clear();
            //Gán giá trị cho thể loại sách
            List<String> dataLisst = new List<string>
            {
                "Chính trị-Pháp luật",
                "Khoa học công nghệ",
                "Kinh tế",
                "Văn học nghệ thuật",
                "Văn hóa -Lịch sử",
                "Giáo trình",
                "Truyện, tiểu thuyết",
                "Tâm lý, tâm linh, tôn giáo",
                "Sách thiếu nhi"
            };
            categories_cb.DataSource = dataLisst;

            //Hiển thị booklist
            List<String> dataLisst1 = new List<string>
            {
                "Chính trị-Pháp luật",
                "Khoa học công nghệ",
                "Kinh tế",
                "Văn học nghệ thuật",
                "Văn hóa -Lịch sử",
                "Giáo trình",
                "Truyện, tiểu thuyết",
                "Tâm lý, tâm linh, tôn giáo",
                "Sách thiếu nhi"
            };
            booklist_cb.DataSource = dataLisst1;
            //Hiển thị các sách đã nhập
            string query = "select * from NhapSach";
            book_dgv.Columns.Add("Column1", "ID");
            book_dgv.Columns.Add("Column2", "BTitle");
            book_dgv.Columns.Add("Column3", "BAuthor");
            book_dgv.Columns.Add("Column4", "BCategories");
            book_dgv.Columns.Add("Column5", "Store");
            book_dgv.Columns.Add("Column6", "NXB");
            book_dgv.Columns.Add("Column7", "Quantity");
            book_dgv.Columns.Add("Column8", "PriceImport");
            book_dgv.Columns.Add("Column9", "PriceSell");
            book_dgv.Columns.Add("Column10", "Date");
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string title = reader.GetString(1);
                                string author = reader.GetString(2);
                                string category = reader.GetString(3);
                                int quan = reader.GetInt32(4);
                                int priceimport = reader.GetInt32(5);
                                int pricesell = reader.GetInt32(6);
                                string store = reader.GetString(7);
                                string nxb = reader.GetString(8);
                                string date = reader.GetString(9);
                                book_dgv.Rows.Add(id.ToString(), title, author, category, store, nxb, quan.ToString(), priceimport.ToString(), pricesell.ToString(), date);
                            }
                        
                    }
                }


                connection.Close();

            }
        }
        private void Book_Load(object sender, EventArgs e)
        {
            loadform();
        }
        //Lưu sách nhập
        private void save_Click(object sender, EventArgs e)
        {
            string query = "insert into NhapSach(Booktitle,author,categories,quantity,priceimport,pricesell,store,NXB,dateimport) values(@title,@author,@cate,@quan,@priceim,@pricesell,@store,@NXB,@date)";
            using(SqlConnection connection=new SqlConnection(conn))
            {
                connection.Open();
                using(SqlCommand command=new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@title", booktitle.Text);
                    command.Parameters.AddWithValue("@author", author.Text);
                    command.Parameters.AddWithValue("@cate", categories_cb.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@quan", int.Parse(quantity.Text));
                    command.Parameters.AddWithValue("@priceim", int.Parse(price_im.Text));
                    command.Parameters.AddWithValue("@pricesell", int.Parse(price_sell.Text));
                    command.Parameters.AddWithValue("@store", store.Text);
                    command.Parameters.AddWithValue("@NXB", NXB.Text);
                    command.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());
                    int a=command.ExecuteNonQuery();
                    if(a > 0)
                    {
                        MessageBox.Show("Đã thêm thành công");
                        loadform();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
        }


        private void book_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if(row >= 0)
            {
                if(book_dgv.Rows[row].Cells[1].Value!=null) {
                    booktitle.Text = book_dgv.Rows[row].Cells[1].Value.ToString();
                    author.Text = book_dgv.Rows[row].Cells[2].Value.ToString();
                    categories_cb.Text = book_dgv.Rows[row].Cells[3].Value.ToString();
                    store.Text = book_dgv.Rows[row].Cells[4].Value.ToString();
                    NXB.Text = book_dgv.Rows[row].Cells[5].Value.ToString();
                    quantity.Text = book_dgv.Rows[row].Cells[6].Value.ToString();
                    price_im.Text = book_dgv.Rows[row].Cells[7].Value.ToString();
                    price_sell.Text = book_dgv.Rows[row].Cells[8].Value.ToString();
                    id_lb.Text = book_dgv.Rows[row].Cells[0].Value.ToString();
                }              
                else{
                    MessageBox.Show("Hãy chọn thông tin sách trong bảng");
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            string query = "update NhapSach set Booktitle=@title,author=@author,categories=@cate,quantity=@quan,priceimport=@priceim,pricesell=@pricesell,store=@store,NXB=@NXB,dateimport=@date where IDimport=@id";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int id = 0;
                    int.TryParse(id_lb.Text, out id);
                    if (id>0) {
                        int quan = 0,priceim=0,pricesell=0;
                        int.TryParse(quantity.Text,out quan);
                        int.TryParse(price_im.Text, out priceim);
                        int.TryParse(price_sell.Text, out pricesell);
                        command.Parameters.AddWithValue("@title", booktitle.Text);
                        command.Parameters.AddWithValue("@author", author.Text);
                        command.Parameters.AddWithValue("@cate", categories_cb.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@quan", quan);
                        command.Parameters.AddWithValue("@priceim", priceim);
                        command.Parameters.AddWithValue("@pricesell", pricesell);
                        command.Parameters.AddWithValue("@store", store.Text);
                        command.Parameters.AddWithValue("@NXB", NXB.Text);
                        command.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());
                        command.Parameters.AddWithValue("@id", int.Parse(id_lb.Text));
                        int a = command.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Đã sửa thành công");
                            loadform();
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn thông tin cần sửa");

                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string query = "delete from NhapSach where IDimport=@id";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int id = 0;
                    int.TryParse(id_lb.Text, out id);
                    if (id > 0)
                    {                  
                        command.Parameters.AddWithValue("@id", int.Parse(id_lb.Text));
                        int a = command.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Đã xóa thành công");
                            loadform();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn thông tin cần xóa");

                    }
                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            booktitle.Text = "";
            author.Text = "";
            categories_cb.Text = "";
            quantity.Text = "";
            price_im.Text = "";
            price_sell.Text = "";
            store.Text = "";
            NXB.Text = "";
            id_lb.Text = "";
        }

        private void booklist_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            book_dgv.Columns.Add("Column1", "ID");
            book_dgv.Columns.Add("Column2", "BTitle");
            book_dgv.Columns.Add("Column3", "BAuthor");
            book_dgv.Columns.Add("Column4", "BCategories");
            book_dgv.Columns.Add("Column5", "Store");
            book_dgv.Columns.Add("Column6", "NXB");
            book_dgv.Columns.Add("Column7", "Quantity");
            book_dgv.Columns.Add("Column8", "PriceImport");
            book_dgv.Columns.Add("Column9", "PriceSell");
            book_dgv.Columns.Add("Column10", "Date");
            book_dgv.Rows.Clear();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string query = "select * from NhapSach where categories=@cate";             
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cate", booklist_cb.SelectedItem.ToString());
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string title = reader.GetString(1);
                                string author = reader.GetString(2);
                                string category = reader.GetString(3);
                                int quan = reader.GetInt32(4);
                                int priceimport = reader.GetInt32(5);
                                int pricesell = reader.GetInt32(6);
                                string store = reader.GetString(7);
                                string nxb = reader.GetString(8);
                                string date = reader.GetString(9);
                                book_dgv.Rows.Add(id.ToString(), title, author, category, store, nxb, quan.ToString(), priceimport.ToString(), pricesell.ToString(), date);
                            }
                    }
                }



                connection.Close();

            }
        }

        private void refesh_Click(object sender, EventArgs e)
        {
            loadform();
        }





    }
}
