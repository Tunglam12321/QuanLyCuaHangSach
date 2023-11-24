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
        private Form currentChildForm;
        private void OpenChildForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.AutoSize = true;
            childForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.Parent = panel2;
            childForm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void changeColor_Click(object sender, EventArgs e)
        {
            if (sender is Button hoveredButton)
            {
                book.BackColor = Color.FromArgb(255, 192, 128);
                user.BackColor = Color.FromArgb(255, 192, 128);
                bills.BackColor = Color.FromArgb(255, 192, 128);
                search.BackColor = Color.FromArgb(255, 192, 128);
                dashboard.BackColor = Color.FromArgb(255, 192, 128);
                logout.BackColor = Color.FromArgb(255, 192, 128);

                pictureBox2.BackColor = Color.FromArgb(255, 192, 128);
                pictureBox3.BackColor = Color.FromArgb(255, 192, 128);
                pictureBox4.BackColor = Color.FromArgb(255, 192, 128);
                pictureBox5.BackColor = Color.FromArgb(255, 192, 128);
                pictureBox6.BackColor = Color.FromArgb(255, 192, 128);
                pictureBox7.BackColor = Color.FromArgb(255, 192, 128);
                if (hoveredButton.Name == "book")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox2.BackColor= Color.Green;

                }
                if (hoveredButton.Name == "user")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox3.BackColor = Color.Green;
                }
                if (hoveredButton.Name == "dashboard")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox6.BackColor = Color.Green;
                }
                if (hoveredButton.Name == "bills")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox4.BackColor = Color.Green;
                }
                if (hoveredButton.Name == "search")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox5.BackColor = Color.Green;
                }
                if (hoveredButton.Name == "logout")
                {
                    hoveredButton.BackColor = Color.Green;
                    pictureBox7.BackColor = Color.Green;
                }


            }
        }
        private void book_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is Form form)
                {
                    form.Close();
                }
            }
            OpenChildForm(new Book());
        }
        private void bill_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is Form form)
                {
                    form.Close();
                }
            }
            OpenChildForm(new Bills());
        }
        private void search_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is Form form)
                {
                    form.Close();
                }
            }
            OpenChildForm(new Timkiem());
        }
        private void dashboard_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is Form form)
                {
                    form.Close();
                }
            }
            OpenChildForm(new Dashboard());
        }
        private void user_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is Form form)
                {
                    form.Close();
                }
            }
            OpenChildForm(new txtUser());
        }
        private void logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BookShop_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
