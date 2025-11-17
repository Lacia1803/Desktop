using Lab06_2212364_PVQHien.BUS;
using Lab06_2212364_PVQHien.DA;
using System;
using System.Windows.Forms;

namespace Lab06_2212364_PVQHien.Win
{
    public partial class frmMain : Form
    {
        public Account CurrentAccount { get; set; }

        public frmMain(Account account)
        {
            InitializeComponent();
            CurrentAccount = account;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào: {CurrentAccount.FullName} ({CurrentAccount.Role})";
            
            // Phân quyền theo role
            ConfigureMenuByRole();
        }

        private void ConfigureMenuByRole()
        {
            // Quyền mặc định - tất cả đều thấy
            menuQuanLyMonAn.Visible = true;
            menuDatMon.Visible = true;
            
            // Quyền Admin - full quyền
            if (CurrentAccount.Role == "Admin")
            {
                menuQuanLyTaiKhoan.Visible = true;
                menuQuanLyBan.Visible = true;
                menuThanhToan.Visible = true;
                menuBaoCao.Visible = true;
            }
            // Quyền Quản lý - hầu hết các quyền
            else if (CurrentAccount.Role == "Quản lý")
            {
                menuQuanLyTaiKhoan.Visible = false;
                menuQuanLyBan.Visible = true;
                menuThanhToan.Visible = true;
                menuBaoCao.Visible = true;
            }
            // Quyền Kế toán - chỉ thanh toán và báo cáo
            else if (CurrentAccount.Role == "Kế toán")
            {
                menuQuanLyTaiKhoan.Visible = false;
                menuQuanLyBan.Visible = false;
                menuThanhToan.Visible = true;
                menuBaoCao.Visible = true;
            }
            // Quyền Nhân viên - chỉ đặt món
            else
            {
                menuQuanLyTaiKhoan.Visible = false;
                menuQuanLyBan.Visible = false;
                menuThanhToan.Visible = false;
                menuBaoCao.Visible = false;
            }
        }

        private void menuQuanLyMonAn_Click(object sender, EventArgs e)
        {
            frmFood frm = new frmFood();
            frm.ShowDialog();
        }

        private void menuQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển", "Thông báo");
        }

        private void menuQuanLyBan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển", "Thông báo");
        }

        private void menuDatMon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển", "Thông báo");
        }

        private void menuThanhToan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển", "Thông báo");
        }

        private void menuBaoCao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển", "Thông báo");
        }

        private void menuDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Tạo form dialog đơn giản để đổi mật khẩu
            Form frmChangePassword = new Form
            {
                Text = "Đổi mật khẩu",
                Size = new System.Drawing.Size(400, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblOldPass = new Label { Text = "Mật khẩu cũ:", Left = 20, Top = 20, Width = 120 };
            TextBox txtOldPass = new TextBox { Left = 150, Top = 20, Width = 200, UseSystemPasswordChar = true };

            Label lblNewPass = new Label { Text = "Mật khẩu mới:", Left = 20, Top = 60, Width = 120 };
            TextBox txtNewPass = new TextBox { Left = 150, Top = 60, Width = 200, UseSystemPasswordChar = true };

            Label lblConfirm = new Label { Text = "Xác nhận mật khẩu:", Left = 20, Top = 100, Width = 120 };
            TextBox txtConfirm = new TextBox { Left = 150, Top = 100, Width = 200, UseSystemPasswordChar = true };

            Button btnOK = new Button { Text = "Đồng ý", Left = 150, Top = 150, Width = 80, DialogResult = DialogResult.OK };
            Button btnCancel = new Button { Text = "Hủy", Left = 250, Top = 150, Width = 80, DialogResult = DialogResult.Cancel };

            frmChangePassword.Controls.AddRange(new Control[] { lblOldPass, txtOldPass, lblNewPass, txtNewPass, lblConfirm, txtConfirm, btnOK, btnCancel });
            frmChangePassword.AcceptButton = btnOK;
            frmChangePassword.CancelButton = btnCancel;

            if (frmChangePassword.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(txtOldPass.Text) || string.IsNullOrEmpty(txtNewPass.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNewPass.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Mật khẩu mới và xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtOldPass.Text != CurrentAccount.Password)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật mật khẩu mới
                CurrentAccount.Password = txtNewPass.Text;
                AccountBL accountBL = new AccountBL();
                if (accountBL.Update(CurrentAccount) > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
