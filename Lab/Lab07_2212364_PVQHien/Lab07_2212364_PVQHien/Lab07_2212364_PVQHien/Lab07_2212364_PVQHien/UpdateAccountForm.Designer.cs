namespace Lab07_2212364_PVQHien
{
	partial class UpdateAccountForm
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
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtFullName = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.chkIsActive = new System.Windows.Forms.CheckBox();
			this.clbRoles = new System.Windows.Forms.CheckedListBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(120, 15);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(250, 20);
			this.txtUsername.TabIndex = 0;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(120, 45);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(250, 20);
			this.txtPassword.TabIndex = 1;
			// 
			// txtFullName
			// 
			this.txtFullName.Location = new System.Drawing.Point(120, 75);
			this.txtFullName.Name = "txtFullName";
			this.txtFullName.Size = new System.Drawing.Size(250, 20);
			this.txtFullName.TabIndex = 2;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(120, 105);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(250, 20);
			this.txtEmail.TabIndex = 3;
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(120, 135);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(250, 20);
			this.txtPhone.TabIndex = 4;
			// 
			// chkIsActive
			// 
			this.chkIsActive.AutoSize = true;
			this.chkIsActive.Checked = true;
			this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIsActive.Location = new System.Drawing.Point(120, 165);
			this.chkIsActive.Name = "chkIsActive";
			this.chkIsActive.Size = new System.Drawing.Size(81, 17);
			this.chkIsActive.TabIndex = 5;
			this.chkIsActive.Text = "Hoạt động";
			this.chkIsActive.UseVisualStyleBackColor = true;
			// 
			// clbRoles
			// 
			this.clbRoles.FormattingEnabled = true;
			this.clbRoles.Location = new System.Drawing.Point(120, 195);
			this.clbRoles.Name = "clbRoles";
			this.clbRoles.Size = new System.Drawing.Size(250, 109);
			this.clbRoles.TabIndex = 6;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(150, 320);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(100, 30);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Tên đăng nhập:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Mật khẩu:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Họ tên:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Email:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 138);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Điện thoại:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 195);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Vai trò:";
			// 
			// UpdateAccountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 370);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.clbRoles);
			this.Controls.Add(this.chkIsActive);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtFullName);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUsername);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdateAccountForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cập nhật tài khoản";
			this.Load += new System.EventHandler(this.UpdateAccountForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtFullName;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.CheckBox chkIsActive;
		private System.Windows.Forms.CheckedListBox clbRoles;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
	}
}
