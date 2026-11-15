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
            this.clbDichVu = new System.Windows.Forms.CheckedListBox();
            this.lblGhiChuDV = new System.Windows.Forms.Label();
            this.lblThanhTienNhan = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnThem = new QuanLyBanVeMayBay.Controls.RoundedButton();
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
            this.lblDichVu.Text = "CHỌN DỊCH VỤ";
            //
            // clbDichVu
            //
            this.clbDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbDichVu.CheckOnClick = true;
            this.clbDichVu.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.clbDichVu.FormattingEnabled = true;
            this.clbDichVu.IntegralHeight = false;
            this.clbDichVu.Location = new System.Drawing.Point(28, 112);
            this.clbDichVu.Name = "clbDichVu";
            this.clbDichVu.Size = new System.Drawing.Size(400, 230);
            this.clbDichVu.TabIndex = 2;
            this.clbDichVu.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbDichVu_ItemCheck);
            //
            // lblGhiChuDV
            //
            this.lblGhiChuDV.AutoSize = true;
            this.lblGhiChuDV.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblGhiChuDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblGhiChuDV.Location = new System.Drawing.Point(28, 348);
            this.lblGhiChuDV.Name = "lblGhiChuDV";
            this.lblGhiChuDV.Text = "Tick các dịch vụ cần thêm. Dịch vụ \"(đã có)\" là vé đã đăng ký trước đó.";
            //
            // lblThanhTienNhan
            //
            this.lblThanhTienNhan.AutoSize = true;
            this.lblThanhTienNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblThanhTienNhan.Location = new System.Drawing.Point(28, 384);
            this.lblThanhTienNhan.Name = "lblThanhTienNhan";
            this.lblThanhTienNhan.Size = new System.Drawing.Size(180, 19);
            this.lblThanhTienNhan.Text = "Thành tiền dịch vụ đã chọn";
            //
            // lblThanhTien
            //
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblThanhTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(106)))), ((int)(((byte)(31)))));
            this.lblThanhTien.Location = new System.Drawing.Point(228, 376);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(200, 32);
            this.lblThanhTien.Text = "0 đ";
            this.lblThanhTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(208, 428);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 44);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy bỏ";
            //
            // btnThem
            //
            this.btnThem.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnThem.Location = new System.Drawing.Point(322, 428);
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
            this.ClientSize = new System.Drawing.Size(456, 496);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.lblThanhTienNhan);
            this.Controls.Add(this.lblGhiChuDV);
            this.Controls.Add(this.clbDichVu);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblDichVu;
        private System.Windows.Forms.CheckedListBox clbDichVu;
        private System.Windows.Forms.Label lblGhiChuDV;
        private System.Windows.Forms.Label lblThanhTienNhan;
        private System.Windows.Forms.Label lblThanhTien;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnThem;
    }
}
