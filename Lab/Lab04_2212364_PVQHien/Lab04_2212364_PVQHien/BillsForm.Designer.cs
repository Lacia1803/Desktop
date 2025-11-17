namespace Lab04_2212364_PVQHien
{
	partial class BillsForm
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
			this.dgvHoaDon = new System.Windows.Forms.DataGridView();
			this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
			this.dtpToDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnFilter = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvHoaDon
			// 
			this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHoaDon.Location = new System.Drawing.Point(12, 60);
			this.dgvHoaDon.Name = "dgvHoaDon";
			this.dgvHoaDon.ReadOnly = true;
			this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvHoaDon.Size = new System.Drawing.Size(776, 378);
			this.dgvHoaDon.TabIndex = 0;
			this.dgvHoaDon.DoubleClick += new System.EventHandler(this.dgvHoaDon_DoubleClick);
			// 
			// dtpFromDate
			// 
			this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFromDate.Location = new System.Drawing.Point(80, 15);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(150, 20);
			this.dtpFromDate.TabIndex = 1;
			this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
			// 
			// dtpToDate
			// 
			this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpToDate.Location = new System.Drawing.Point(310, 15);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(150, 20);
			this.dtpToDate.TabIndex = 2;
			this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Từ ngày:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(250, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Đến ngày:";
			// 
			// btnFilter
			// 
			this.btnFilter.Location = new System.Drawing.Point(480, 13);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(100, 23);
			this.btnFilter.TabIndex = 5;
			this.btnFilter.Text = "Lọc";
			this.btnFilter.UseVisualStyleBackColor = true;
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// BillsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnFilter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtpToDate);
			this.Controls.Add(this.dtpFromDate);
			this.Controls.Add(this.dgvHoaDon);
			this.Name = "BillsForm";
			this.Text = "Danh sách hóa đơn";
			((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvHoaDon;
		private System.Windows.Forms.DateTimePicker dtpFromDate;
		private System.Windows.Forms.DateTimePicker dtpToDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnFilter;
	}
}