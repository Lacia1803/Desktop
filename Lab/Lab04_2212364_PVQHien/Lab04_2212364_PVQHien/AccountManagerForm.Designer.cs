namespace Lab04_2212364_PVQHien
{
	partial class AccountManagerForm
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
			this.dgvAccount = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmDeleteAccount = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmViewRoles = new System.Windows.Forms.ToolStripMenuItem();
			this.cboGroup = new System.Windows.Forms.ComboBox();
			this.cboStatus = new System.Windows.Forms.ComboBox();
			this.btnFilter = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtDisplayName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnResetPassword = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvAccount
			// 
			this.dgvAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAccount.ContextMenuStrip = this.contextMenuStrip1;
			this.dgvAccount.Location = new System.Drawing.Point(12, 120);
			this.dgvAccount.Name = "dgvAccount";
			this.dgvAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAccount.Size = new System.Drawing.Size(776, 318);
			this.dgvAccount.TabIndex = 0;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDeleteAccount,
            this.tsmViewRoles});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(180, 48);
			// 
			// tsmDeleteAccount
			// 
			this.tsmDeleteAccount.Name = "tsmDeleteAccount";
			this.tsmDeleteAccount.Size = new System.Drawing.Size(179, 22);
			this.tsmDeleteAccount.Text = "Xóa tài khoản";
			this.tsmDeleteAccount.Click += new System.EventHandler(this.tsmDeleteAccount_Click);
			// 
			// tsmViewRoles
			// 
			this.tsmViewRoles.Name = "tsmViewRoles";
			this.tsmViewRoles.Size = new System.Drawing.Size(179, 22);
			this.tsmViewRoles.Text = "Xem danh sách vai trò";
			this.tsmViewRoles.Click += new System.EventHandler(this.tsmViewRoles_Click);
			// 
			// cboGroup
			// 
			this.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGroup.FormattingEnabled = true;
			this.cboGroup.Location = new System.Drawing.Point(70, 80);
			this.cboGroup.Name = "cboGroup";
			this.cboGroup.Size = new System.Drawing.Size(150, 21);
			this.cboGroup.TabIndex = 1;
			// 
			// cboStatus
			// 
			this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboStatus.FormattingEnabled = true;
			this.cboStatus.Location = new System.Drawing.Point(320, 80);
			this.cboStatus.Name = "cboStatus";
			this.cboStatus.Size = new System.Drawing.Size(150, 21);
			this.cboStatus.TabIndex = 2;
			// 
			// btnFilter
			// 
			this.btnFilter.Location = new System.Drawing.Point(490, 78);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(75, 23);
			this.btnFilter.TabIndex = 3;
			this.btnFilter.Text = "Lọc";
			this.btnFilter.UseVisualStyleBackColor = true;
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Nhóm:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(250, 83);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Trạng thái:";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(120, 15);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(150, 20);
			this.txtUserName.TabIndex = 6;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(120, 45);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(150, 20);
			this.txtPassword.TabIndex = 7;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// txtDisplayName
			// 
			this.txtDisplayName.Location = new System.Drawing.Point(380, 15);
			this.txtDisplayName.Name = "txtDisplayName";
			this.txtDisplayName.Size = new System.Drawing.Size(200, 20);
			this.txtDisplayName.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Tên đăng nhập:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Mật khẩu:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(300, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Tên hiển thị:";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(600, 13);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 12;
			this.btnAdd.Text = "Thêm";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(600, 43);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(75, 23);
			this.btnUpdate.TabIndex = 13;
			this.btnUpdate.Text = "Cập nhật";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnResetPassword
			// 
			this.btnResetPassword.Location = new System.Drawing.Point(690, 13);
			this.btnResetPassword.Name = "btnResetPassword";
			this.btnResetPassword.Size = new System.Drawing.Size(100, 53);
			this.btnResetPassword.TabIndex = 14;
			this.btnResetPassword.Text = "Reset mật khẩu";
			this.btnResetPassword.UseVisualStyleBackColor = true;
			this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
			// 
			// AccountManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnResetPassword);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDisplayName);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnFilter);
			this.Controls.Add(this.cboStatus);
			this.Controls.Add(this.cboGroup);
			this.Controls.Add(this.dgvAccount);
			this.Name = "AccountManagerForm";
			this.Text = "Quản lý tài khoản";
			((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvAccount;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem tsmDeleteAccount;
		private System.Windows.Forms.ToolStripMenuItem tsmViewRoles;
		private System.Windows.Forms.ComboBox cboGroup;
		private System.Windows.Forms.ComboBox cboStatus;
		private System.Windows.Forms.Button btnFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtDisplayName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnResetPassword;
	}
}