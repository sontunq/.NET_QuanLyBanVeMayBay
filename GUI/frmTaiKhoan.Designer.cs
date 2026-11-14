namespace QuanLyBanVeMayBay.GUI
{
    partial class frmTaiKhoan
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.ipTenDangNhap = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.ipMatKhau = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.ipHoTen = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.ipEmail = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.ipSoDienThoai = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cboVaiTro = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnLuu = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.ipTenDangNhap.SuspendLayout();
            this.ipMatKhau.SuspendLayout();
            this.ipHoTen.SuspendLayout();
            this.ipEmail.SuspendLayout();
            this.ipSoDienThoai.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(162, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Thêm tài khoản";
            //
            // lblTenDangNhap
            //
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblTenDangNhap.Location = new System.Drawing.Point(28, 70);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(106, 13);
            this.lblTenDangNhap.Text = "TÊN ĐĂNG NHẬP *";
            //
            // ipTenDangNhap
            //
            this.ipTenDangNhap.Controls.Add(this.txtTenDangNhap);
            this.ipTenDangNhap.Location = new System.Drawing.Point(28, 90);
            this.ipTenDangNhap.Name = "ipTenDangNhap";
            this.ipTenDangNhap.Size = new System.Drawing.Size(220, 42);
            this.ipTenDangNhap.TabIndex = 1;
            //
            // txtTenDangNhap
            //
            this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenDangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenDangNhap.MaxLength = 50;
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.TabIndex = 0;
            //
            // lblMatKhau
            //
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblMatKhau.Location = new System.Drawing.Point(272, 70);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(75, 13);
            this.lblMatKhau.Text = "MẬT KHẨU *";
            //
            // ipMatKhau
            //
            this.ipMatKhau.Controls.Add(this.txtMatKhau);
            this.ipMatKhau.Location = new System.Drawing.Point(272, 90);
            this.ipMatKhau.Name = "ipMatKhau";
            this.ipMatKhau.Size = new System.Drawing.Size(220, 42);
            this.ipMatKhau.TabIndex = 2;
            //
            // txtMatKhau
            //
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.TabIndex = 0;
            this.txtMatKhau.UseSystemPasswordChar = true;
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblHoTen.Location = new System.Drawing.Point(28, 144);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(52, 13);
            this.lblHoTen.Text = "HỌ TÊN *";
            //
            // ipHoTen
            //
            this.ipHoTen.Controls.Add(this.txtHoTen);
            this.ipHoTen.Location = new System.Drawing.Point(28, 164);
            this.ipHoTen.Name = "ipHoTen";
            this.ipHoTen.Size = new System.Drawing.Size(464, 42);
            this.ipHoTen.TabIndex = 3;
            //
            // txtHoTen
            //
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.TabIndex = 0;
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblEmail.Location = new System.Drawing.Point(28, 218);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 13);
            this.lblEmail.Text = "EMAIL *";
            //
            // ipEmail
            //
            this.ipEmail.Controls.Add(this.txtEmail);
            this.ipEmail.Location = new System.Drawing.Point(28, 238);
            this.ipEmail.Name = "ipEmail";
            this.ipEmail.Size = new System.Drawing.Size(220, 42);
            this.ipEmail.TabIndex = 4;
            //
            // txtEmail
            //
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TabIndex = 0;
            //
            // lblSoDienThoai
            //
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblSoDienThoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblSoDienThoai.Location = new System.Drawing.Point(272, 218);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(88, 13);
            this.lblSoDienThoai.Text = "SỐ ĐIỆN THOẠI";
            //
            // ipSoDienThoai
            //
            this.ipSoDienThoai.Controls.Add(this.txtSoDienThoai);
            this.ipSoDienThoai.Location = new System.Drawing.Point(272, 238);
            this.ipSoDienThoai.Name = "ipSoDienThoai";
            this.ipSoDienThoai.Size = new System.Drawing.Size(220, 42);
            this.ipSoDienThoai.TabIndex = 5;
            //
            // txtSoDienThoai
            //
            this.txtSoDienThoai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoDienThoai.MaxLength = 15;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.TabIndex = 0;
            //
            // lblVaiTro
            //
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblVaiTro.Location = new System.Drawing.Point(28, 292);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(46, 13);
            this.lblVaiTro.Text = "VAI TRÒ";
            //
            // cboVaiTro
            //
            this.cboVaiTro.Items.AddRange(new object[] {
            "NhanVien",
            "Admin"});
            this.cboVaiTro.Location = new System.Drawing.Point(28, 312);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(220, 40);
            this.cboVaiTro.TabIndex = 6;
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(272, 376);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 44);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy bỏ";
            //
            // btnLuu
            //
            this.btnLuu.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnLuu.Location = new System.Drawing.Point(386, 376);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(106, 44);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            //
            // frmTaiKhoan
            //
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(520, 444);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.cboVaiTro);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.ipSoDienThoai);
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.ipEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.ipHoTen);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.ipMatKhau);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.ipTenDangNhap);
            this.Controls.Add(this.lblTenDangNhap);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaiKhoan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tài khoản";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.ipTenDangNhap.ResumeLayout(false);
            this.ipTenDangNhap.PerformLayout();
            this.ipMatKhau.ResumeLayout(false);
            this.ipMatKhau.PerformLayout();
            this.ipHoTen.ResumeLayout(false);
            this.ipHoTen.PerformLayout();
            this.ipEmail.ResumeLayout(false);
            this.ipEmail.PerformLayout();
            this.ipSoDienThoai.ResumeLayout(false);
            this.ipSoDienThoai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTenDangNhap;
        private QuanLyBanVeMayBay.Controls.InputBox ipTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private QuanLyBanVeMayBay.Controls.InputBox ipMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblHoTen;
        private QuanLyBanVeMayBay.Controls.InputBox ipHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblEmail;
        private QuanLyBanVeMayBay.Controls.InputBox ipEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSoDienThoai;
        private QuanLyBanVeMayBay.Controls.InputBox ipSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblVaiTro;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboVaiTro;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnLuu;
    }
}
