namespace Lab07_2212364_PVQHien
{
	partial class AccountRolesForm
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
			this.lblAccountName = new System.Windows.Forms.Label();
			this.lvwRoles = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// lblAccountName
			// 
			this.lblAccountName.AutoSize = true;
			this.lblAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAccountName.Location = new System.Drawing.Point(12, 15);
			this.lblAccountName.Name = "lblAccountName";
			this.lblAccountName.Size = new System.Drawing.Size(88, 16);
			this.lblAccountName.TabIndex = 0;
			this.lblAccountName.Text = "Tài khoản: ";
			// 
			// lvwRoles
			// 
			this.lvwRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lvwRoles.FullRowSelect = true;
			this.lvwRoles.GridLines = true;
			this.lvwRoles.HideSelection = false;
			this.lvwRoles.Location = new System.Drawing.Point(12, 45);
			this.lvwRoles.Name = "lvwRoles";
			this.lvwRoles.Size = new System.Drawing.Size(460, 193);
			this.lvwRoles.TabIndex = 1;
			this.lvwRoles.UseCompatibleStateImageBehavior = false;
			this.lvwRoles.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Vai trò";
			this.columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Mô tả";
			this.columnHeader2.Width = 280;
			// 
			// AccountRolesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 261);
			this.Controls.Add(this.lvwRoles);
			this.Controls.Add(this.lblAccountName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AccountRolesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Vai trò của tài khoản";
			this.Load += new System.EventHandler(this.AccountRolesForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Label lblAccountName;
		private System.Windows.Forms.ListView lvwRoles;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}
