namespace Lab05_2212364_PVQHien
{
	partial class OrderDetailsForm
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
			this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblItemCount = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvOrderDetails
			// 
			this.dgvOrderDetails.AllowUserToAddRows = false;
			this.dgvOrderDetails.AllowUserToDeleteRows = false;
			this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvOrderDetails.Location = new System.Drawing.Point(12, 12);
			this.dgvOrderDetails.Name = "dgvOrderDetails";
			this.dgvOrderDetails.ReadOnly = true;
			this.dgvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvOrderDetails.Size = new System.Drawing.Size(760, 350);
			this.dgvOrderDetails.TabIndex = 0;
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotal.Location = new System.Drawing.Point(12, 375);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(127, 17);
			this.lblTotal.TabIndex = 1;
			this.lblTotal.Text = "Tổng cộng: 0 VNĐ";
			// 
			// lblItemCount
			// 
			this.lblItemCount.AutoSize = true;
			this.lblItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblItemCount.Location = new System.Drawing.Point(300, 376);
			this.lblItemCount.Name = "lblItemCount";
			this.lblItemCount.Size = new System.Drawing.Size(72, 15);
			this.lblItemCount.TabIndex = 2;
			this.lblItemCount.Text = "Số món: 0";
			// 
			// OrderDetailsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 411);
			this.Controls.Add(this.lblItemCount);
			this.Controls.Add(this.lblTotal);
			this.Controls.Add(this.dgvOrderDetails);
			this.Name = "OrderDetailsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Chi tiết hóa đơn";
			this.Load += new System.EventHandler(this.OrderDetailsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.DataGridView dgvOrderDetails;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblItemCount;
	}
}
