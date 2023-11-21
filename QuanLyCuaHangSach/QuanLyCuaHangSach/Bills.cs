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
    public partial class Bills : Form
    {
        SqlConnection Con=new SqlConnection(@"Data Source=MSI\\SQLEXPRESS;Initial Catalog=QL_Cua_Hang_Sach;User ID=sa;Password=1234");
        string conn = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=QL_Cua_Hang_Sach;User ID=sa;Password=1234";
        public Bills()
        {
            InitializeComponent();
        }
        List<string> list = new List<string>();
        List<int> totallist = new List<int>();
        List<BookItem> bookitems = new List<BookItem>();
        private void loadform()
        {
            book_dgv.Rows.Clear();
            //Hiển thị các sách đã nhập
            string query = "select * from NhapSach";
            int total = 0;
            foreach(int a in totallist)
            {
                total += a;
            }
            label9.Text = total.ToString();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(1));
                            int id = reader.GetInt32(0);
                            string title = reader.GetString(1);
                            string author = reader.GetString(2);
                            string category = reader.GetString(3);
                            int quan = reader.GetInt32(4);              
                            int pricesell = reader.GetInt32(6);
                            string store = reader.GetString(7);
                            book_dgv.Rows.Add(id.ToString(), title, author, category, quan.ToString(), pricesell.ToString());
                        }

                    }
                }


                connection.Close();

            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Bills_Load(object sender, EventArgs e)
        {
            loadform();
        }
        int stock = 0;
        private void UpdateBook()
        {
            

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                int quan = 0;
                int.TryParse(quantity_bill.Text, out quan);
                int newquan = (int)(stock - quan);
                string query = "update NhapSach set quantity=@newquan where Booktitle=@booktitle";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newquan", newquan);
                    command.Parameters.AddWithValue("@booktitle", bookname.Text);
                    int result= command.ExecuteNonQuery();
                    if(result > 0)
                    {
                        MessageBox.Show("Thêm sách thành công vào đơn hàng");
                        loadform();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sách thất bại vào đơn hàng");
                    }
                }
                connection.Close();
            }
        }

        int n = 0;
        private void addtobill_Click(object sender, EventArgs e)
        {
            int soluong = 0;

            int.TryParse(quantity_bill.Text, out soluong);
            if (!list.Contains(bookname.Text))
            {
                MessageBox.Show("Hãy nhập đúng tên sách");
            }
            else
            {
                if(soluong<=0 || soluong > stock)
                {
                    MessageBox.Show("Hãy nhập số lượng cho phép");
                }
                else
                {
                    if (price_bill.Text == "")
                    {
                        MessageBox.Show("Hãy nhập giá sản phẩm");
                    }
                    else
                    {
                        int saleoff = 0;
                        int.TryParse(saleoff_bill.Text, out saleoff);
                        string title = bookname.Text;
                        int gia = 0;
                        int.TryParse(price_bill.Text, out gia);
                        float total = (float)soluong * gia*(1-(float)saleoff/100);
                        bookbill_dgv.Rows.Add(n+1,title,gia,soluong,saleoff,total);
                        n++;
                        totallist.Add((int)total);
                        UpdateBook();
                        BookItem a=new BookItem(n+1,title,gia,soluong,saleoff,(int)total);
                        bookitems.Add(a);

                    }
                }
            }
        }

        private void reset_bill_Click(object sender, EventArgs e)
        {
            bookname.Text = "";
            clientname_bill.Text = "";
            quantity_bill.Text = "";
            price_bill.Text = "";
            saleoff_bill.Text = "";
        }

        private void book_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if(row>=0)
            {
                bookname.Text = book_dgv.Rows[row].Cells[1].Value.ToString();
                price_bill.Text = book_dgv.Rows[row].Cells[5].Value.ToString();
                stock = int.Parse(book_dgv.Rows[row].Cells[4].Value.ToString());
            }
            
        }

        private void bookbill_dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                int quan = 0;
                int row = bookbill_dgv.SelectedRows.Count;
                string title = "";
                int gia_item = 0;
                if (row>0 )
                {
                    DataGridViewRow dataGridViewRow = bookbill_dgv.SelectedRows[0];
                    string quanstr = dataGridViewRow.Cells["quantity"].Value.ToString();
                    int.TryParse(quanstr, out quan);
                    title = dataGridViewRow.Cells["book"].Value.ToString();
                    int.TryParse(dataGridViewRow.Cells["total"].Value.ToString(),out gia_item);
                    totallist.Remove(gia_item);
                }
                int number = 0;
                string query = "select quantity from NhapSach where Booktitle=@booktitle";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@booktitle", title);
                    using(SqlDataReader reader=command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                number = reader.GetInt32(0);
                                break;
                            }
                        }
                    }
                }
                string query1 = "update NhapSach set quantity=@newquan where Booktitle=@booktitle";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                   
                    using (SqlCommand cmd = new SqlCommand(query1,connection))
                    {
                        command.Parameters.AddWithValue("@newquan", number + quan);
                        command.Parameters.AddWithValue("@booktitle", title);
                        int resut=command.ExecuteNonQuery();
                        if (resut > 0)
                        {
                            MessageBox.Show("Đã bỏ sản phẩm ra khỏi giỏ");
                            
                            loadform();
                        }
                        else
                        {
                            MessageBox.Show("Xin hãy chọn sản phẩm để bỏ khỏi giỏ hàng");
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
