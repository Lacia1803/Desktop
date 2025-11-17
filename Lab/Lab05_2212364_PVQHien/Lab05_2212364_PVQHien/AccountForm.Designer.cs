namespace Lab05_2212364_PVQHien
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

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dgvAccounts = new System.Windows.Forms.DataGridView();
			this.contextMenuAccounts = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmViewRoles = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmViewActivityLog = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAccountName = new System.Windows.Forms.TextBox();
			this.txtFullName = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.btnAddAccount = new System.Windows.Forms.Button();
			this.btnUpdateAccount = new System.Windows.Forms.Button();
			this.btnResetPassword = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
			this.contextMenuAccounts.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvAccounts
			// 
			this.dgvAccounts.AllowUserToAddRows = false;
			this.dgvAccounts.AllowUserToDeleteRows = false;
			this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAccounts.ContextMenuStrip = this.contextMenuAccounts;
			this.dgvAccounts.Location = new System.Drawing.Point(12, 12);
			this.dgvAccounts.MultiSelect = false;
			this.dgvAccounts.Name = "dgvAccounts";
			this.dgvAccounts.ReadOnly = true;
			this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAccounts.Size = new System.Drawing.Size(760, 250);
			this.dgvAccounts.TabIndex = 0;
			this.dgvAccounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellClick);
			this.dgvAccounts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvAccounts_MouseDown);
			// 
			// contextMenuAccounts
			// 
			this.contextMenuAccounts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmViewRoles,
            this.tsmViewActivityLog});
			this.contextMenuAccounts.Name = "contextMenuAccounts";
			this.contextMenuAccounts.Size = new System.Drawing.Size(212, 48);
			// 
			// tsmViewRoles
			// 
			this.tsmViewRoles.Name = "tsmViewRoles";
			this.tsmViewRoles.Size = new System.Drawing.Size(211, 22);
			this.tsmViewRoles.Text = "Xem danh sách các vai trò";
			this.tsmViewRoles.Click += new System.EventHandler(this.tsmViewRoles_Click);
			// 
			// tsmViewActivityLog
			// 
			this.tsmViewActivityLog.Name = "tsmViewActivityLog";
			this.tsmViewActivityLog.Size = new System.Drawing.Size(211, 22);
			this.tsmViewActivityLog.Text = "Xem nhật ký hoạt động";
			this.tsmViewActivityLog.Click += new System.EventHandler(this.tsmViewActivityLog_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 280);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Tên tài khoản:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 310);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Họ và tên:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 340);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Email:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 370);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Số điện thoại:";
			// 
			// txtAccountName
			// 
			this.txtAccountName.Location = new System.Drawing.Point(110, 277);
			this.txtAccountName.Name = "txtAccountName";
			this.txtAccountName.Size = new System.Drawing.Size(250, 20);
			this.txtAccountName.TabIndex = 5;
			// 
			// txtFullName
			// 
			this.txtFullName.Location = new System.Drawing.Point(110, 307);
			this.txtFullName.Name = "txtFullName";
			this.txtFullName.Size = new System.Drawing.Size(400, 20);
			this.txtFullName.TabIndex = 6;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(110, 337);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(400, 20);
			this.txtEmail.TabIndex = 7;
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(110, 367);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(250, 20);
			this.txtPhone.TabIndex = 8;
			// 
			// btnAddAccount
			// 
			this.btnAddAccount.Location = new System.Drawing.Point(110, 405);
			this.btnAddAccount.Name = "btnAddAccount";
			this.btnAddAccount.Size = new System.Drawing.Size(100, 30);
			this.btnAddAccount.TabIndex = 9;
			this.btnAddAccount.Text = "Thêm mới";
			this.btnAddAccount.UseVisualStyleBackColor = true;
			this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
			// 
			// btnUpdateAccount
			// 
			this.btnUpdateAccount.Location = new System.Drawing.Point(230, 405);
			this.btnUpdateAccount.Name = "btnUpdateAccount";
			this.btnUpdateAccount.Size = new System.Drawing.Size(100, 30);
			this.btnUpdateAccount.TabIndex = 10;
			this.btnUpdateAccount.Text = "Cập nhật";
			this.btnUpdateAccount.UseVisualStyleBackColor = true;
			this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
			// 
			// btnResetPassword
			// 
			this.btnResetPassword.Location = new System.Drawing.Point(350, 405);
			this.btnResetPassword.Name = "btnResetPassword";
			this.btnResetPassword.Size = new System.Drawing.Size(120, 30);
			this.btnResetPassword.TabIndex = 11;
			this.btnResetPassword.Text = "Reset mật khẩu";
			this.btnResetPassword.UseVisualStyleBackColor = true;
			this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(490, 405);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(100, 30);
			this.btnClear.TabIndex = 12;
			this.btnClear.Text = "Làm mới";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// AccountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 461);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnResetPassword);
			this.Controls.Add(this.btnUpdateAccount);
			this.Controls.Add(this.btnAddAccount);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtFullName);
			this.Controls.Add(this.txtAccountName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvAccounts);
			this.Name = "AccountForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý tài khoản";
			this.Load += new System.EventHandler(this.AccountForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
			this.contextMenuAccounts.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.DataGridView dgvAccounts;
		private System.Windows.Forms.ContextMenuStrip contextMenuAccounts;
		private System.Windows.Forms.ToolStripMenuItem tsmViewRoles;
		private System.Windows.Forms.ToolStripMenuItem tsmViewActivityLog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtAccountName;
		private System.Windows.Forms.TextBox txtFullName;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.Button btnAddAccount;
		private System.Windows.Forms.Button btnUpdateAccount;
		private System.Windows.Forms.Button btnResetPassword;
		private System.Windows.Forms.Button btnClear;
	}
}
