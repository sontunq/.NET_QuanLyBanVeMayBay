namespace QuanLyBanVeMayBay.GUI
{
    partial class frmMain
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNghiepVu = new System.Windows.Forms.Label();
            this.btnTongQuan = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.btnDatVe = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.btnDonDatVe = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.btnTraCuu = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.btnKhachHang = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.lblQuanLy = new System.Windows.Forms.Label();
            this.btnChuyenBay = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.btnMayBay = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.btnBaoCao = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.btnTaiKhoan = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.btnNhatKy = new QuanLyBanVeMayBay.Controls.SidebarButton();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.btnDangXuat = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblTieuDeTrang = new System.Windows.Forms.Label();
            this.lblDuongDan = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.timerGio = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.flpMenu.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlSidebar
            //
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(95)))));
            this.pnlSidebar.Controls.Add(this.flpMenu);
            this.pnlSidebar.Controls.Add(this.pnlUser);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(248, 861);
            this.pnlSidebar.TabIndex = 0;
            //
            // flpMenu
            //
            this.flpMenu.AutoScroll = true;
            this.flpMenu.Controls.Add(this.lblNghiepVu);
            this.flpMenu.Controls.Add(this.btnTongQuan);
            this.flpMenu.Controls.Add(this.btnDatVe);
            this.flpMenu.Controls.Add(this.btnDonDatVe);
            this.flpMenu.Controls.Add(this.btnTraCuu);
            this.flpMenu.Controls.Add(this.btnKhachHang);
            this.flpMenu.Controls.Add(this.lblQuanLy);
            this.flpMenu.Controls.Add(this.btnChuyenBay);
            this.flpMenu.Controls.Add(this.btnMayBay);
            this.flpMenu.Controls.Add(this.btnBaoCao);
            this.flpMenu.Controls.Add(this.btnTaiKhoan);
            this.flpMenu.Controls.Add(this.btnNhatKy);
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMenu.Location = new System.Drawing.Point(0, 88);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(248, 645);
            this.flpMenu.TabIndex = 1;
            this.flpMenu.WrapContents = false;
            //
            // lblNghiepVu
            //
            this.lblNghiepVu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblNghiepVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(204)))), ((int)(((byte)(212)))));
            this.lblNghiepVu.Location = new System.Drawing.Point(0, 0);
            this.lblNghiepVu.Margin = new System.Windows.Forms.Padding(0);
            this.lblNghiepVu.Name = "lblNghiepVu";
            this.lblNghiepVu.Padding = new System.Windows.Forms.Padding(24, 0, 0, 6);
            this.lblNghiepVu.Size = new System.Drawing.Size(248, 34);
            this.lblNghiepVu.TabIndex = 0;
            this.lblNghiepVu.Text = "NGHIỆP VỤ";
            this.lblNghiepVu.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // btnTongQuan
            //
            this.btnTongQuan.Glyph = "";
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.TabIndex = 1;
            this.btnTongQuan.Text = "Tổng quan";
            this.btnTongQuan.Click += new System.EventHandler(this.Menu_Click);
            //
            // btnDatVe
            //
            this.btnDatVe.Glyph = "";
            this.btnDatVe.Name = "btnDatVe";
            this.btnDatVe.TabIndex = 2;
            this.btnDatVe.Text = "Đặt vé";
            this.btnDatVe.Click += new System.EventHandler(this.Menu_Click);
            //
            // btnDonDatVe
            //
            this.btnDonDatVe.Glyph = "";
            this.btnDonDatVe.Name = "btnDonDatVe";
            this.btnDonDatVe.TabIndex = 3;
            this.btnDonDatVe.Text = "Đơn đặt vé";
            this.btnDonDatVe.Click += new System.EventHandler(this.Menu_Click);
            //
            // btnTraCuu
            //
            this.btnTraCuu.Glyph = "";
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.TabIndex = 4;
            this.btnTraCuu.Text = "Tra cứu & hủy vé";
            this.btnTraCuu.Click += new System.EventHandler(this.Menu_Click);
            //
            // btnKhachHang
            //
            this.btnKhachHang.Glyph = "";
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.TabIndex = 5;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.Click += new System.EventHandler(this.Menu_Click);
            //
            // lblQuanLy
            //
            this.lblQuanLy.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblQuanLy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(204)))), ((int)(((byte)(212)))));
            this.lblQuanLy.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblQuanLy.Name = "lblQuanLy";
            this.lblQuanLy.Padding = new System.Windows.Forms.Padding(24, 0, 0, 6);
            this.lblQuanLy.Size = new System.Drawing.Size(248, 34);
            this.lblQuanLy.TabIndex = 6;
            this.lblQuanLy.Text = "QUẢN LÝ";
            this.lblQuanLy.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // btnChuyenBay
            //
            this.btnChuyenBay.Glyph = "";
            this.btnChuyenBay.Name = "btnChuyenBay";
            this.btnChuyenBay.TabIndex = 7;
            this.btnChuyenBay.Text = "Chuyến bay";
            this.btnChuyenBay.Click += new System.EventHandler(this.Menu_Click);
            //
            // btnMayBay
            //
            this.btnMayBay.Glyph = "";
            this.btnMayBay.Name = "btnMayBay";
            this.btnMayBay.TabIndex = 8;
            this.btnMayBay.Text = "Máy bay";
            this.btnMayBay.Click += new System.EventHandler(this.Menu_Click);
            //
            // btnBaoCao
            //
            this.btnBaoCao.Glyph = "";
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.TabIndex = 9;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.Click += new System.EventHandler(this.Menu_Click);
            //
            // btnTaiKhoan
            //
            this.btnTaiKhoan.Glyph = "";
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.TabIndex = 10;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.Click += new System.EventHandler(this.Menu_Click);
            //
            // btnNhatKy
            //
            this.btnNhatKy.Glyph = "";
            this.btnNhatKy.Name = "btnNhatKy";
            this.btnNhatKy.TabIndex = 11;
            this.btnNhatKy.Text = "Nhật ký";
            this.btnNhatKy.Click += new System.EventHandler(this.Menu_Click);
            //
            // pnlUser
            //
            this.pnlUser.Controls.Add(this.btnDangXuat);
            this.pnlUser.Controls.Add(this.lblVaiTro);
            this.pnlUser.Controls.Add(this.lblHoTen);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUser.Location = new System.Drawing.Point(0, 733);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(248, 128);
            this.pnlUser.TabIndex = 2;
            this.pnlUser.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUser_Paint);
            //
            // btnDangXuat
            //
            this.btnDangXuat.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Dark;
            this.btnDangXuat.Location = new System.Drawing.Point(24, 72);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(200, 40);
            this.btnDangXuat.TabIndex = 0;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            //
            // lblVaiTro
            //
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(204)))), ((int)(((byte)(212)))));
            this.lblVaiTro.Location = new System.Drawing.Point(72, 36);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(84, 15);
            this.lblVaiTro.TabIndex = 2;
            this.lblVaiTro.Text = "Quản trị viên";
            //
            // lblHoTen
            //
            this.lblHoTen.AutoEllipsis = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblHoTen.ForeColor = System.Drawing.Color.White;
            this.lblHoTen.Location = new System.Drawing.Point(72, 14);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(160, 20);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ tên";
            //
            // pnlLogo
            //
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(248, 88);
            this.pnlLogo.TabIndex = 0;
            this.pnlLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogo_Paint);
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblNgay);
            this.pnlHeader.Controls.Add(this.lblTieuDeTrang);
            this.pnlHeader.Controls.Add(this.lblDuongDan);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(248, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1176, 84);
            this.pnlHeader.TabIndex = 1;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            //
            // lblNgay
            //
            this.lblNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.lblNgay.Location = new System.Drawing.Point(856, 30);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(290, 24);
            this.lblNgay.TabIndex = 2;
            this.lblNgay.Text = "Thứ 3, 03/11/2026  ·  12:00";
            this.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblTieuDeTrang
            //
            this.lblTieuDeTrang.AutoSize = true;
            this.lblTieuDeTrang.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblTieuDeTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.lblTieuDeTrang.Location = new System.Drawing.Point(24, 34);
            this.lblTieuDeTrang.Name = "lblTieuDeTrang";
            this.lblTieuDeTrang.Size = new System.Drawing.Size(124, 32);
            this.lblTieuDeTrang.TabIndex = 1;
            this.lblTieuDeTrang.Text = "Tổng quan";
            //
            // lblDuongDan
            //
            this.lblDuongDan.AutoSize = true;
            this.lblDuongDan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDuongDan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblDuongDan.Location = new System.Drawing.Point(27, 14);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Size = new System.Drawing.Size(124, 15);
            this.lblDuongDan.TabIndex = 0;
            this.lblDuongDan.Text = "Nghiệp vụ  /  Tổng quan";
            //
            // pnlContent
            //
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(248, 84);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(18, 16, 18, 14);
            this.pnlContent.Size = new System.Drawing.Size(1176, 777);
            this.pnlContent.TabIndex = 2;
            //
            // timerGio
            //
            this.timerGio.Interval = 30000;
            this.timerGio.Tick += new System.EventHandler(this.timerGio_Tick);
            //
            // frmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1424, 861);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán vé máy bay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.pnlSidebar.ResumeLayout(false);
            this.flpMenu.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Label lblNghiepVu;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnTongQuan;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnDatVe;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnDonDatVe;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnTraCuu;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnKhachHang;
        private System.Windows.Forms.Label lblQuanLy;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnChuyenBay;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnMayBay;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnBaoCao;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnTaiKhoan;
        private QuanLyBanVeMayBay.Controls.SidebarButton btnNhatKy;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblVaiTro;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnDangXuat;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDuongDan;
        private System.Windows.Forms.Label lblTieuDeTrang;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Timer timerGio;
    }
}
