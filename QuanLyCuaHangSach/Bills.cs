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
    public partial class Bills : Form
    {
        public Bills()
        {
            InitializeComponent();
        }
        string con = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=QL_Cua_Hang_Sach;Persist Security Info=True;User ID=sa;Password=1234";
        List<BookItem> list = new List<BookItem>();
        int n = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int stock = 0;
        private void loadform()
        {
            bookbill_dgv.Rows.Clear();
            foreach (BookItem i in list)
            {
                bookbill_dgv.Rows.Add(i.STT, i.Product, i.price, i.quantity,i.saleoff, i.total);
            }
            book_dgv.Rows.Clear();
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "select * from NhapSach";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book_dgv.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(6));
                        }
                    }
                }
            }
            int total_bill = 0;
            foreach (BookItem b in list)
            {
                total_bill += b.total;
            }
            label9.Text = total_bill.ToString();
        }
        private void Bills_Load(object sender, EventArgs e)
        {
            loadform();
        }

        private void reset_bill_Click(object sender, EventArgs e)
        {
            bookname.Text = "";
            quantity_bill.Text = "";
            saleoff_bill.Text = "";
            clientname_bill.Text = "";
            price_bill.Text = "";
        }

        private void book_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ dòng được click
                DataGridViewRow selectedRow = book_dgv.Rows[e.RowIndex];
                bookname.Text = selectedRow.Cells["btitle"].Value.ToString();
                price_bill.Text = selectedRow.Cells["price_sell"].Value.ToString();
                stock = Convert.ToInt32(selectedRow.Cells["quantity_store"].Value);
                
            }
        }
        
        private void addtobill_Click(object sender, EventArgs e)
        {
            if (stock == 0)
            {
                MessageBox.Show("Hãy chọn sách để cho vào giỏ");
            }
            else
            {
                int soluong = 0;
                int.TryParse(quantity_bill.Text, out soluong);
                int conlai = stock - soluong;
                if(soluong == 0||soluong >stock) {
                    MessageBox.Show("Số lượng không cho phép");
                }
                else
                {
                    int gia = 0,saleoff=0;
                    int.TryParse(price_bill.Text, out gia);
                    int.TryParse(saleoff_bill.Text, out saleoff);
                    int total=(int)(soluong*gia*(1-(float)saleoff/100));
                    
                    

                    BookItem a=new BookItem(n+1,bookname.Text,gia,soluong,saleoff,total);
                    list.Add(a);
                    n++;
                    
                    using(SqlConnection connection=new SqlConnection(con))
                    {
                        connection.Open();
                        string query = "update NhapSach set quantity=@quan where Booktitle=@title";
                        using(SqlCommand command=new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@quan", conlai);
                            command.Parameters.AddWithValue("@title",bookname.Text);
                            int i=command.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Thêm thành công sản phẩm vào giỏ hàng");
                                loadform();
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại");
                            }
                        }
                        
                    }
                    loadform();
                }
            }
        }

        private void bookbill_dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow deletedRow = e.Row;
            int quan1 = Convert.ToInt32(deletedRow.Cells["quantity"].Value);
            string title = deletedRow.Cells["book"].Value.ToString();
            int quan2 = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "select quantity from NhapSach where Booktitle=@title";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            quan2=reader.GetInt32(0);
                        }
                    }
                    
                }
            }
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].Product == title)
                {
                    list.RemoveAt(i);
                }
            }
            using (SqlConnection connection=new SqlConnection(con))
            {
                connection.Open();
                string query = "update NhapSach set quantity=@quan where Booktitle=@title";
                using(SqlCommand command=new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@quan", quan1+quan2);
                    command.Parameters.AddWithValue("@title", deletedRow.Cells["book"].Value.ToString());
                    int i=command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Đã xóa sản phẩm khỏi giỏ hàng");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại sản phẩm khỏi giỏ hàng");
                    }
                }
            }
            loadform();
        }

        private void print_bill_Click(object sender, EventArgs e)
        {
            if (clientname_bill.Text == "" || list == null)
            {
                MessageBox.Show("Hãy nhập thông tin khách hàng và giỏ hàng");
            }
            else
            {
                int chiso = 0;
                using(SqlConnection connection=new SqlConnection(con))
                {
                    connection.Open();
                    string query = "select top 1 IDbills from Bills order by IDbills desc";
                    using(SqlCommand command=new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                chiso=reader.GetInt32(0);
                            }
                        }
                    }
                }
                foreach(BookItem bi in list)
                {
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();
                        string query = "insert into Bills(IDbills,bookname,quantity,clientname,price,date_sell,sale_off) values(@id,@bookname,@quan,@client,@price,@date,@saleoff)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", chiso + 1);
                            command.Parameters.AddWithValue("@bookname", bi.Product);
                            command.Parameters.AddWithValue("@quan", bi.quantity);
                            command.Parameters.AddWithValue("@client", clientname_bill.Text);
                            command.Parameters.AddWithValue("@price", bi.price);
                            command.Parameters.AddWithValue("@date",datepicker_bill.Text);
                            command.Parameters.AddWithValue("@saleoff", bi.saleoff);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                PrintPreviewDialog printDialog1 = new PrintPreviewDialog();
                printDialog1.Document = printDocument1; 
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 600, 285);
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }
        int pos = 80;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("BookShop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("Contact shop: 0365079956", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(26, 20));
            e.Graphics.DrawString("Client Name" +clientname_bill.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            e.Graphics.DrawString("STT", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 60));
            e.Graphics.DrawString("BOOK", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(45, 60));
            e.Graphics.DrawString("PRICE", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(330, 60));
            e.Graphics.DrawString("QUANTITY", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(400, 60));
            e.Graphics.DrawString("SALE OFF", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(480, 60));
            e.Graphics.DrawString("TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(540, 60));
            foreach(BookItem boo in list)
            {
                e.Graphics.DrawString(""+boo.STT, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + boo.Product, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + boo.price, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(330, pos));
                e.Graphics.DrawString("" + boo.quantity, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(365, pos));
                e.Graphics.DrawString("" + boo.saleoff, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(450, pos));
                e.Graphics.DrawString("" + boo.total, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(560, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Grand Total: " +label9.Text, new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(60, pos+50));
            e.Graphics.DrawString("Time" +datepicker_bill.Text, new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(40, pos+85));
            e.Graphics.DrawString("********BookStore*********", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(40, pos+120));
            bookbill_dgv.Rows.Clear();
            bookbill_dgv.Refresh();
            pos = 150;
        }
    }
}
