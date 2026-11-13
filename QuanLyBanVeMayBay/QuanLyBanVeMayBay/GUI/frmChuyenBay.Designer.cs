namespace QuanLyBanVeMayBay.GUI
{
    partial class frmChuyenBay
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
            this.lblMayBay = new System.Windows.Forms.Label();
            this.cboMayBay = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.lblSanBayDi = new System.Windows.Forms.Label();
            this.cboSanBayDi = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.lblSanBayDen = new System.Windows.Forms.Label();
            this.cboSanBayDen = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.lblKhoiHanh = new System.Windows.Forms.Label();
            this.dtpKhoiHanh = new System.Windows.Forms.DateTimePicker();
            this.lblThoiGianBay = new System.Windows.Forms.Label();
            this.nudThoiGianBay = new System.Windows.Forms.NumericUpDown();
            this.lblGiaPT = new System.Windows.Forms.Label();
            this.nudGiaPT = new System.Windows.Forms.NumericUpDown();
            this.lblGiaPTDB = new System.Windows.Forms.Label();
            this.nudGiaPTDB = new System.Windows.Forms.NumericUpDown();
            this.lblGiaTG = new System.Windows.Forms.Label();
            this.nudGiaTG = new System.Windows.Forms.NumericUpDown();
            this.lblLuuY = new System.Windows.Forms.Label();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnTao = new QuanLyBanVeMayBay.Controls.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGianBay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaPTDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaTG)).BeginInit();
            this.SuspendLayout();
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(161, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Tạo chuyến bay";
            //
            // lblMoTa
            //
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblMoTa.Location = new System.Drawing.Point(27, 52);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(390, 19);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text = "Hệ thống tự tạo bảng giá và sơ đồ ghế trống cho chuyến bay";
            //
            // lblMayBay
            //
            this.lblMayBay.AutoSize = true;
            this.lblMayBay.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblMayBay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblMayBay.Location = new System.Drawing.Point(28, 92);
            this.lblMayBay.Name = "lblMayBay";
            this.lblMayBay.Size = new System.Drawing.Size(55, 13);
            this.lblMayBay.Text = "MÁY BAY";
            //
            // cboMayBay
            //
            this.cboMayBay.Location = new System.Drawing.Point(28, 112);
            this.cboMayBay.Name = "cboMayBay";
            this.cboMayBay.Size = new System.Drawing.Size(484, 40);
            this.cboMayBay.TabIndex = 2;
            //
            // lblSanBayDi
            //
            this.lblSanBayDi.AutoSize = true;
            this.lblSanBayDi.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblSanBayDi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblSanBayDi.Location = new System.Drawing.Point(28, 166);
            this.lblSanBayDi.Name = "lblSanBayDi";
            this.lblSanBayDi.Size = new System.Drawing.Size(68, 13);
            this.lblSanBayDi.Text = "SÂN BAY ĐI";
            //
            // cboSanBayDi
            //
            this.cboSanBayDi.Location = new System.Drawing.Point(28, 186);
            this.cboSanBayDi.Name = "cboSanBayDi";
            this.cboSanBayDi.Size = new System.Drawing.Size(232, 40);
            this.cboSanBayDi.TabIndex = 3;
            //
            // lblSanBayDen
            //
            this.lblSanBayDen.AutoSize = true;
            this.lblSanBayDen.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblSanBayDen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblSanBayDen.Location = new System.Drawing.Point(280, 166);
            this.lblSanBayDen.Name = "lblSanBayDen";
            this.lblSanBayDen.Size = new System.Drawing.Size(77, 13);
            this.lblSanBayDen.Text = "SÂN BAY ĐẾN";
            //
            // cboSanBayDen
            //
            this.cboSanBayDen.Location = new System.Drawing.Point(280, 186);
            this.cboSanBayDen.Name = "cboSanBayDen";
            this.cboSanBayDen.Size = new System.Drawing.Size(232, 40);
            this.cboSanBayDen.TabIndex = 4;
            //
            // lblKhoiHanh
            //
            this.lblKhoiHanh.AutoSize = true;
            this.lblKhoiHanh.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblKhoiHanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblKhoiHanh.Location = new System.Drawing.Point(28, 240);
            this.lblKhoiHanh.Name = "lblKhoiHanh";
            this.lblKhoiHanh.Size = new System.Drawing.Size(67, 13);
            this.lblKhoiHanh.Text = "KHỞI HÀNH";
            //
            // dtpKhoiHanh
            //
            this.dtpKhoiHanh.CustomFormat = "dd/MM/yyyy   HH:mm";
            this.dtpKhoiHanh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpKhoiHanh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKhoiHanh.Location = new System.Drawing.Point(28, 262);
            this.dtpKhoiHanh.Name = "dtpKhoiHanh";
            this.dtpKhoiHanh.Size = new System.Drawing.Size(232, 27);
            this.dtpKhoiHanh.TabIndex = 5;
            //
            // lblThoiGianBay
            //
            this.lblThoiGianBay.AutoSize = true;
            this.lblThoiGianBay.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblThoiGianBay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblThoiGianBay.Location = new System.Drawing.Point(280, 240);
            this.lblThoiGianBay.Name = "lblThoiGianBay";
            this.lblThoiGianBay.Size = new System.Drawing.Size(127, 13);
            this.lblThoiGianBay.Text = "THỜI GIAN BAY (PHÚT)";
            //
            // nudThoiGianBay
            //
            this.nudThoiGianBay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudThoiGianBay.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudThoiGianBay.Location = new System.Drawing.Point(280, 262);
            this.nudThoiGianBay.Maximum = new decimal(new int[] { 1500, 0, 0, 0 });
            this.nudThoiGianBay.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            this.nudThoiGianBay.Name = "nudThoiGianBay";
            this.nudThoiGianBay.Size = new System.Drawing.Size(232, 27);
            this.nudThoiGianBay.TabIndex = 6;
            this.nudThoiGianBay.Value = new decimal(new int[] { 125, 0, 0, 0 });
            //
            // lblGiaPT
            //
            this.lblGiaPT.AutoSize = true;
            this.lblGiaPT.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblGiaPT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblGiaPT.Location = new System.Drawing.Point(28, 310);
            this.lblGiaPT.Name = "lblGiaPT";
            this.lblGiaPT.Size = new System.Drawing.Size(95, 13);
            this.lblGiaPT.Text = "GIÁ PHỔ THÔNG";
            //
            // nudGiaPT
            //
            this.nudGiaPT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudGiaPT.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudGiaPT.Location = new System.Drawing.Point(28, 332);
            this.nudGiaPT.Maximum = new decimal(new int[] { 500000000, 0, 0, 0 });
            this.nudGiaPT.Name = "nudGiaPT";
            this.nudGiaPT.Size = new System.Drawing.Size(150, 27);
            this.nudGiaPT.TabIndex = 7;
            this.nudGiaPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGiaPT.ThousandsSeparator = true;
            this.nudGiaPT.Value = new decimal(new int[] { 900000, 0, 0, 0 });
            //
            // lblGiaPTDB
            //
            this.lblGiaPTDB.AutoSize = true;
            this.lblGiaPTDB.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblGiaPTDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblGiaPTDB.Location = new System.Drawing.Point(195, 310);
            this.lblGiaPTDB.Name = "lblGiaPTDB";
            this.lblGiaPTDB.Size = new System.Drawing.Size(101, 13);
            this.lblGiaPTDB.Text = "GIÁ PT ĐẶC BIỆT";
            //
            // nudGiaPTDB
            //
            this.nudGiaPTDB.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudGiaPTDB.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudGiaPTDB.Location = new System.Drawing.Point(195, 332);
            this.nudGiaPTDB.Maximum = new decimal(new int[] { 500000000, 0, 0, 0 });
            this.nudGiaPTDB.Name = "nudGiaPTDB";
            this.nudGiaPTDB.Size = new System.Drawing.Size(150, 27);
            this.nudGiaPTDB.TabIndex = 8;
            this.nudGiaPTDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGiaPTDB.ThousandsSeparator = true;
            this.nudGiaPTDB.Value = new decimal(new int[] { 1500000, 0, 0, 0 });
            //
            // lblGiaTG
            //
            this.lblGiaTG.AutoSize = true;
            this.lblGiaTG.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblGiaTG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblGiaTG.Location = new System.Drawing.Point(362, 310);
            this.lblGiaTG.Name = "lblGiaTG";
            this.lblGiaTG.Size = new System.Drawing.Size(94, 13);
            this.lblGiaTG.Text = "GIÁ THƯƠNG GIA";
            //
            // nudGiaTG
            //
            this.nudGiaTG.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudGiaTG.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudGiaTG.Location = new System.Drawing.Point(362, 332);
            this.nudGiaTG.Maximum = new decimal(new int[] { 500000000, 0, 0, 0 });
            this.nudGiaTG.Name = "nudGiaTG";
            this.nudGiaTG.Size = new System.Drawing.Size(150, 27);
            this.nudGiaTG.TabIndex = 9;
            this.nudGiaTG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGiaTG.ThousandsSeparator = true;
            this.nudGiaTG.Value = new decimal(new int[] { 2800000, 0, 0, 0 });
            //
            // lblLuuY
            //
            this.lblLuuY.AutoSize = true;
            this.lblLuuY.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblLuuY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblLuuY.Location = new System.Drawing.Point(28, 376);
            this.lblLuuY.Name = "lblLuuY";
            this.lblLuuY.Size = new System.Drawing.Size(401, 15);
            this.lblLuuY.Text = "Giờ khởi hành phải ở tương lai; máy bay và sân bay phải đang hoạt động.";
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(274, 410);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 44);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy bỏ";
            //
            // btnTao
            //
            this.btnTao.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnTao.Location = new System.Drawing.Point(388, 410);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(124, 44);
            this.btnTao.TabIndex = 10;
            this.btnTao.Text = "Tạo chuyến";
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            //
            // frmChuyenBay
            //
            this.AcceptButton = this.btnTao;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(540, 478);
            this.Controls.Add(this.btnTao);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblLuuY);
            this.Controls.Add(this.nudGiaTG);
            this.Controls.Add(this.lblGiaTG);
            this.Controls.Add(this.nudGiaPTDB);
            this.Controls.Add(this.lblGiaPTDB);
            this.Controls.Add(this.nudGiaPT);
            this.Controls.Add(this.lblGiaPT);
            this.Controls.Add(this.nudThoiGianBay);
            this.Controls.Add(this.lblThoiGianBay);
            this.Controls.Add(this.dtpKhoiHanh);
            this.Controls.Add(this.lblKhoiHanh);
            this.Controls.Add(this.cboSanBayDen);
            this.Controls.Add(this.lblSanBayDen);
            this.Controls.Add(this.cboSanBayDi);
            this.Controls.Add(this.lblSanBayDi);
            this.Controls.Add(this.cboMayBay);
            this.Controls.Add(this.lblMayBay);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChuyenBay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chuyến bay";
            this.Load += new System.EventHandler(this.frmChuyenBay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGianBay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaPTDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaTG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblMayBay;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboMayBay;
        private System.Windows.Forms.Label lblSanBayDi;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboSanBayDi;
        private System.Windows.Forms.Label lblSanBayDen;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboSanBayDen;
        private System.Windows.Forms.Label lblKhoiHanh;
        private System.Windows.Forms.DateTimePicker dtpKhoiHanh;
        private System.Windows.Forms.Label lblThoiGianBay;
        private System.Windows.Forms.NumericUpDown nudThoiGianBay;
        private System.Windows.Forms.Label lblGiaPT;
        private System.Windows.Forms.NumericUpDown nudGiaPT;
        private System.Windows.Forms.Label lblGiaPTDB;
        private System.Windows.Forms.NumericUpDown nudGiaPTDB;
        private System.Windows.Forms.Label lblGiaTG;
        private System.Windows.Forms.NumericUpDown nudGiaTG;
        private System.Windows.Forms.Label lblLuuY;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTao;
    }
}
