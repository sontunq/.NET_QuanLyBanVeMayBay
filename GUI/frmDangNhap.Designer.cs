namespace QuanLyBanVeMayBay.GUI
{
    partial class frmDangNhap
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
            this.bannerDangNhap = new QuanLyBanVeMayBay.Controls.LoginBanner();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblGoiY = new System.Windows.Forms.Label();
            this.lblLoi = new System.Windows.Forms.Label();
            this.btnDangNhap = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.chkGhiNho = new System.Windows.Forms.CheckBox();
            this.ipMatKhau = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.ipTaiKhoan = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.ipMayChu = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtMayChu = new System.Windows.Forms.TextBox();
            this.lblMayChu = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlForm.SuspendLayout();
            this.ipMatKhau.SuspendLayout();
            this.ipTaiKhoan.SuspendLayout();
            this.ipMayChu.SuspendLayout();
            this.SuspendLayout();
            //
            // bannerDangNhap
            //
            this.bannerDangNhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.bannerDangNhap.Location = new System.Drawing.Point(0, 0);
            this.bannerDangNhap.Name = "bannerDangNhap";
            this.bannerDangNhap.Size = new System.Drawing.Size(500, 620);
            this.bannerDangNhap.TabIndex = 0;
            this.bannerDangNhap.TabStop = false;
            //
            // pnlForm
            //
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblGoiY);
            this.pnlForm.Controls.Add(this.lblLoi);
            this.pnlForm.Controls.Add(this.btnDangNhap);
            this.pnlForm.Controls.Add(this.chkGhiNho);
            this.pnlForm.Controls.Add(this.ipMatKhau);
            this.pnlForm.Controls.Add(this.lblMatKhau);
            this.pnlForm.Controls.Add(this.ipTaiKhoan);
            this.pnlForm.Controls.Add(this.lblTaiKhoan);
            this.pnlForm.Controls.Add(this.ipMayChu);
            this.pnlForm.Controls.Add(this.lblMayChu);
            this.pnlForm.Controls.Add(this.lblMoTa);
            this.pnlForm.Controls.Add(this.lblTieuDe);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(500, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(500, 620);
            this.pnlForm.TabIndex = 1;
            //
            // lblGoiY
            //
            this.lblGoiY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.lblGoiY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGoiY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.lblGoiY.Location = new System.Drawing.Point(70, 548);
            this.lblGoiY.Name = "lblGoiY";
            this.lblGoiY.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblGoiY.Size = new System.Drawing.Size(360, 36);
            this.lblGoiY.TabIndex = 11;
            this.lblGoiY.Text = "Tài khoản mẫu:  admin / admin123   ·   nv01 / 123456";
            this.lblGoiY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblLoi
            //
            this.lblLoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(35)))), ((int)(((byte)(24)))));
            this.lblLoi.Location = new System.Drawing.Point(70, 502);
            this.lblLoi.Name = "lblLoi";
            this.lblLoi.Size = new System.Drawing.Size(360, 40);
            this.lblLoi.TabIndex = 10;
            //
            // btnDangNhap
            //
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnDangNhap.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnDangNhap.Location = new System.Drawing.Point(70, 446);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(360, 50);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            //
            // chkGhiNho
            //
            this.chkGhiNho.AutoSize = true;
            this.chkGhiNho.Checked = true;
            this.chkGhiNho.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGhiNho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.chkGhiNho.Location = new System.Drawing.Point(72, 408);
            this.chkGhiNho.Name = "chkGhiNho";
            this.chkGhiNho.Size = new System.Drawing.Size(145, 23);
            this.chkGhiNho.TabIndex = 3;
            this.chkGhiNho.Text = "Ghi nhớ máy chủ";
            this.chkGhiNho.UseVisualStyleBackColor = true;
            //
            // ipMatKhau
            //
            this.ipMatKhau.Controls.Add(this.txtMatKhau);
            this.ipMatKhau.Location = new System.Drawing.Point(70, 354);
            this.ipMatKhau.Name = "ipMatKhau";
            this.ipMatKhau.Size = new System.Drawing.Size(360, 44);
            this.ipMatKhau.TabIndex = 2;
            //
            // txtMatKhau
            //
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.TabIndex = 0;
            this.txtMatKhau.UseSystemPasswordChar = true;
            //
            // lblMatKhau
            //
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblMatKhau.Location = new System.Drawing.Point(70, 333);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(67, 13);
            this.lblMatKhau.TabIndex = 9;
            this.lblMatKhau.Text = "MẬT KHẨU";
            //
            // ipTaiKhoan
            //
            this.ipTaiKhoan.Controls.Add(this.txtTaiKhoan);
            this.ipTaiKhoan.Location = new System.Drawing.Point(70, 274);
            this.ipTaiKhoan.Name = "ipTaiKhoan";
            this.ipTaiKhoan.Size = new System.Drawing.Size(360, 44);
            this.ipTaiKhoan.TabIndex = 1;
            //
            // txtTaiKhoan
            //
            this.txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.TabIndex = 0;
            //
            // lblTaiKhoan
            //
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblTaiKhoan.Location = new System.Drawing.Point(70, 253);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(98, 13);
            this.lblTaiKhoan.TabIndex = 8;
            this.lblTaiKhoan.Text = "TÊN ĐĂNG NHẬP";
            //
            // ipMayChu
            //
            this.ipMayChu.Controls.Add(this.txtMayChu);
            this.ipMayChu.Location = new System.Drawing.Point(70, 194);
            this.ipMayChu.Name = "ipMayChu";
            this.ipMayChu.Size = new System.Drawing.Size(360, 44);
            this.ipMayChu.TabIndex = 0;
            //
            // txtMayChu
            //
            this.txtMayChu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMayChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMayChu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMayChu.Name = "txtMayChu";
            this.txtMayChu.PlaceholderText = ".  hoặc  .\\SQLEXPRESS";
            this.txtMayChu.TabIndex = 0;
            //
            // lblMayChu
            //
            this.lblMayChu.AutoSize = true;
            this.lblMayChu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblMayChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblMayChu.Location = new System.Drawing.Point(70, 173);
            this.lblMayChu.Name = "lblMayChu";
            this.lblMayChu.Size = new System.Drawing.Size(121, 13);
            this.lblMayChu.TabIndex = 7;
            this.lblMayChu.Text = "MÁY CHỦ SQL SERVER";
            //
            // lblMoTa
            //
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblMoTa.Location = new System.Drawing.Point(71, 122);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(282, 19);
            this.lblMoTa.TabIndex = 6;
            this.lblMoTa.Text = "Kết nối tới cơ sở dữ liệu QuanLyBanVeMayBay2";
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.lblTieuDe.Location = new System.Drawing.Point(66, 76);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(165, 41);
            this.lblTieuDe.TabIndex = 5;
            this.lblTieuDe.Text = "Đăng nhập";
            //
            // frmDangNhap
            //
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.bannerDangNhap);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Quản lý bán vé máy bay";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ipMatKhau.ResumeLayout(false);
            this.ipMatKhau.PerformLayout();
            this.ipTaiKhoan.ResumeLayout(false);
            this.ipTaiKhoan.PerformLayout();
            this.ipMayChu.ResumeLayout(false);
            this.ipMayChu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private QuanLyBanVeMayBay.Controls.LoginBanner bannerDangNhap;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblMayChu;
        private QuanLyBanVeMayBay.Controls.InputBox ipMayChu;
        private System.Windows.Forms.TextBox txtMayChu;
        private System.Windows.Forms.Label lblTaiKhoan;
        private QuanLyBanVeMayBay.Controls.InputBox ipTaiKhoan;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private QuanLyBanVeMayBay.Controls.InputBox ipMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.CheckBox chkGhiNho;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnDangNhap;
        private System.Windows.Forms.Label lblLoi;
        private System.Windows.Forms.Label lblGoiY;
    }
}
