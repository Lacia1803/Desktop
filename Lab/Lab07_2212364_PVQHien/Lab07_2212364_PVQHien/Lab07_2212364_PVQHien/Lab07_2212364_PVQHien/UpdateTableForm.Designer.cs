namespace Lab07_2212364_PVQHien
{
	partial class UpdateTableForm
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
			this.txtName = new System.Windows.Forms.TextBox();
			this.nudCapacity = new System.Windows.Forms.NumericUpDown();
			this.cbbHall = new System.Windows.Forms.ComboBox();
			this.cbbStatus = new System.Windows.Forms.ComboBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(120, 20);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(200, 20);
			this.txtName.TabIndex = 0;
			// 
			// nudCapacity
			// 
			this.nudCapacity.Location = new System.Drawing.Point(120, 50);
			this.nudCapacity.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.nudCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudCapacity.Name = "nudCapacity";
			this.nudCapacity.Size = new System.Drawing.Size(200, 20);
			this.nudCapacity.TabIndex = 1;
			this.nudCapacity.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// cbbHall
			// 
			this.cbbHall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbHall.FormattingEnabled = true;
			this.cbbHall.Location = new System.Drawing.Point(120, 80);
			this.cbbHall.Name = "cbbHall";
			this.cbbHall.Size = new System.Drawing.Size(200, 21);
			this.cbbHall.TabIndex = 2;
			// 
			// cbbStatus
			// 
			this.cbbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbStatus.FormattingEnabled = true;
			this.cbbStatus.Items.AddRange(new object[] {
            "Available",
            "Occupied",
            "Reserved"});
			this.cbbStatus.Location = new System.Drawing.Point(120, 110);
			this.cbbStatus.Name = "cbbStatus";
			this.cbbStatus.Size = new System.Drawing.Size(200, 21);
			this.cbbStatus.TabIndex = 3;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(120, 150);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(100, 30);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Tên bàn:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Sức chứa:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Phòng:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Trạng thái:";
			// 
			// UpdateTableForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 201);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.cbbStatus);
			this.Controls.Add(this.cbbHall);
			this.Controls.Add(this.nudCapacity);
			this.Controls.Add(this.txtName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdateTableForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cập nhật bàn";
			this.Load += new System.EventHandler(this.UpdateTableForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.NumericUpDown nudCapacity;
		private System.Windows.Forms.ComboBox cbbHall;
		private System.Windows.Forms.ComboBox cbbStatus;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}
