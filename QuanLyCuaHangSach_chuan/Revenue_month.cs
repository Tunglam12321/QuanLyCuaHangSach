using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach
{
    internal class Revenue_month
    {
        public string month { get; set; }
        public int revenue { get; set; }
        public int profit { get; set; }

        public Revenue_month() { }
        public Revenue_month(string month, int revenue, int profit)
        {
            this.month = month;
            this.revenue = revenue;
            this.profit = profit;
        }
    }
}
