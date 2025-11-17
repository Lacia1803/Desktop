namespace Lab04_2212364_PVQHien
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.dgvTables = new System.Windows.Forms.DataGridView();
			this.txtTableName = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnViewBill = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmDeleteTable = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmViewBills = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmViewBillHistory = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvTables
			// 
			this.dgvTables.AllowUserToAddRows = false;
			this.dgvTables.AllowUserToDeleteRows = false;
			this.dgvTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTables.ContextMenuStrip = this.contextMenuStrip1;
			this.dgvTables.Location = new System.Drawing.Point(12, 80);
			this.dgvTables.Name = "dgvTables";
			this.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTables.Size = new System.Drawing.Size(776, 358);
			this.dgvTables.TabIndex = 0;
			// 
			// txtTableName
			// 
			this.txtTableName.Location = new System.Drawing.Point(80, 20);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(200, 20);
			this.txtTableName.TabIndex = 1;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(300, 18);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(100, 23);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Thêm bàn";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(420, 18);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(100, 23);
			this.btnUpdate.TabIndex = 3;
			this.btnUpdate.Text = "Cập nhật";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(540, 18);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(100, 23);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.Text = "Xóa bàn";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnViewBill
			// 
			this.btnViewBill.Location = new System.Drawing.Point(660, 18);
			this.btnViewBill.Name = "btnViewBill";
			this.btnViewBill.Size = new System.Drawing.Size(120, 23);
			this.btnViewBill.TabIndex = 5;
			this.btnViewBill.Text = "Xem hóa đơn";
			this.btnViewBill.UseVisualStyleBackColor = true;
			this.btnViewBill.Click += new System.EventHandler(this.btnViewBill_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tên bàn:";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDeleteTable,
            this.tsmViewBills,
            this.tsmViewBillHistory});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(200, 70);
			// 
			// tsmDeleteTable
			// 
			this.tsmDeleteTable.Name = "tsmDeleteTable";
			this.tsmDeleteTable.Size = new System.Drawing.Size(199, 22);
			this.tsmDeleteTable.Text = "Xóa bàn";
			this.tsmDeleteTable.Click += new System.EventHandler(this.tsmDeleteTable_Click);
			// 
			// tsmViewBills
			// 
			this.tsmViewBills.Name = "tsmViewBills";
			this.tsmViewBills.Size = new System.Drawing.Size(199, 22);
			this.tsmViewBills.Text = "Xem danh mục hóa đơn";
			this.tsmViewBills.Click += new System.EventHandler(this.tsmViewBills_Click);
			// 
			// tsmViewBillHistory
			// 
			this.tsmViewBillHistory.Name = "tsmViewBillHistory";
			this.tsmViewBillHistory.Size = new System.Drawing.Size(199, 22);
			this.tsmViewBillHistory.Text = "Xem nhật ký hóa đơn";
			this.tsmViewBillHistory.Click += new System.EventHandler(this.tsmViewBillHistory_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnViewBill);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.txtTableName);
			this.Controls.Add(this.dgvTables);
			this.Name = "MainForm";
			this.Text = "Quản lý bàn - Restaurant Management";
			((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvTables;
		private System.Windows.Forms.TextBox txtTableName;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnViewBill;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem tsmDeleteTable;
		private System.Windows.Forms.ToolStripMenuItem tsmViewBills;
		private System.Windows.Forms.ToolStripMenuItem tsmViewBillHistory;
	}
}
