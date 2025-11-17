namespace Lab07_2212364_PVQHien
{
	partial class BillDetailsForm
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
			this.lblInvoiceId = new System.Windows.Forms.Label();
			this.lblTable = new System.Windows.Forms.Label();
			this.lblDateCreated = new System.Windows.Forms.Label();
			this.lblDatePayment = new System.Windows.Forms.Label();
			this.lblTotalAmount = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lvwDetails = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// lblInvoiceId
			// 
			this.lblInvoiceId.AutoSize = true;
			this.lblInvoiceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInvoiceId.Location = new System.Drawing.Point(12, 15);
			this.lblInvoiceId.Name = "lblInvoiceId";
			this.lblInvoiceId.Size = new System.Drawing.Size(87, 15);
			this.lblInvoiceId.TabIndex = 0;
			this.lblInvoiceId.Text = "Hóa đơn #: ";
			// 
			// lblTable
			// 
			this.lblTable.AutoSize = true;
			this.lblTable.Location = new System.Drawing.Point(12, 40);
			this.lblTable.Name = "lblTable";
			this.lblTable.Size = new System.Drawing.Size(32, 13);
			this.lblTable.TabIndex = 1;
			this.lblTable.Text = "Bàn: ";
			// 
			// lblDateCreated
			// 
			this.lblDateCreated.AutoSize = true;
			this.lblDateCreated.Location = new System.Drawing.Point(12, 60);
			this.lblDateCreated.Name = "lblDateCreated";
			this.lblDateCreated.Size = new System.Drawing.Size(56, 13);
			this.lblDateCreated.TabIndex = 2;
			this.lblDateCreated.Text = "Ngày tạo: ";
			// 
			// lblDatePayment
			// 
			this.lblDatePayment.AutoSize = true;
			this.lblDatePayment.Location = new System.Drawing.Point(12, 80);
			this.lblDatePayment.Name = "lblDatePayment";
			this.lblDatePayment.Size = new System.Drawing.Size(98, 13);
			this.lblDatePayment.TabIndex = 3;
			this.lblDatePayment.Text = "Ngày thanh toán: ";
			// 
			// lblTotalAmount
			// 
			this.lblTotalAmount.AutoSize = true;
			this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalAmount.Location = new System.Drawing.Point(400, 15);
			this.lblTotalAmount.Name = "lblTotalAmount";
			this.lblTotalAmount.Size = new System.Drawing.Size(78, 15);
			this.lblTotalAmount.TabIndex = 4;
			this.lblTotalAmount.Text = "Tổng tiền: ";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(400, 40);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(61, 13);
			this.lblStatus.TabIndex = 5;
			this.lblStatus.Text = "Trạng thái: ";
			// 
			// lvwDetails
			// 
			this.lvwDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.lvwDetails.FullRowSelect = true;
			this.lvwDetails.GridLines = true;
			this.lvwDetails.HideSelection = false;
			this.lvwDetails.Location = new System.Drawing.Point(12, 110);
			this.lvwDetails.Name = "lvwDetails";
			this.lvwDetails.Size = new System.Drawing.Size(660, 290);
			this.lvwDetails.TabIndex = 6;
			this.lvwDetails.UseCompatibleStateImageBehavior = false;
			this.lvwDetails.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "STT";
			this.columnHeader1.Width = 50;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Món ăn";
			this.columnHeader2.Width = 200;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Số lượng";
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Đơn giá";
			this.columnHeader4.Width = 120;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Thành tiền";
			this.columnHeader5.Width = 120;
			// 
			// BillDetailsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 421);
			this.Controls.Add(this.lvwDetails);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.lblTotalAmount);
			this.Controls.Add(this.lblDatePayment);
			this.Controls.Add(this.lblDateCreated);
			this.Controls.Add(this.lblTable);
			this.Controls.Add(this.lblInvoiceId);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BillDetailsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Chi tiết hóa đơn";
			this.Load += new System.EventHandler(this.BillDetailsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Label lblInvoiceId;
		private System.Windows.Forms.Label lblTable;
		private System.Windows.Forms.Label lblDateCreated;
		private System.Windows.Forms.Label lblDatePayment;
		private System.Windows.Forms.Label lblTotalAmount;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.ListView lvwDetails;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
	}
}
