using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class BookShop : Form
    {
        public BookShop()
        {
            InitializeComponent();
        }

        private void changeColor_Click(object sender, EventArgs e)
        {
            if (sender is Button hoveredButton)
            {
                book.BackColor = Color.FromArgb(255, 192, 128);
                user.BackColor = Color.FromArgb(255, 192, 128);
                Bills.BackColor = Color.FromArgb(255, 192, 128);
                logout.BackColor = Color.FromArgb(255, 192, 128);
                pictureBox2.BackColor = Color.FromArgb(255, 192, 128);
                pictureBox3.BackColor = Color.FromArgb(255, 192, 128);
                pictureBox4.BackColor = Color.FromArgb(255, 192, 128);
                pictureBox5.BackColor = Color.FromArgb(255, 192, 128);
                if (hoveredButton.Name == "book")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox2.BackColor= Color.Green;
                  

                }
                if (hoveredButton.Name == "user")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox3.BackColor = Color.Green;
                    txtUser user = new txtUser();
                    user.Show();
                }
                if (hoveredButton.Name == "dashboard")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox4.BackColor = Color.Green;
                }
                if (hoveredButton.Name == "logout")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox5.BackColor = Color.Green;
                }


            }
        }

        private void BookShop_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
