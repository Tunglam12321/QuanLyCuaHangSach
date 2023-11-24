using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        string con = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=QL_Cua_Hang_Sach;Persist Security Info=True;User ID=sa;Password=1234";
        Revenue_month a = new Revenue_month();
        List<Revenue_cate> list_cate = new List<Revenue_cate>();
        private void Dashboard_Load(object sender, EventArgs e)
        {
            label4.Text = "";
            label7.Text = "";
            label8.Text = "";
            dataGridView1.Rows.Clear();
        }
        private void Hienthi()
        {
            if (label4.Text != "")
            {
                using(SqlConnection connection=new SqlConnection(con))
                {
                    connection.Open();
                    string query = "select * from Dashboard_month where month=@month";
                    using(SqlCommand command=new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@month", label4.Text);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                label7.Text = reader.GetInt32(1).ToString();
                                label8.Text = reader.GetInt32(2).ToString();
                            }
                        }
                    }
                }
                dataGridView1.Rows.Clear();
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    string query = "select * from Dashboard_category where month=@month";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@month", label4.Text);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                            }
                        }
                    }
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string timeSelect = dateTimePicker1.Value.ToString();
            string month = timeSelect.Split(' ')[0].Split('/')[0];
            string year = timeSelect.Split(' ')[0].Split('/')[2];
            label4.Text = month+"/"+year;
        }

        private void db_Click(object sender, EventArgs e)
        {
            if (label4.Text == "")
            {
                MessageBox.Show("Chọn thời gian để thống kê");
            }
            else
            {
                a.month = label4.Text;
                using(SqlConnection connection=new SqlConnection(con))
                {
                    connection.Open();
                    string query = "select NhapSach.Booktitle,NhapSach.categories,NhapSach.priceimport,NhapSach.pricesell,Bills.quantity,Bills.date_sell,Bills.sale_off from NhapSach,Bills where NhapSach.Booktitle=Bills.bookname";
                    using(SqlCommand command=new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string timeBill = reader.GetString(5);
                                string monthBill = timeBill.Split(' ')[0].Split('/')[0];
                                string yearBill = timeBill.Split(' ')[0].Split('/')[2];
                                if (monthBill + "/" + yearBill == label4.Text)
                                {
                                    int price_sell = reader.GetInt32(3);
                                    int price_im = reader.GetInt32(2);
                                    int quan = reader.GetInt32(4);
                                    string categoryy = reader.GetString(1);
                                    int sale_off = reader.GetInt32(6);
                                    int revenue = (int)(quan * price_sell * (1 - (float)sale_off / 100));
                                    int profit = revenue - quan * price_im;
                                    a.revenue += revenue;
                                    a.profit += profit;
                                    int check = 0;
                                    foreach(Revenue_cate a in list_cate)
                                    {
                                        if (a.month == label4.Text && a.category == categoryy)
                                        {
                                            a.revenue += revenue;
                                            a.profit += profit;
                                            check++;
                                        }
                                    }
                                    if (check == 0)
                                    {
                                        Revenue_cate newitem = new Revenue_cate(label4.Text, categoryy, revenue, profit);
                                        list_cate.Add(newitem);
                                    }
                                }
                            }
                        }
                    }
                }
                using(SqlConnection connection1=new SqlConnection(con))
                {
                    connection1.Open();
                    string query1 = "update Dashboard_month set total_revenue=@revenue,profit=@profit where month=@month";
                    string query2 = "insert into Dashboard_month(month,total_revenue,profit) values(@month,@revenue,@profit)";
                    string query3 = "update Dashboard_category set total_revenue=@revenue,profit=@profit where month=@month and category=@cate";
                    string query4 = "insert into Dashboard_category(month,category,total_revenue,profit) values(@month,@cate,@total_revenue,@profit)";
                    int check1 = 0;
                    using(SqlCommand command1=new SqlCommand(query1, connection1))
                    {
                        command1.Parameters.AddWithValue("@month", a.month);
                        command1.Parameters.AddWithValue("@revenue", a.revenue);
                        command1.Parameters.AddWithValue("@profit", a.profit);
                        int i = command1.ExecuteNonQuery();
                        if (i > 0)
                        {
                            check1 = 1;
                        }
                    }
                    if (check1 == 0)
                    {
                        using (SqlCommand command1 = new SqlCommand(query2, connection1))
                        {
                            command1.Parameters.AddWithValue("@month", a.month);
                            command1.Parameters.AddWithValue("@revenue", a.revenue);
                            command1.Parameters.AddWithValue("@profit", a.profit);
                            int i = command1.ExecuteNonQuery();
                           
                        }
                    }
                    foreach(Revenue_cate ca in list_cate)
                    {
                        int check2 = 0;
                        using (SqlCommand command1 = new SqlCommand(query3, connection1))
                        {
                            command1.Parameters.AddWithValue("@month", ca.month);
                            command1.Parameters.AddWithValue("@revenue", ca.revenue);
                            command1.Parameters.AddWithValue("@profit", ca.profit);
                            command1.Parameters.AddWithValue("@cate", ca.category);
                            int i = command1.ExecuteNonQuery();
                            if (i > 0)
                            {
                                check2 = 1;
                            }
                        }
                        if (check2 == 0)
                        {
                            using (SqlCommand command1 = new SqlCommand(query4, connection1))
                            {
                                command1.Parameters.AddWithValue("@month", ca.month);
                                command1.Parameters.AddWithValue("@revenue", ca.revenue);
                                command1.Parameters.AddWithValue("@profit", ca.profit);
                                command1.Parameters.AddWithValue("@cate", ca.category);
                                int i = command1.ExecuteNonQuery();
                                
                            }
                        }
                    }
                    
                }
                Hienthi();
            }
        }
    }
}
