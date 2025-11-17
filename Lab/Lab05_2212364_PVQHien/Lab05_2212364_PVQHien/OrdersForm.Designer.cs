namespace Lab05_2212364_PVQHien
{
	partial class OrdersForm
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.btnSearch = new System.Windows.Forms.Button();
			this.dgvOrders = new System.Windows.Forms.DataGridView();
			this.lblTotalAmount = new System.Windows.Forms.Label();
			this.lblTotalDiscount = new System.Windows.Forms.Label();
			this.lblTotalTax = new System.Windows.Forms.Label();
			this.lblRevenue = new System.Windows.Forms.Label();
			this.lblOrderCount = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Từ ngày:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(280, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Đến ngày:";
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpStartDate.Location = new System.Drawing.Point(67, 12);
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
			this.dtpStartDate.TabIndex = 2;
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpEndDate.Location = new System.Drawing.Point(342, 12);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
			this.dtpEndDate.TabIndex = 3;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(560, 10);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(100, 23);
			this.btnSearch.TabIndex = 4;
			this.btnSearch.Text = "Tìm kiếm";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// dgvOrders
			// 
			this.dgvOrders.AllowUserToAddRows = false;
			this.dgvOrders.AllowUserToDeleteRows = false;
			this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvOrders.Location = new System.Drawing.Point(12, 45);
			this.dgvOrders.MultiSelect = false;
			this.dgvOrders.Name = "dgvOrders";
			this.dgvOrders.ReadOnly = true;
			this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvOrders.Size = new System.Drawing.Size(960, 400);
			this.dgvOrders.TabIndex = 5;
			this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
			// 
			// lblTotalAmount
			// 
			this.lblTotalAmount.AutoSize = true;
			this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalAmount.Location = new System.Drawing.Point(12, 460);
			this.lblTotalAmount.Name = "lblTotalAmount";
			this.lblTotalAmount.Size = new System.Drawing.Size(120, 15);
			this.lblTotalAmount.TabIndex = 6;
			this.lblTotalAmount.Text = "Tổng tiền: 0 VNĐ";
			// 
			// lblTotalDiscount
			// 
			this.lblTotalDiscount.AutoSize = true;
			this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalDiscount.Location = new System.Drawing.Point(200, 460);
			this.lblTotalDiscount.Name = "lblTotalDiscount";
			this.lblTotalDiscount.Size = new System.Drawing.Size(112, 15);
			this.lblTotalDiscount.TabIndex = 7;
			this.lblTotalDiscount.Text = "Giảm giá: 0 VNĐ";
			// 
			// lblTotalTax
			// 
			this.lblTotalTax.AutoSize = true;
			this.lblTotalTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalTax.Location = new System.Drawing.Point(380, 460);
			this.lblTotalTax.Name = "lblTotalTax";
			this.lblTotalTax.Size = new System.Drawing.Size(83, 15);
			this.lblTotalTax.TabIndex = 8;
			this.lblTotalTax.Text = "Thuế: 0 VNĐ";
			// 
			// lblRevenue
			// 
			this.lblRevenue.AutoSize = true;
			this.lblRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRevenue.ForeColor = System.Drawing.Color.Green;
			this.lblRevenue.Location = new System.Drawing.Point(540, 460);
			this.lblRevenue.Name = "lblRevenue";
			this.lblRevenue.Size = new System.Drawing.Size(128, 17);
			this.lblRevenue.TabIndex = 9;
			this.lblRevenue.Text = "Doanh thu: 0 VNĐ";
			// 
			// lblOrderCount
			// 
			this.lblOrderCount.AutoSize = true;
			this.lblOrderCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOrderCount.Location = new System.Drawing.Point(800, 460);
			this.lblOrderCount.Name = "lblOrderCount";
			this.lblOrderCount.Size = new System.Drawing.Size(102, 15);
			this.lblOrderCount.TabIndex = 10;
			this.lblOrderCount.Text = "Số hóa đơn: 0";
			// 
			// OrdersForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 491);
			this.Controls.Add(this.lblOrderCount);
			this.Controls.Add(this.lblRevenue);
			this.Controls.Add(this.lblTotalTax);
			this.Controls.Add(this.lblTotalDiscount);
			this.Controls.Add(this.lblTotalAmount);
			this.Controls.Add(this.dgvOrders);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.dtpEndDate);
			this.Controls.Add(this.dtpStartDate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "OrdersForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý hóa đơn";
			this.Load += new System.EventHandler(this.OrdersForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpStartDate;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.DataGridView dgvOrders;
		private System.Windows.Forms.Label lblTotalAmount;
		private System.Windows.Forms.Label lblTotalDiscount;
		private System.Windows.Forms.Label lblTotalTax;
		private System.Windows.Forms.Label lblRevenue;
		private System.Windows.Forms.Label lblOrderCount;
	}
}
