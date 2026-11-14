namespace QuanLyBanVeMayBay.GUI
{
    partial class frmThemDichVu
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
            this.lblDichVu = new System.Windows.Forms.Label();
            this.cboDichVu = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblThanhTienNhan = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnThem = new QuanLyBanVeMayBay.Controls.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(150, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Thêm dịch vụ";
            //
            // lblMoTa
            //
            this.lblMoTa.AutoEllipsis = true;
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblMoTa.Location = new System.Drawing.Point(27, 52);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(400, 20);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text = "Vé #";
            //
            // lblDichVu
            //
            this.lblDichVu.AutoSize = true;
            this.lblDichVu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblDichVu.Location = new System.Drawing.Point(28, 92);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(51, 13);
            this.lblDichVu.Text = "DỊCH VỤ";
            //
            // cboDichVu
            //
            this.cboDichVu.Location = new System.Drawing.Point(28, 112);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(400, 40);
            this.cboDichVu.TabIndex = 2;
            this.cboDichVu.SelectedIndexChanged += new System.EventHandler(this.TinhThanhTien);
            //
            // lblSoLuong
            //
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblSoLuong.Location = new System.Drawing.Point(28, 168);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(61, 13);
            this.lblSoLuong.Text = "SỐ LƯỢNG";
            //
            // nudSoLuong
            //
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudSoLuong.Location = new System.Drawing.Point(28, 190);
            this.nudSoLuong.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(120, 27);
            this.nudSoLuong.TabIndex = 3;
            this.nudSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.ValueChanged += new System.EventHandler(this.TinhThanhTien);
            //
            // lblThanhTienNhan
            //
            this.lblThanhTienNhan.AutoSize = true;
            this.lblThanhTienNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblThanhTienNhan.Location = new System.Drawing.Point(196, 194);
            this.lblThanhTienNhan.Name = "lblThanhTienNhan";
            this.lblThanhTienNhan.Size = new System.Drawing.Size(73, 19);
            this.lblThanhTienNhan.Text = "Thành tiền";
            //
            // lblThanhTien
            //
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblThanhTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(106)))), ((int)(((byte)(31)))));
            this.lblThanhTien.Location = new System.Drawing.Point(268, 186);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(160, 32);
            this.lblThanhTien.Text = "0 đ";
            this.lblThanhTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(208, 248);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 44);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy bỏ";
            //
            // btnThem
            //
            this.btnThem.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnThem.Location = new System.Drawing.Point(322, 248);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(106, 44);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // frmThemDichVu
            //
            this.AcceptButton = this.btnThem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(456, 316);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.lblThanhTienNhan);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.cboDichVu);
            this.Controls.Add(this.lblDichVu);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemDichVu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dịch vụ";
            this.Load += new System.EventHandler(this.frmThemDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblDichVu;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboDichVu;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblThanhTienNhan;
        private System.Windows.Forms.Label lblThanhTien;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnThem;
    }
}
