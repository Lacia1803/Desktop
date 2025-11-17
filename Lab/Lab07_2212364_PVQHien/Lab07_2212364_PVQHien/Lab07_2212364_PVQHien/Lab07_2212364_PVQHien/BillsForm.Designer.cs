namespace Lab07_2212364_PVQHien
{
	partial class BillsForm
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
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.btnSearch = new System.Windows.Forms.Button();
			this.lvwBills = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnViewDetails = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// dtpFrom
			// 
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFrom.Location = new System.Drawing.Point(70, 15);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(120, 20);
			this.dtpFrom.TabIndex = 0;
			// 
			// dtpTo
			// 
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTo.Location = new System.Drawing.Point(240, 15);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(120, 20);
			this.dtpTo.TabIndex = 1;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(380, 13);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(100, 25);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Tìm kiếm";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// lvwBills
			// 
			this.lvwBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.lvwBills.FullRowSelect = true;
			this.lvwBills.GridLines = true;
			this.lvwBills.HideSelection = false;
			this.lvwBills.Location = new System.Drawing.Point(12, 50);
			this.lvwBills.Name = "lvwBills";
			this.lvwBills.Size = new System.Drawing.Size(760, 350);
			this.lvwBills.TabIndex = 3;
			this.lvwBills.UseCompatibleStateImageBehavior = false;
			this.lvwBills.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 50;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Bàn";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Ngày tạo";
			this.columnHeader3.Width = 140;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Ngày thanh toán";
			this.columnHeader4.Width = 140;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Tổng tiền";
			this.columnHeader5.Width = 120;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Trạng thái";
			this.columnHeader6.Width = 100;
			// 
			// btnViewDetails
			// 
			this.btnViewDetails.Location = new System.Drawing.Point(12, 415);
			this.btnViewDetails.Name = "btnViewDetails";
			this.btnViewDetails.Size = new System.Drawing.Size(120, 30);
			this.btnViewDetails.TabIndex = 4;
			this.btnViewDetails.Text = "Xem chi tiết";
			this.btnViewDetails.UseVisualStyleBackColor = true;
			this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Từ ngày:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Đến:";
			// 
			// BillsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 461);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnViewDetails);
			this.Controls.Add(this.lvwBills);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.dtpTo);
			this.Controls.Add(this.dtpFrom);
			this.Name = "BillsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý hóa đơn";
			this.Load += new System.EventHandler(this.BillsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.ListView lvwBills;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Button btnViewDetails;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}
