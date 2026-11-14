namespace QuanLyBanVeMayBay.GUI
{
    partial class frmHuyVe
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
            this.lblChuyen = new System.Windows.Forms.Label();
            this.lblHanhKhach = new System.Windows.Forms.Label();
            this.lblNhan = new System.Windows.Forms.Label();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblHang = new System.Windows.Forms.Label();
            this.lblHangGiaTri = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblGiaGiaTri = new System.Windows.Forms.Label();
            this.lblDon = new System.Windows.Forms.Label();
            this.lblDonGiaTri = new System.Windows.Forms.Label();
            this.cardPhi = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.lblTienHoan = new System.Windows.Forms.Label();
            this.lblPhiHuy = new System.Windows.Forms.Label();
            this.lblConLai = new System.Windows.Forms.Label();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.ipLyDo = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblLuuY = new System.Windows.Forms.Label();
            this.btnDong = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnHuyVe = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.pnlHeader.SuspendLayout();
            this.tlpThongTin.SuspendLayout();
            this.cardPhi.SuspendLayout();
            this.ipLyDo.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(95)))));
            this.pnlHeader.Controls.Add(this.lblChuyen);
            this.pnlHeader.Controls.Add(this.lblHanhKhach);
            this.pnlHeader.Controls.Add(this.lblNhan);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 116);
            this.pnlHeader.TabIndex = 0;
            //
            // lblChuyen
            //
            this.lblChuyen.AutoEllipsis = true;
            this.lblChuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(243)))));
            this.lblChuyen.Location = new System.Drawing.Point(28, 78);
            this.lblChuyen.Name = "lblChuyen";
            this.lblChuyen.Size = new System.Drawing.Size(424, 22);
            this.lblChuyen.TabIndex = 2;
            this.lblChuyen.Text = "HAN → SGN";
            //
            // lblHanhKhach
            //
            this.lblHanhKhach.AutoEllipsis = true;
            this.lblHanhKhach.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblHanhKhach.ForeColor = System.Drawing.Color.White;
            this.lblHanhKhach.Location = new System.Drawing.Point(24, 42);
            this.lblHanhKhach.Name = "lblHanhKhach";
            this.lblHanhKhach.Size = new System.Drawing.Size(428, 34);
            this.lblHanhKhach.TabIndex = 1;
            this.lblHanhKhach.Text = "Hành khách";
            //
            // lblNhan
            //
            this.lblNhan.AutoSize = true;
            this.lblNhan.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.lblNhan.Location = new System.Drawing.Point(28, 22);
            this.lblNhan.Name = "lblNhan";
            this.lblNhan.Size = new System.Drawing.Size(45, 13);
            this.lblNhan.TabIndex = 0;
            this.lblNhan.Text = "HỦY VÉ";
            //
            // tlpThongTin
            //
            this.tlpThongTin.ColumnCount = 2;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpThongTin.Controls.Add(this.lblHang, 0, 0);
            this.tlpThongTin.Controls.Add(this.lblHangGiaTri, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblGia, 0, 1);
            this.tlpThongTin.Controls.Add(this.lblGiaGiaTri, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblDon, 0, 2);
            this.tlpThongTin.Controls.Add(this.lblDonGiaTri, 1, 2);
            this.tlpThongTin.Location = new System.Drawing.Point(28, 132);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.RowCount = 3;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpThongTin.Size = new System.Drawing.Size(424, 92);
            this.tlpThongTin.TabIndex = 1;
            //
            // lblHang
            //
            this.lblHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblHang.Name = "lblHang";
            this.lblHang.Text = "Ghế / hạng vé";
            this.lblHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblHangGiaTri
            //
            this.lblHangGiaTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHangGiaTri.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblHangGiaTri.Name = "lblHangGiaTri";
            this.lblHangGiaTri.Text = "-";
            this.lblHangGiaTri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblGia
            //
            this.lblGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblGia.Name = "lblGia";
            this.lblGia.Text = "Giá thực trả";
            this.lblGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblGiaGiaTri
            //
            this.lblGiaGiaTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiaGiaTri.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblGiaGiaTri.Name = "lblGiaGiaTri";
            this.lblGiaGiaTri.Text = "0 đ";
            this.lblGiaGiaTri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblDon
            //
            this.lblDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblDon.Name = "lblDon";
            this.lblDon.Text = "Đơn";
            this.lblDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblDonGiaTri
            //
            this.lblDonGiaTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonGiaTri.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDonGiaTri.Name = "lblDonGiaTri";
            this.lblDonGiaTri.Text = "-";
            this.lblDonGiaTri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // cardPhi
            //
            this.cardPhi.BackColor = System.Drawing.Color.White;
            this.cardPhi.Controls.Add(this.lblTienHoan);
            this.cardPhi.Controls.Add(this.lblPhiHuy);
            this.cardPhi.Controls.Add(this.lblConLai);
            this.cardPhi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(225)))));
            this.cardPhi.Location = new System.Drawing.Point(28, 234);
            this.cardPhi.Name = "cardPhi";
            this.cardPhi.Radius = 10;
            this.cardPhi.ShadowSize = 0;
            this.cardPhi.Size = new System.Drawing.Size(424, 98);
            this.cardPhi.TabIndex = 2;
            //
            // lblTienHoan
            //
            this.lblTienHoan.BackColor = System.Drawing.Color.Transparent;
            this.lblTienHoan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTienHoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(110)))), ((int)(((byte)(67)))));
            this.lblTienHoan.Location = new System.Drawing.Point(16, 66);
            this.lblTienHoan.Name = "lblTienHoan";
            this.lblTienHoan.Size = new System.Drawing.Size(392, 22);
            this.lblTienHoan.TabIndex = 2;
            this.lblTienHoan.Text = "Tiền hoàn dự kiến: 0 đ";
            //
            // lblPhiHuy
            //
            this.lblPhiHuy.BackColor = System.Drawing.Color.Transparent;
            this.lblPhiHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblPhiHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(74)))), ((int)(((byte)(0)))));
            this.lblPhiHuy.Location = new System.Drawing.Point(16, 42);
            this.lblPhiHuy.Name = "lblPhiHuy";
            this.lblPhiHuy.Size = new System.Drawing.Size(392, 22);
            this.lblPhiHuy.TabIndex = 1;
            this.lblPhiHuy.Text = "Phí hủy dự kiến: 0 đ";
            //
            // lblConLai
            //
            this.lblConLai.BackColor = System.Drawing.Color.Transparent;
            this.lblConLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.lblConLai.Location = new System.Drawing.Point(16, 14);
            this.lblConLai.Name = "lblConLai";
            this.lblConLai.Size = new System.Drawing.Size(392, 24);
            this.lblConLai.TabIndex = 0;
            this.lblConLai.Text = "Còn ... trước giờ bay";
            //
            // lblLyDo
            //
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblLyDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblLyDo.Location = new System.Drawing.Point(28, 346);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(62, 13);
            this.lblLyDo.TabIndex = 3;
            this.lblLyDo.Text = "LÝ DO HỦY *";
            //
            // ipLyDo
            //
            this.ipLyDo.Controls.Add(this.txtLyDo);
            this.ipLyDo.Location = new System.Drawing.Point(28, 368);
            this.ipLyDo.Name = "ipLyDo";
            this.ipLyDo.Size = new System.Drawing.Size(424, 76);
            this.ipLyDo.TabIndex = 4;
            //
            // txtLyDo
            //
            this.txtLyDo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLyDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.PlaceholderText = "VD: Khách đổi lịch trình";
            this.txtLyDo.TabIndex = 0;
            //
            // lblLuuY
            //
            this.lblLuuY.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblLuuY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblLuuY.Location = new System.Drawing.Point(28, 452);
            this.lblLuuY.Name = "lblLuuY";
            this.lblLuuY.Size = new System.Drawing.Size(424, 38);
            this.lblLuuY.TabIndex = 5;
            this.lblLuuY.Text = "Phí hủy: còn từ 72 giờ trở lên 10% · 24–72 giờ 20% · dưới 24 giờ 30%. Số tiền chính xác do hệ thống tính khi xác nhận.";
            //
            // btnDong
            //
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnDong.Location = new System.Drawing.Point(222, 500);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 44);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "Đóng";
            //
            // btnHuyVe
            //
            this.btnHuyVe.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Danger;
            this.btnHuyVe.Location = new System.Drawing.Point(342, 500);
            this.btnHuyVe.Name = "btnHuyVe";
            this.btnHuyVe.Size = new System.Drawing.Size(110, 44);
            this.btnHuyVe.TabIndex = 6;
            this.btnHuyVe.Text = "Hủy vé";
            this.btnHuyVe.Click += new System.EventHandler(this.btnHuyVe_Click);
            //
            // frmHuyVe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(480, 566);
            this.Controls.Add(this.btnHuyVe);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.lblLuuY);
            this.Controls.Add(this.ipLyDo);
            this.Controls.Add(this.lblLyDo);
            this.Controls.Add(this.cardPhi);
            this.Controls.Add(this.tlpThongTin);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHuyVe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hủy vé";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpThongTin.ResumeLayout(false);
            this.cardPhi.ResumeLayout(false);
            this.ipLyDo.ResumeLayout(false);
            this.ipLyDo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNhan;
        private System.Windows.Forms.Label lblHanhKhach;
        private System.Windows.Forms.Label lblChuyen;
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
        private System.Windows.Forms.Label lblHang;
        private System.Windows.Forms.Label lblHangGiaTri;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblGiaGiaTri;
        private System.Windows.Forms.Label lblDon;
        private System.Windows.Forms.Label lblDonGiaTri;
        private QuanLyBanVeMayBay.Controls.CardPanel cardPhi;
        private System.Windows.Forms.Label lblConLai;
        private System.Windows.Forms.Label lblPhiHuy;
        private System.Windows.Forms.Label lblTienHoan;
        private System.Windows.Forms.Label lblLyDo;
        private QuanLyBanVeMayBay.Controls.InputBox ipLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblLuuY;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnDong;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuyVe;
    }
}
