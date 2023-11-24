using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach
{
    internal class Revenue_cate
    {
        public string month  { get; set; }
        public string category { get; set; }
        public int revenue { get; set; }
        public int profit { get; set; }
        

        public Revenue_cate() {
            month = "";
            category = "";
            revenue = 0;
            profit = 0;
        }
        public Revenue_cate(string month, string category, int revenue, int profit)
        {
            this.month = month;
            this.category = category;
            this.revenue = revenue;
            this.profit = profit;

        }
    }
}
