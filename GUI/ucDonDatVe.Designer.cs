namespace QuanLyBanVeMayBay.GUI
{
    partial class ucDonDatVe
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpCongCu = new System.Windows.Forms.FlowLayoutPanel();
            this.cboTrangThai = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.ipTim = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnLoc = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnThemDichVu = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnThanhToan = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnHuyVe = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnInHoaDon = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.tlpNoiDung = new System.Windows.Forms.TableLayoutPanel();
            this.cardDon = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvDon = new System.Windows.Forms.DataGridView();
            this.cardVe = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.cardDichVu = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.flpCongCu.SuspendLayout();
            this.ipTim.SuspendLayout();
            this.tlpNoiDung.SuspendLayout();
            this.cardDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDon)).BeginInit();
            this.cardVe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.cardDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.SuspendLayout();
            //
            // flpCongCu
            //
            this.flpCongCu.Controls.Add(this.cboTrangThai);
            this.flpCongCu.Controls.Add(this.ipTim);
            this.flpCongCu.Controls.Add(this.btnLoc);
            this.flpCongCu.Controls.Add(this.btnThemDichVu);
            this.flpCongCu.Controls.Add(this.btnThanhToan);
            this.flpCongCu.Controls.Add(this.btnHuyVe);
            this.flpCongCu.Controls.Add(this.btnInHoaDon);
            this.flpCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCongCu.Name = "flpCongCu";
            this.flpCongCu.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.flpCongCu.Size = new System.Drawing.Size(1140, 56);
            this.flpCongCu.TabIndex = 0;
            this.flpCongCu.WrapContents = false;
            //
            // cboTrangThai
            //
            this.cboTrangThai.Items.AddRange(new object[] {
            "Tất cả trạng thái",
            "Chờ thanh toán",
            "Đã thanh toán",
            "Đã hủy"});
            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(180, 40);
            this.cboTrangThai.TabIndex = 0;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            //
            // ipTim
            //
            this.ipTim.Controls.Add(this.txtTim);
            this.ipTim.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.ipTim.Name = "ipTim";
            this.ipTim.Size = new System.Drawing.Size(190, 42);
            this.ipTim.TabIndex = 1;
            //
            // txtTim
            //
            this.txtTim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTim.Name = "txtTim";
            this.txtTim.PlaceholderText = "Mã đơn hoặc tên khách hàng";
            this.txtTim.TabIndex = 0;
            this.txtTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTim_KeyDown);
            //
            // btnLoc
            //
            this.btnLoc.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnLoc.Margin = new System.Windows.Forms.Padding(0, 4, 14, 4);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(90, 42);
            this.btnLoc.TabIndex = 2;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            //
            // btnThemDichVu
            //
            this.btnThemDichVu.AutoSize = true;
            this.btnThemDichVu.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnThemDichVu.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnThemDichVu.Name = "btnThemDichVu";
            this.btnThemDichVu.Size = new System.Drawing.Size(166, 42);
            this.btnThemDichVu.TabIndex = 3;
            this.btnThemDichVu.Text = "+ Dịch vụ cho vé";
            this.btnThemDichVu.Click += new System.EventHandler(this.btnThemDichVu_Click);
            //
            // btnThanhToan
            //
            this.btnThanhToan.AutoSize = true;
            this.btnThanhToan.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(160, 42);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "Thanh toán đơn";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            //
            // btnHuyVe
            //
            this.btnHuyVe.AutoSize = true;
            this.btnHuyVe.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Danger;
            this.btnHuyVe.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnHuyVe.Name = "btnHuyVe";
            this.btnHuyVe.Size = new System.Drawing.Size(100, 42);
            this.btnHuyVe.TabIndex = 5;
            this.btnHuyVe.Text = "Hủy vé";
            this.btnHuyVe.Click += new System.EventHandler(this.btnHuyVe_Click);
            //
            // btnInHoaDon
            //
            this.btnInHoaDon.AutoSize = true;
            this.btnInHoaDon.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(120, 42);
            this.btnInHoaDon.TabIndex = 6;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            //
            // tlpNoiDung
            //
            this.tlpNoiDung.ColumnCount = 2;
            this.tlpNoiDung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tlpNoiDung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpNoiDung.Controls.Add(this.cardDon, 0, 0);
            this.tlpNoiDung.Controls.Add(this.cardVe, 0, 1);
            this.tlpNoiDung.Controls.Add(this.cardDichVu, 1, 1);
            this.tlpNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNoiDung.Name = "tlpNoiDung";
            this.tlpNoiDung.RowCount = 2;
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpNoiDung.SetColumnSpan(this.cardDon, 2);
            this.tlpNoiDung.TabIndex = 1;
            //
            // cardDon
            //
            this.cardDon.Controls.Add(this.dgvDon);
            this.cardDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDon.Margin = new System.Windows.Forms.Padding(0);
            this.cardDon.Name = "cardDon";
            this.cardDon.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardDon.TabIndex = 0;
            this.cardDon.Title = "Đơn đặt vé";
            //
            // dgvDon
            //
            this.dgvDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDon.Name = "dgvDon";
            this.dgvDon.TabIndex = 0;
            this.dgvDon.SelectionChanged += new System.EventHandler(this.dgvDon_SelectionChanged);
            //
            // cardVe
            //
            this.cardVe.Controls.Add(this.dgvVe);
            this.cardVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardVe.Margin = new System.Windows.Forms.Padding(0);
            this.cardVe.Name = "cardVe";
            this.cardVe.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardVe.TabIndex = 1;
            this.cardVe.Title = "Vé trong đơn";
            //
            // dgvVe
            //
            this.dgvVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.TabIndex = 0;
            //
            // cardDichVu
            //
            this.cardDichVu.Controls.Add(this.dgvDichVu);
            this.cardDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDichVu.Margin = new System.Windows.Forms.Padding(0);
            this.cardDichVu.Name = "cardDichVu";
            this.cardDichVu.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardDichVu.TabIndex = 2;
            this.cardDichVu.Title = "Dịch vụ đã mua";
            //
            // dgvDichVu
            //
            this.dgvDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.TabIndex = 0;
            //
            // ucDonDatVe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.tlpNoiDung);
            this.Controls.Add(this.flpCongCu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucDonDatVe";
            this.Size = new System.Drawing.Size(1140, 760);
            this.flpCongCu.ResumeLayout(false);
            this.flpCongCu.PerformLayout();
            this.ipTim.ResumeLayout(false);
            this.ipTim.PerformLayout();
            this.tlpNoiDung.ResumeLayout(false);
            this.cardDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDon)).EndInit();
            this.cardVe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.cardDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCongCu;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboTrangThai;
        private QuanLyBanVeMayBay.Controls.InputBox ipTim;
        private System.Windows.Forms.TextBox txtTim;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnLoc;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnThemDichVu;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnThanhToan;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuyVe;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnInHoaDon;
        private System.Windows.Forms.TableLayoutPanel tlpNoiDung;
        private QuanLyBanVeMayBay.Controls.CardPanel cardDon;
        private System.Windows.Forms.DataGridView dgvDon;
        private QuanLyBanVeMayBay.Controls.CardPanel cardVe;
        private System.Windows.Forms.DataGridView dgvVe;
        private QuanLyBanVeMayBay.Controls.CardPanel cardDichVu;
        private System.Windows.Forms.DataGridView dgvDichVu;
    }
}
