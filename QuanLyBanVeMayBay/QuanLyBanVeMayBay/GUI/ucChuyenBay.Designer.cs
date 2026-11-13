namespace QuanLyBanVeMayBay.GUI
{
    partial class ucChuyenBay
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
            this.cboHienThi = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.btnLamMoi = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnTao = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnTrangThai = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.tlpNoiDung = new System.Windows.Forms.TableLayoutPanel();
            this.cardChuyenBay = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvChuyenBay = new System.Windows.Forms.DataGridView();
            this.cardHanhKhach = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvHanhKhach = new System.Windows.Forms.DataGridView();
            this.flpCongCu.SuspendLayout();
            this.tlpNoiDung.SuspendLayout();
            this.cardChuyenBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenBay)).BeginInit();
            this.cardHanhKhach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanhKhach)).BeginInit();
            this.SuspendLayout();
            //
            // flpCongCu
            //
            this.flpCongCu.Controls.Add(this.cboHienThi);
            this.flpCongCu.Controls.Add(this.btnLamMoi);
            this.flpCongCu.Controls.Add(this.btnTao);
            this.flpCongCu.Controls.Add(this.btnTrangThai);
            this.flpCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCongCu.Name = "flpCongCu";
            this.flpCongCu.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.flpCongCu.Size = new System.Drawing.Size(1140, 56);
            this.flpCongCu.TabIndex = 0;
            this.flpCongCu.WrapContents = false;
            //
            // cboHienThi
            //
            this.cboHienThi.Items.AddRange(new object[] {
            "Sắp khởi hành (đang mở bán)",
            "Tất cả chuyến bay"});
            this.cboHienThi.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cboHienThi.Name = "cboHienThi";
            this.cboHienThi.Size = new System.Drawing.Size(260, 40);
            this.cboHienThi.TabIndex = 0;
            this.cboHienThi.SelectedIndexChanged += new System.EventHandler(this.cboHienThi_SelectedIndexChanged);
            //
            // btnLamMoi
            //
            this.btnLamMoi.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0, 4, 24, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 42);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // btnTao
            //
            this.btnTao.AutoSize = true;
            this.btnTao.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnTao.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(160, 42);
            this.btnTao.TabIndex = 2;
            this.btnTao.Text = "+ Tạo chuyến bay";
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            //
            // btnTrangThai
            //
            this.btnTrangThai.AutoSize = true;
            this.btnTrangThai.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnTrangThai.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnTrangThai.Name = "btnTrangThai";
            this.btnTrangThai.Size = new System.Drawing.Size(150, 42);
            this.btnTrangThai.TabIndex = 3;
            this.btnTrangThai.Text = "Đổi trạng thái";
            this.btnTrangThai.Click += new System.EventHandler(this.btnTrangThai_Click);
            //
            // tlpNoiDung
            //
            this.tlpNoiDung.ColumnCount = 1;
            this.tlpNoiDung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoiDung.Controls.Add(this.cardChuyenBay, 0, 0);
            this.tlpNoiDung.Controls.Add(this.cardHanhKhach, 0, 1);
            this.tlpNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNoiDung.Name = "tlpNoiDung";
            this.tlpNoiDung.RowCount = 2;
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpNoiDung.TabIndex = 1;
            //
            // cardChuyenBay
            //
            this.cardChuyenBay.Controls.Add(this.dgvChuyenBay);
            this.cardChuyenBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardChuyenBay.Margin = new System.Windows.Forms.Padding(0);
            this.cardChuyenBay.Name = "cardChuyenBay";
            this.cardChuyenBay.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardChuyenBay.TabIndex = 0;
            this.cardChuyenBay.Title = "Chuyến bay";
            //
            // dgvChuyenBay
            //
            this.dgvChuyenBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChuyenBay.Name = "dgvChuyenBay";
            this.dgvChuyenBay.TabIndex = 0;
            this.dgvChuyenBay.SelectionChanged += new System.EventHandler(this.dgvChuyenBay_SelectionChanged);
            //
            // cardHanhKhach
            //
            this.cardHanhKhach.Controls.Add(this.dgvHanhKhach);
            this.cardHanhKhach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardHanhKhach.Margin = new System.Windows.Forms.Padding(0);
            this.cardHanhKhach.Name = "cardHanhKhach";
            this.cardHanhKhach.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardHanhKhach.TabIndex = 1;
            this.cardHanhKhach.Title = "Hành khách trên chuyến";
            //
            // dgvHanhKhach
            //
            this.dgvHanhKhach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHanhKhach.Name = "dgvHanhKhach";
            this.dgvHanhKhach.TabIndex = 0;
            //
            // ucChuyenBay
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.tlpNoiDung);
            this.Controls.Add(this.flpCongCu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucChuyenBay";
            this.Size = new System.Drawing.Size(1140, 760);
            this.flpCongCu.ResumeLayout(false);
            this.flpCongCu.PerformLayout();
            this.tlpNoiDung.ResumeLayout(false);
            this.cardChuyenBay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenBay)).EndInit();
            this.cardHanhKhach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanhKhach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCongCu;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboHienThi;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnLamMoi;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTao;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTrangThai;
        private System.Windows.Forms.TableLayoutPanel tlpNoiDung;
        private QuanLyBanVeMayBay.Controls.CardPanel cardChuyenBay;
        private System.Windows.Forms.DataGridView dgvChuyenBay;
        private QuanLyBanVeMayBay.Controls.CardPanel cardHanhKhach;
        private System.Windows.Forms.DataGridView dgvHanhKhach;
    }
}
