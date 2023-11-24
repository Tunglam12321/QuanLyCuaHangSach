namespace QuanLyCuaHangSach
{
    partial class Bills
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.book_dgv = new System.Windows.Forms.DataGridView();
            this.IDbook = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity_store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_sell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print_bill = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.reset_bill = new System.Windows.Forms.Button();
            this.addtobill = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.datepicker_bill = new System.Windows.Forms.DateTimePicker();
            this.clientname_bill = new System.Windows.Forms.TextBox();
            this.price_bill = new System.Windows.Forms.TextBox();
            this.quantity_bill = new System.Windows.Forms.TextBox();
            this.bookname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saleoff_bill = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.book_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // book_dgv
            // 
            this.book_dgv.BackgroundColor = System.Drawing.Color.White;
            this.book_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.book_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.book_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.book_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDbook,
            this.btitle,
            this.author,
            this.category,
            this.quantity_store,
            this.price_sell});
            this.book_dgv.GridColor = System.Drawing.SystemColors.Control;
            this.book_dgv.Location = new System.Drawing.Point(12, 350);
            this.book_dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.book_dgv.Name = "book_dgv";
            this.book_dgv.RowHeadersWidth = 51;
            this.book_dgv.Size = new System.Drawing.Size(543, 282);
            this.book_dgv.TabIndex = 45;
            // 
            // IDbook
            // 
            this.IDbook.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDbook.HeaderText = "IDbook";
            this.IDbook.MinimumWidth = 6;
            this.IDbook.Name = "IDbook";
            // 
            // btitle
            // 
            this.btitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.btitle.HeaderText = "BTitle";
            this.btitle.MinimumWidth = 6;
            this.btitle.Name = "btitle";
            // 
            // author
            // 
            this.author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.author.HeaderText = "Bauthor";
            this.author.MinimumWidth = 6;
            this.author.Name = "author";
            // 
            // category
            // 
            this.category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.category.HeaderText = "Category";
            this.category.MinimumWidth = 6;
            this.category.Name = "category";
            // 
            // quantity_store
            // 
            this.quantity_store.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantity_store.HeaderText = "Quantity";
            this.quantity_store.MinimumWidth = 6;
            this.quantity_store.Name = "quantity_store";
            // 
            // price_sell
            // 
            this.price_sell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.price_sell.HeaderText = "Price";
            this.price_sell.MinimumWidth = 6;
            this.price_sell.Name = "price_sell";
            // 
            // print_bill
            // 
            this.print_bill.AutoSize = true;
            this.print_bill.BackColor = System.Drawing.Color.Lime;
            this.print_bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print_bill.ForeColor = System.Drawing.Color.White;
            this.print_bill.Location = new System.Drawing.Point(728, 532);
            this.print_bill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.print_bill.Name = "print_bill";
            this.print_bill.Size = new System.Drawing.Size(100, 33);
            this.print_bill.TabIndex = 44;
            this.print_bill.Text = "Print";
            this.print_bill.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(741, 484);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 29);
            this.label9.TabIndex = 42;
            this.label9.Text = "Total";
            // 
            // reset_bill
            // 
            this.reset_bill.AutoSize = true;
            this.reset_bill.BackColor = System.Drawing.Color.Lime;
            this.reset_bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_bill.ForeColor = System.Drawing.Color.White;
            this.reset_bill.Location = new System.Drawing.Point(183, 281);
            this.reset_bill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reset_bill.Name = "reset_bill";
            this.reset_bill.Size = new System.Drawing.Size(100, 33);
            this.reset_bill.TabIndex = 39;
            this.reset_bill.Text = "Reset";
            this.reset_bill.UseVisualStyleBackColor = false;
            // 
            // addtobill
            // 
            this.addtobill.AutoSize = true;
            this.addtobill.BackColor = System.Drawing.Color.Lime;
            this.addtobill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.addtobill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addtobill.ForeColor = System.Drawing.Color.White;
            this.addtobill.Location = new System.Drawing.Point(45, 281);
            this.addtobill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addtobill.Name = "addtobill";
            this.addtobill.Size = new System.Drawing.Size(121, 33);
            this.addtobill.TabIndex = 38;
            this.addtobill.Text = "Add to bill";
            this.addtobill.UseVisualStyleBackColor = false;
            this.addtobill.Click += new System.EventHandler(this.addtobill_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(831, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 29);
            this.label8.TabIndex = 36;
            this.label8.Text = "BookBill";
            // 
            // datepicker_bill
            // 
            this.datepicker_bill.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datepicker_bill.Location = new System.Drawing.Point(369, 235);
            this.datepicker_bill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.datepicker_bill.Name = "datepicker_bill";
            this.datepicker_bill.Size = new System.Drawing.Size(107, 22);
            this.datepicker_bill.TabIndex = 34;
            // 
            // clientname_bill
            // 
            this.clientname_bill.Location = new System.Drawing.Point(12, 235);
            this.clientname_bill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clientname_bill.Name = "clientname_bill";
            this.clientname_bill.Size = new System.Drawing.Size(132, 22);
            this.clientname_bill.TabIndex = 33;
            // 
            // price_bill
            // 
            this.price_bill.Location = new System.Drawing.Point(191, 235);
            this.price_bill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.price_bill.Name = "price_bill";
            this.price_bill.Size = new System.Drawing.Size(132, 22);
            this.price_bill.TabIndex = 32;
            // 
            // quantity_bill
            // 
            this.quantity_bill.Location = new System.Drawing.Point(191, 122);
            this.quantity_bill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quantity_bill.Name = "quantity_bill";
            this.quantity_bill.Size = new System.Drawing.Size(132, 22);
            this.quantity_bill.TabIndex = 31;
            // 
            // bookname
            // 
            this.bookname.Location = new System.Drawing.Point(12, 122);
            this.bookname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bookname.Name = "bookname";
            this.bookname.Size = new System.Drawing.Size(132, 22);
            this.bookname.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(364, 178);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 29);
            this.label7.TabIndex = 29;
            this.label7.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(185, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 29);
            this.label6.TabIndex = 28;
            this.label6.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 178);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 29);
            this.label5.TabIndex = 27;
            this.label5.Text = "Client Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 29);
            this.label3.TabIndex = 25;
            this.label3.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 29);
            this.label2.TabIndex = 24;
            this.label2.Text = "Book Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(489, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 39);
            this.label1.TabIndex = 23;
            this.label1.Text = "BILLS";
            // 
            // saleoff_bill
            // 
            this.saleoff_bill.Location = new System.Drawing.Point(369, 122);
            this.saleoff_bill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saleoff_bill.Name = "saleoff_bill";
            this.saleoff_bill.Size = new System.Drawing.Size(132, 22);
            this.saleoff_bill.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(364, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 29);
            this.label4.TabIndex = 46;
            this.label4.Text = "Sale Off";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.book,
            this.price,
            this.quantity,
            this.total});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView1.Location = new System.Drawing.Point(563, 122);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(545, 282);
            this.dataGridView1.TabIndex = 48;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            // 
            // book
            // 
            this.book.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.book.HeaderText = "Book";
            this.book.MinimumWidth = 6;
            this.book.Name = "book";
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantity.HeaderText = "Quantity";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            // 
            // Bills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 635);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.saleoff_bill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.book_dgv);
            this.Controls.Add(this.print_bill);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.reset_bill);
            this.Controls.Add(this.addtobill);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.datepicker_bill);
            this.Controls.Add(this.clientname_bill);
            this.Controls.Add(this.price_bill);
            this.Controls.Add(this.quantity_bill);
            this.Controls.Add(this.bookname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Bills";
            this.Text = "Bills";
            ((System.ComponentModel.ISupportInitialize)(this.book_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView book_dgv;
        private System.Windows.Forms.Button print_bill;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button reset_bill;
        private System.Windows.Forms.Button addtobill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datepicker_bill;
        private System.Windows.Forms.TextBox clientname_bill;
        private System.Windows.Forms.TextBox price_bill;
        private System.Windows.Forms.TextBox quantity_bill;
        private System.Windows.Forms.TextBox bookname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox saleoff_bill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn book;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDbook;
        private System.Windows.Forms.DataGridViewTextBoxColumn btitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity_store;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_sell;
    }
}