namespace Lab07_2212364_PVQHien
{
	partial class RoleForm
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
			this.lvwRoles = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvwUsers = new System.Windows.Forms.ListView();
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txtRoleName = new System.Windows.Forms.TextBox();
			this.txtRoleDescription = new System.Windows.Forms.TextBox();
			this.btnAddRole = new System.Windows.Forms.Button();
			this.btnUpdateRole = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwRoles
			// 
			this.lvwRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lvwRoles.FullRowSelect = true;
			this.lvwRoles.GridLines = true;
			this.lvwRoles.HideSelection = false;
			this.lvwRoles.Location = new System.Drawing.Point(12, 12);
			this.lvwRoles.Name = "lvwRoles";
			this.lvwRoles.Size = new System.Drawing.Size(400, 250);
			this.lvwRoles.TabIndex = 0;
			this.lvwRoles.UseCompatibleStateImageBehavior = false;
			this.lvwRoles.View = System.Windows.Forms.View.Details;
			this.lvwRoles.SelectedIndexChanged += new System.EventHandler(this.lvwRoles_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 50;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Tên vai trò";
			this.columnHeader2.Width = 150;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Mô tả";
			this.columnHeader3.Width = 180;
			// 
			// lvwUsers
			// 
			this.lvwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
			this.lvwUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwUsers.FullRowSelect = true;
			this.lvwUsers.GridLines = true;
			this.lvwUsers.HideSelection = false;
			this.lvwUsers.Location = new System.Drawing.Point(3, 16);
			this.lvwUsers.Name = "lvwUsers";
			this.lvwUsers.Size = new System.Drawing.Size(394, 181);
			this.lvwUsers.TabIndex = 1;
			this.lvwUsers.UseCompatibleStateImageBehavior = false;
			this.lvwUsers.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "ID";
			this.columnHeader4.Width = 50;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Username";
			this.columnHeader5.Width = 100;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Họ tên";
			this.columnHeader6.Width = 120;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Email";
			this.columnHeader7.Width = 100;
			// 
			// txtRoleName
			// 
			this.txtRoleName.Location = new System.Drawing.Point(6, 32);
			this.txtRoleName.Name = "txtRoleName";
			this.txtRoleName.Size = new System.Drawing.Size(250, 20);
			this.txtRoleName.TabIndex = 2;
			// 
			// txtRoleDescription
			// 
			this.txtRoleDescription.Location = new System.Drawing.Point(6, 74);
			this.txtRoleDescription.Multiline = true;
			this.txtRoleDescription.Name = "txtRoleDescription";
			this.txtRoleDescription.Size = new System.Drawing.Size(250, 60);
			this.txtRoleDescription.TabIndex = 3;
			// 
			// btnAddRole
			// 
			this.btnAddRole.Location = new System.Drawing.Point(6, 145);
			this.btnAddRole.Name = "btnAddRole";
			this.btnAddRole.Size = new System.Drawing.Size(120, 30);
			this.btnAddRole.TabIndex = 4;
			this.btnAddRole.Text = "Thêm vai trò";
			this.btnAddRole.UseVisualStyleBackColor = true;
			this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
			// 
			// btnUpdateRole
			// 
			this.btnUpdateRole.Location = new System.Drawing.Point(136, 145);
			this.btnUpdateRole.Name = "btnUpdateRole";
			this.btnUpdateRole.Size = new System.Drawing.Size(120, 30);
			this.btnUpdateRole.TabIndex = 5;
			this.btnUpdateRole.Text = "Cập nhật vai trò";
			this.btnUpdateRole.UseVisualStyleBackColor = true;
			this.btnUpdateRole.Click += new System.EventHandler(this.btnUpdateRole_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tên vai trò:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Mô tả:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtRoleName);
			this.groupBox1.Controls.Add(this.btnUpdateRole);
			this.groupBox1.Controls.Add(this.txtRoleDescription);
			this.groupBox1.Controls.Add(this.btnAddRole);
			this.groupBox1.Location = new System.Drawing.Point(418, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(270, 185);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin vai trò";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lvwUsers);
			this.groupBox2.Location = new System.Drawing.Point(12, 268);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(400, 200);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Người dùng thuộc vai trò";
			// 
			// RoleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 480);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lvwRoles);
			this.Name = "RoleForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý vai trò";
			this.Load += new System.EventHandler(this.RoleForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvwRoles;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ListView lvwUsers;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.TextBox txtRoleName;
		private System.Windows.Forms.TextBox txtRoleDescription;
		private System.Windows.Forms.Button btnAddRole;
		private System.Windows.Forms.Button btnUpdateRole;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}
