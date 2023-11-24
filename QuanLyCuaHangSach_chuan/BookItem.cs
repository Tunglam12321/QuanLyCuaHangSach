using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach
{
    internal class BookItem
    {
        public int STT { get; set; }
        public string Product { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int saleoff { get; set; }
        public int total { get; set; }

        public BookItem() { }
        public BookItem(int STT,string product,int price,int quantity,int saleoff,int total)
        {
            this.STT = STT;
            this.Product = product;
            this.price= price;
            this.quantity = quantity;
            this.saleoff = saleoff;
            this.total = total;
        }
    }
}
