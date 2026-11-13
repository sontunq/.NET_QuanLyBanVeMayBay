namespace QuanLyBanVeMayBay.GUI
{
    partial class frmThanhToan
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblNhan = new System.Windows.Forms.Label();
            this.tlpTien = new System.Windows.Forms.TableLayoutPanel();
            this.lblTienVe = new System.Windows.Forms.Label();
            this.lblTienVeGiaTri = new System.Windows.Forms.Label();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.lblDichVuGiaTri = new System.Windows.Forms.Label();
            this.lblGiam = new System.Windows.Forms.Label();
            this.lblGiamGiaTri = new System.Windows.Forms.Label();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.flpPhuongThuc = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTienMat = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnChuyenKhoan = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnThe = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.ipGhiChu = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblLuuY = new System.Windows.Forms.Label();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnXacNhan = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.pnlHeader.SuspendLayout();
            this.tlpTien.SuspendLayout();
            this.flpPhuongThuc.SuspendLayout();
            this.ipGhiChu.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(104)))), ((int)(((byte)(133)))));
            this.pnlHeader.Controls.Add(this.lblMoTa);
            this.pnlHeader.Controls.Add(this.lblSoTien);
            this.pnlHeader.Controls.Add(this.lblNhan);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 132);
            this.pnlHeader.TabIndex = 0;
            //
            // lblMoTa
            //
            this.lblMoTa.AutoEllipsis = true;
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(243)))));
            this.lblMoTa.Location = new System.Drawing.Point(28, 94);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(424, 22);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "2 vé · Khách hàng";
            //
            // lblSoTien
            //
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI Semibold", 24F);
            this.lblSoTien.ForeColor = System.Drawing.Color.White;
            this.lblSoTien.Location = new System.Drawing.Point(22, 44);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(77, 45);
            this.lblSoTien.TabIndex = 1;
            this.lblSoTien.Text = "0 đ";
            //
            // lblNhan
            //
            this.lblNhan.AutoSize = true;
            this.lblNhan.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.lblNhan.Location = new System.Drawing.Point(28, 24);
            this.lblNhan.Name = "lblNhan";
            this.lblNhan.Size = new System.Drawing.Size(97, 13);
            this.lblNhan.TabIndex = 0;
            this.lblNhan.Text = "THANH TOÁN ĐƠN";
            //
            // tlpTien
            //
            this.tlpTien.ColumnCount = 2;
            this.tlpTien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTien.Controls.Add(this.lblTienVe, 0, 0);
            this.tlpTien.Controls.Add(this.lblTienVeGiaTri, 1, 0);
            this.tlpTien.Controls.Add(this.lblDichVu, 0, 1);
            this.tlpTien.Controls.Add(this.lblDichVuGiaTri, 1, 1);
            this.tlpTien.Controls.Add(this.lblGiam, 0, 2);
            this.tlpTien.Controls.Add(this.lblGiamGiaTri, 1, 2);
            this.tlpTien.Location = new System.Drawing.Point(28, 150);
            this.tlpTien.Name = "tlpTien";
            this.tlpTien.RowCount = 3;
            this.tlpTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTien.Size = new System.Drawing.Size(424, 92);
            this.tlpTien.TabIndex = 1;
            //
            // lblTienVe
            //
            this.lblTienVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTienVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblTienVe.Name = "lblTienVe";
            this.lblTienVe.Text = "Tiền vé";
            this.lblTienVe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblTienVeGiaTri
            //
            this.lblTienVeGiaTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTienVeGiaTri.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTienVeGiaTri.Name = "lblTienVeGiaTri";
            this.lblTienVeGiaTri.Text = "0 đ";
            this.lblTienVeGiaTri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblDichVu
            //
            this.lblDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Text = "Dịch vụ đi kèm";
            this.lblDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblDichVuGiaTri
            //
            this.lblDichVuGiaTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDichVuGiaTri.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDichVuGiaTri.Name = "lblDichVuGiaTri";
            this.lblDichVuGiaTri.Text = "0 đ";
            this.lblDichVuGiaTri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblGiam
            //
            this.lblGiam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblGiam.Name = "lblGiam";
            this.lblGiam.Text = "Đã giảm (khuyến mãi, thành viên)";
            this.lblGiam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblGiamGiaTri
            //
            this.lblGiamGiaTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiamGiaTri.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblGiamGiaTri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(110)))), ((int)(((byte)(67)))));
            this.lblGiamGiaTri.Name = "lblGiamGiaTri";
            this.lblGiamGiaTri.Text = "0 đ";
            this.lblGiamGiaTri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblPhuongThuc
            //
            this.lblPhuongThuc.AutoSize = true;
            this.lblPhuongThuc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblPhuongThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblPhuongThuc.Location = new System.Drawing.Point(28, 260);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(156, 13);
            this.lblPhuongThuc.TabIndex = 2;
            this.lblPhuongThuc.Text = "PHƯƠNG THỨC THANH TOÁN";
            //
            // flpPhuongThuc
            //
            this.flpPhuongThuc.Controls.Add(this.btnTienMat);
            this.flpPhuongThuc.Controls.Add(this.btnChuyenKhoan);
            this.flpPhuongThuc.Controls.Add(this.btnThe);
            this.flpPhuongThuc.Location = new System.Drawing.Point(28, 282);
            this.flpPhuongThuc.Name = "flpPhuongThuc";
            this.flpPhuongThuc.Size = new System.Drawing.Size(430, 48);
            this.flpPhuongThuc.TabIndex = 3;
            this.flpPhuongThuc.WrapContents = false;
            //
            // btnTienMat
            //
            this.btnTienMat.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Primary;
            this.btnTienMat.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnTienMat.Name = "btnTienMat";
            this.btnTienMat.Size = new System.Drawing.Size(134, 44);
            this.btnTienMat.TabIndex = 0;
            this.btnTienMat.Text = "Tiền mặt";
            this.btnTienMat.Click += new System.EventHandler(this.PhuongThuc_Click);
            //
            // btnChuyenKhoan
            //
            this.btnChuyenKhoan.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnChuyenKhoan.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnChuyenKhoan.Name = "btnChuyenKhoan";
            this.btnChuyenKhoan.Size = new System.Drawing.Size(134, 44);
            this.btnChuyenKhoan.TabIndex = 1;
            this.btnChuyenKhoan.Text = "Chuyển khoản";
            this.btnChuyenKhoan.Click += new System.EventHandler(this.PhuongThuc_Click);
            //
            // btnThe
            //
            this.btnThe.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnThe.Margin = new System.Windows.Forms.Padding(0);
            this.btnThe.Name = "btnThe";
            this.btnThe.Size = new System.Drawing.Size(136, 44);
            this.btnThe.TabIndex = 2;
            this.btnThe.Text = "Thẻ";
            this.btnThe.Click += new System.EventHandler(this.PhuongThuc_Click);
            //
            // lblGhiChu
            //
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblGhiChu.Location = new System.Drawing.Point(28, 344);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(50, 13);
            this.lblGhiChu.TabIndex = 4;
            this.lblGhiChu.Text = "GHI CHÚ";
            //
            // ipGhiChu
            //
            this.ipGhiChu.Controls.Add(this.txtGhiChu);
            this.ipGhiChu.Location = new System.Drawing.Point(28, 366);
            this.ipGhiChu.Name = "ipGhiChu";
            this.ipGhiChu.Size = new System.Drawing.Size(424, 44);
            this.ipGhiChu.TabIndex = 5;
            //
            // txtGhiChu
            //
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.PlaceholderText = "Không bắt buộc";
            this.txtGhiChu.TabIndex = 0;
            //
            // lblLuuY
            //
            this.lblLuuY.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblLuuY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblLuuY.Location = new System.Drawing.Point(28, 420);
            this.lblLuuY.Name = "lblLuuY";
            this.lblLuuY.Size = new System.Drawing.Size(424, 40);
            this.lblLuuY.TabIndex = 6;
            this.lblLuuY.Text = "Số tiền thu bằng đúng tổng thanh toán của đơn. Sau khi thanh toán, tổng chi tiêu và hạng thành viên của khách được cập nhật tự động.";
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(164, 470);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 44);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Để sau";
            //
            // btnXacNhan
            //
            this.btnXacNhan.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnXacNhan.Location = new System.Drawing.Point(274, 470);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(178, 44);
            this.btnXacNhan.TabIndex = 7;
            this.btnXacNhan.Text = "Xác nhận thanh toán";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            //
            // frmThanhToan
            //
            this.AcceptButton = this.btnXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(480, 536);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblLuuY);
            this.Controls.Add(this.ipGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.flpPhuongThuc);
            this.Controls.Add(this.lblPhuongThuc);
            this.Controls.Add(this.tlpTien);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThanhToan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpTien.ResumeLayout(false);
            this.flpPhuongThuc.ResumeLayout(false);
            this.ipGhiChu.ResumeLayout(false);
            this.ipGhiChu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNhan;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TableLayoutPanel tlpTien;
        private System.Windows.Forms.Label lblTienVe;
        private System.Windows.Forms.Label lblTienVeGiaTri;
        private System.Windows.Forms.Label lblDichVu;
        private System.Windows.Forms.Label lblDichVuGiaTri;
        private System.Windows.Forms.Label lblGiam;
        private System.Windows.Forms.Label lblGiamGiaTri;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.FlowLayoutPanel flpPhuongThuc;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTienMat;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnChuyenKhoan;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnThe;
        private System.Windows.Forms.Label lblGhiChu;
        private QuanLyBanVeMayBay.Controls.InputBox ipGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblLuuY;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnXacNhan;
    }
}
