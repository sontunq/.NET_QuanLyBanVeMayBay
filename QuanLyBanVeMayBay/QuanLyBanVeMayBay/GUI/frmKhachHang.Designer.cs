namespace QuanLyBanVeMayBay.GUI
{
    partial class frmKhachHang
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
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.ipHoTen = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblLoaiGiayTo = new System.Windows.Forms.Label();
            this.cboLoaiGiayTo = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.lblSoGiayTo = new System.Windows.Forms.Label();
            this.ipSoGiayTo = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtSoGiayTo = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.ipSoDienThoai = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.ipEmail = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.ipDiaChi = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblLuuY = new System.Windows.Forms.Label();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnLuu = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.ipHoTen.SuspendLayout();
            this.ipSoGiayTo.SuspendLayout();
            this.ipSoDienThoai.SuspendLayout();
            this.ipEmail.SuspendLayout();
            this.ipDiaChi.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(172, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Thêm khách hàng";
            //
            // lblMoTa
            //
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblMoTa.Location = new System.Drawing.Point(27, 52);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(292, 19);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text = "Thông tin dùng để xuất vé và tích lũy hạng thành viên";
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblHoTen.Location = new System.Drawing.Point(28, 92);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(52, 13);
            this.lblHoTen.Text = "HỌ TÊN *";
            //
            // ipHoTen
            //
            this.ipHoTen.Controls.Add(this.txtHoTen);
            this.ipHoTen.Location = new System.Drawing.Point(28, 112);
            this.ipHoTen.Name = "ipHoTen";
            this.ipHoTen.Size = new System.Drawing.Size(464, 42);
            this.ipHoTen.TabIndex = 2;
            //
            // txtHoTen
            //
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.TabIndex = 0;
            //
            // lblLoaiGiayTo
            //
            this.lblLoaiGiayTo.AutoSize = true;
            this.lblLoaiGiayTo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblLoaiGiayTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblLoaiGiayTo.Location = new System.Drawing.Point(28, 166);
            this.lblLoaiGiayTo.Name = "lblLoaiGiayTo";
            this.lblLoaiGiayTo.Size = new System.Drawing.Size(81, 13);
            this.lblLoaiGiayTo.Text = "LOẠI GIẤY TỜ";
            //
            // cboLoaiGiayTo
            //
            this.cboLoaiGiayTo.Items.AddRange(new object[] {
            "CCCD",
            "Hộ chiếu",
            "Giấy khai sinh"});
            this.cboLoaiGiayTo.Location = new System.Drawing.Point(28, 186);
            this.cboLoaiGiayTo.Name = "cboLoaiGiayTo";
            this.cboLoaiGiayTo.Size = new System.Drawing.Size(220, 40);
            this.cboLoaiGiayTo.TabIndex = 3;
            //
            // lblSoGiayTo
            //
            this.lblSoGiayTo.AutoSize = true;
            this.lblSoGiayTo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblSoGiayTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblSoGiayTo.Location = new System.Drawing.Point(272, 166);
            this.lblSoGiayTo.Name = "lblSoGiayTo";
            this.lblSoGiayTo.Size = new System.Drawing.Size(80, 13);
            this.lblSoGiayTo.Text = "SỐ GIẤY TỜ *";
            //
            // ipSoGiayTo
            //
            this.ipSoGiayTo.Controls.Add(this.txtSoGiayTo);
            this.ipSoGiayTo.Location = new System.Drawing.Point(272, 186);
            this.ipSoGiayTo.Name = "ipSoGiayTo";
            this.ipSoGiayTo.Size = new System.Drawing.Size(220, 42);
            this.ipSoGiayTo.TabIndex = 4;
            //
            // txtSoGiayTo
            //
            this.txtSoGiayTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoGiayTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoGiayTo.MaxLength = 20;
            this.txtSoGiayTo.Name = "txtSoGiayTo";
            this.txtSoGiayTo.TabIndex = 0;
            //
            // lblNgaySinh
            //
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblNgaySinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblNgaySinh.Location = new System.Drawing.Point(28, 240);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(67, 13);
            this.lblNgaySinh.Text = "NGÀY SINH";
            //
            // dtpNgaySinh
            //
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(28, 262);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(220, 27);
            this.dtpNgaySinh.TabIndex = 5;
            //
            // lblGioiTinh
            //
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblGioiTinh.Location = new System.Drawing.Point(272, 240);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(63, 13);
            this.lblGioiTinh.Text = "GIỚI TÍNH";
            //
            // cboGioiTinh
            //
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioiTinh.Location = new System.Drawing.Point(272, 260);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(220, 40);
            this.cboGioiTinh.TabIndex = 6;
            //
            // lblSoDienThoai
            //
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblSoDienThoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblSoDienThoai.Location = new System.Drawing.Point(28, 314);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(88, 13);
            this.lblSoDienThoai.Text = "SỐ ĐIỆN THOẠI";
            //
            // ipSoDienThoai
            //
            this.ipSoDienThoai.Controls.Add(this.txtSoDienThoai);
            this.ipSoDienThoai.Location = new System.Drawing.Point(28, 334);
            this.ipSoDienThoai.Name = "ipSoDienThoai";
            this.ipSoDienThoai.Size = new System.Drawing.Size(220, 42);
            this.ipSoDienThoai.TabIndex = 7;
            //
            // txtSoDienThoai
            //
            this.txtSoDienThoai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoDienThoai.MaxLength = 15;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.TabIndex = 0;
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblEmail.Location = new System.Drawing.Point(272, 314);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 13);
            this.lblEmail.Text = "EMAIL";
            //
            // ipEmail
            //
            this.ipEmail.Controls.Add(this.txtEmail);
            this.ipEmail.Location = new System.Drawing.Point(272, 334);
            this.ipEmail.Name = "ipEmail";
            this.ipEmail.Size = new System.Drawing.Size(220, 42);
            this.ipEmail.TabIndex = 8;
            //
            // txtEmail
            //
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TabIndex = 0;
            //
            // lblDiaChi
            //
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblDiaChi.Location = new System.Drawing.Point(28, 388);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(48, 13);
            this.lblDiaChi.Text = "ĐỊA CHỈ";
            //
            // ipDiaChi
            //
            this.ipDiaChi.Controls.Add(this.txtDiaChi);
            this.ipDiaChi.Location = new System.Drawing.Point(28, 408);
            this.ipDiaChi.Name = "ipDiaChi";
            this.ipDiaChi.Size = new System.Drawing.Size(464, 42);
            this.ipDiaChi.TabIndex = 9;
            //
            // txtDiaChi
            //
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiaChi.MaxLength = 200;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.TabIndex = 0;
            //
            // lblLuuY
            //
            this.lblLuuY.AutoSize = true;
            this.lblLuuY.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblLuuY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblLuuY.Location = new System.Drawing.Point(28, 462);
            this.lblLuuY.Name = "lblLuuY";
            this.lblLuuY.Size = new System.Drawing.Size(360, 15);
            this.lblLuuY.Text = "Hành khách dưới 16 tuổi khi bay cần người giám hộ từ 18 tuổi trở lên.";
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(272, 494);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 44);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy bỏ";
            //
            // btnLuu
            //
            this.btnLuu.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnLuu.Location = new System.Drawing.Point(386, 494);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(106, 44);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            //
            // frmKhachHang
            //
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(520, 560);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblLuuY);
            this.Controls.Add(this.ipDiaChi);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.ipEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.ipSoDienThoai);
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.ipSoGiayTo);
            this.Controls.Add(this.lblSoGiayTo);
            this.Controls.Add(this.cboLoaiGiayTo);
            this.Controls.Add(this.lblLoaiGiayTo);
            this.Controls.Add(this.ipHoTen);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhachHang";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Khách hàng";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            this.ipHoTen.ResumeLayout(false);
            this.ipHoTen.PerformLayout();
            this.ipSoGiayTo.ResumeLayout(false);
            this.ipSoGiayTo.PerformLayout();
            this.ipSoDienThoai.ResumeLayout(false);
            this.ipSoDienThoai.PerformLayout();
            this.ipEmail.ResumeLayout(false);
            this.ipEmail.PerformLayout();
            this.ipDiaChi.ResumeLayout(false);
            this.ipDiaChi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblHoTen;
        private QuanLyBanVeMayBay.Controls.InputBox ipHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblLoaiGiayTo;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboLoaiGiayTo;
        private System.Windows.Forms.Label lblSoGiayTo;
        private QuanLyBanVeMayBay.Controls.InputBox ipSoGiayTo;
        private System.Windows.Forms.TextBox txtSoGiayTo;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblSoDienThoai;
        private QuanLyBanVeMayBay.Controls.InputBox ipSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private QuanLyBanVeMayBay.Controls.InputBox ipEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private QuanLyBanVeMayBay.Controls.InputBox ipDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblLuuY;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnLuu;
    }
}
