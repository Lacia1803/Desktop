namespace Lab07_2212364_PVQHien
{
	partial class AccountForm
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

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lvwAccounts = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cbbRole = new System.Windows.Forms.ComboBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnAddAccount = new System.Windows.Forms.Button();
			this.btnUpdateAccount = new System.Windows.Forms.Button();
			this.btnResetPassword = new System.Windows.Forms.Button();
			this.btnChangePassword = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuDeleteAccount = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewRoles = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwAccounts
			// 
			this.lvwAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.lvwAccounts.ContextMenuStrip = this.contextMenuStrip1;
			this.lvwAccounts.FullRowSelect = true;
			this.lvwAccounts.GridLines = true;
			this.lvwAccounts.HideSelection = false;
			this.lvwAccounts.Location = new System.Drawing.Point(12, 80);
			this.lvwAccounts.Name = "lvwAccounts";
			this.lvwAccounts.Size = new System.Drawing.Size(760, 350);
			this.lvwAccounts.TabIndex = 0;
			this.lvwAccounts.UseCompatibleStateImageBehavior = false;
			this.lvwAccounts.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 50;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Username";
			this.columnHeader2.Width = 120;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Họ tên";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Email";
			this.columnHeader4.Width = 180;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Điện thoại";
			this.columnHeader5.Width = 100;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Trạng thái";
			this.columnHeader6.Width = 100;
			// 
			// cbbRole
			// 
			this.cbbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbRole.FormattingEnabled = true;
			this.cbbRole.Location = new System.Drawing.Point(80, 15);
			this.cbbRole.Name = "cbbRole";
			this.cbbRole.Size = new System.Drawing.Size(200, 21);
			this.cbbRole.TabIndex = 1;
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(370, 15);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(200, 20);
			this.txtSearch.TabIndex = 2;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(580, 12);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(90, 25);
			this.btnSearch.TabIndex = 3;
			this.btnSearch.Text = "Tìm kiếm";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnAddAccount
			// 
			this.btnAddAccount.Location = new System.Drawing.Point(12, 440);
			this.btnAddAccount.Name = "btnAddAccount";
			this.btnAddAccount.Size = new System.Drawing.Size(120, 30);
			this.btnAddAccount.TabIndex = 4;
			this.btnAddAccount.Text = "Thêm tài khoản";
			this.btnAddAccount.UseVisualStyleBackColor = true;
			this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
			// 
			// btnUpdateAccount
			// 
			this.btnUpdateAccount.Location = new System.Drawing.Point(140, 440);
			this.btnUpdateAccount.Name = "btnUpdateAccount";
			this.btnUpdateAccount.Size = new System.Drawing.Size(120, 30);
			this.btnUpdateAccount.TabIndex = 5;
			this.btnUpdateAccount.Text = "Cập nhật";
			this.btnUpdateAccount.UseVisualStyleBackColor = true;
			this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
			// 
			// btnResetPassword
			// 
			this.btnResetPassword.Location = new System.Drawing.Point(268, 440);
			this.btnResetPassword.Name = "btnResetPassword";
			this.btnResetPassword.Size = new System.Drawing.Size(120, 30);
			this.btnResetPassword.TabIndex = 6;
			this.btnResetPassword.Text = "Reset mật khẩu";
			this.btnResetPassword.UseVisualStyleBackColor = true;
			this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
			// 
			// btnChangePassword
			// 
			this.btnChangePassword.Location = new System.Drawing.Point(396, 440);
			this.btnChangePassword.Name = "btnChangePassword";
			this.btnChangePassword.Size = new System.Drawing.Size(120, 30);
			this.btnChangePassword.TabIndex = 7;
			this.btnChangePassword.Text = "Đổi mật khẩu";
			this.btnChangePassword.UseVisualStyleBackColor = true;
			this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteAccount,
            this.menuViewRoles});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
			// 
			// menuDeleteAccount
			// 
			this.menuDeleteAccount.Name = "menuDeleteAccount";
			this.menuDeleteAccount.Size = new System.Drawing.Size(180, 22);
			this.menuDeleteAccount.Text = "Xóa tài khoản";
			this.menuDeleteAccount.Click += new System.EventHandler(this.menuDeleteAccount_Click);
			// 
			// menuViewRoles
			// 
			this.menuViewRoles.Name = "menuViewRoles";
			this.menuViewRoles.Size = new System.Drawing.Size(180, 22);
			this.menuViewRoles.Text = "Xem danh sách vai trò";
			this.menuViewRoles.Click += new System.EventHandler(this.menuViewRoles_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Vai trò:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(300, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Tìm kiếm:";
			// 
			// AccountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 482);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnChangePassword);
			this.Controls.Add(this.btnResetPassword);
			this.Controls.Add(this.btnUpdateAccount);
			this.Controls.Add(this.btnAddAccount);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.cbbRole);
			this.Controls.Add(this.lvwAccounts);
			this.Name = "AccountForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý tài khoản";
			this.Load += new System.EventHandler(this.AccountForm_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lvwAccounts;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ComboBox cbbRole;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnAddAccount;
		private System.Windows.Forms.Button btnUpdateAccount;
		private System.Windows.Forms.Button btnResetPassword;
		private System.Windows.Forms.Button btnChangePassword;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuDeleteAccount;
		private System.Windows.Forms.ToolStripMenuItem menuViewRoles;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}
