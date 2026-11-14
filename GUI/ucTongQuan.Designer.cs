namespace QuanLyBanVeMayBay.GUI
{
    partial class ucTongQuan
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
            this.cboNam = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.cboThang = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.btnXem = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnDatVeNhanh = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.tlpSoLieu = new System.Windows.Forms.TableLayoutPanel();
            this.statChuyenBay = new QuanLyBanVeMayBay.Controls.StatCard();
            this.statVe = new QuanLyBanVeMayBay.Controls.StatCard();
            this.statVeHuy = new QuanLyBanVeMayBay.Controls.StatCard();
            this.statDoanhThu = new QuanLyBanVeMayBay.Controls.StatCard();
            this.tlpDuoi = new System.Windows.Forms.TableLayoutPanel();
            this.cardBieuDo = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.chartDoanhThu = new QuanLyBanVeMayBay.Controls.BarChart();
            this.cardSapBay = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvSapBay = new System.Windows.Forms.DataGridView();
            this.flpCongCu.SuspendLayout();
            this.tlpSoLieu.SuspendLayout();
            this.tlpDuoi.SuspendLayout();
            this.cardBieuDo.SuspendLayout();
            this.cardSapBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSapBay)).BeginInit();
            this.SuspendLayout();
            //
            // flpCongCu
            //
            this.flpCongCu.Controls.Add(this.cboNam);
            this.flpCongCu.Controls.Add(this.cboThang);
            this.flpCongCu.Controls.Add(this.btnXem);
            this.flpCongCu.Controls.Add(this.btnDatVeNhanh);
            this.flpCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCongCu.Name = "flpCongCu";
            this.flpCongCu.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.flpCongCu.Size = new System.Drawing.Size(1140, 56);
            this.flpCongCu.TabIndex = 0;
            this.flpCongCu.WrapContents = false;
            //
            // cboNam
            //
            this.cboNam.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(150, 40);
            this.cboNam.TabIndex = 0;
            //
            // cboThang
            //
            this.cboThang.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(150, 40);
            this.cboThang.TabIndex = 1;
            //
            // btnXem
            //
            this.btnXem.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnXem.Margin = new System.Windows.Forms.Padding(0, 4, 24, 4);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(130, 42);
            this.btnXem.TabIndex = 2;
            this.btnXem.Text = "Xem thống kê";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            //
            // btnDatVeNhanh
            //
            this.btnDatVeNhanh.AutoSize = true;
            this.btnDatVeNhanh.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnDatVeNhanh.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnDatVeNhanh.Name = "btnDatVeNhanh";
            this.btnDatVeNhanh.Size = new System.Drawing.Size(130, 42);
            this.btnDatVeNhanh.TabIndex = 3;
            this.btnDatVeNhanh.Text = "Đặt vé mới";
            this.btnDatVeNhanh.Click += new System.EventHandler(this.btnDatVeNhanh_Click);
            //
            // tlpSoLieu
            //
            this.tlpSoLieu.ColumnCount = 4;
            this.tlpSoLieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSoLieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSoLieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSoLieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSoLieu.Controls.Add(this.statChuyenBay, 0, 0);
            this.tlpSoLieu.Controls.Add(this.statVe, 1, 0);
            this.tlpSoLieu.Controls.Add(this.statVeHuy, 2, 0);
            this.tlpSoLieu.Controls.Add(this.statDoanhThu, 3, 0);
            this.tlpSoLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpSoLieu.Name = "tlpSoLieu";
            this.tlpSoLieu.RowCount = 1;
            this.tlpSoLieu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSoLieu.Size = new System.Drawing.Size(1140, 112);
            this.tlpSoLieu.TabIndex = 1;
            //
            // statChuyenBay
            //
            this.statChuyenBay.Caption = "Chuyến bay (theo ngày khởi hành)";
            this.statChuyenBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statChuyenBay.Glyph = "";
            this.statChuyenBay.IconBack = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.statChuyenBay.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(104)))), ((int)(((byte)(133)))));
            this.statChuyenBay.Margin = new System.Windows.Forms.Padding(0);
            this.statChuyenBay.Name = "statChuyenBay";
            this.statChuyenBay.TabIndex = 0;
            //
            // statVe
            //
            this.statVe.Caption = "Vé còn hiệu lực";
            this.statVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statVe.Glyph = "";
            this.statVe.IconBack = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(243)))), ((int)(((byte)(241)))));
            this.statVe.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(93)))));
            this.statVe.Margin = new System.Windows.Forms.Padding(0);
            this.statVe.Name = "statVe";
            this.statVe.TabIndex = 1;
            //
            // statVeHuy
            //
            this.statVeHuy.Caption = "Vé đã hủy";
            this.statVeHuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statVeHuy.Glyph = "";
            this.statVeHuy.IconBack = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.statVeHuy.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(35)))), ((int)(((byte)(24)))));
            this.statVeHuy.Margin = new System.Windows.Forms.Padding(0);
            this.statVeHuy.Name = "statVeHuy";
            this.statVeHuy.TabIndex = 2;
            //
            // statDoanhThu
            //
            this.statDoanhThu.Caption = "Tổng tiền thu";
            this.statDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statDoanhThu.Glyph = "";
            this.statDoanhThu.IconBack = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(222)))));
            this.statDoanhThu.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(92)))), ((int)(((byte)(20)))));
            this.statDoanhThu.Margin = new System.Windows.Forms.Padding(0);
            this.statDoanhThu.Name = "statDoanhThu";
            this.statDoanhThu.TabIndex = 3;
            this.statDoanhThu.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(106)))), ((int)(((byte)(31)))));
            //
            // tlpDuoi
            //
            this.tlpDuoi.ColumnCount = 2;
            this.tlpDuoi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpDuoi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpDuoi.Controls.Add(this.cardBieuDo, 0, 0);
            this.tlpDuoi.Controls.Add(this.cardSapBay, 1, 0);
            this.tlpDuoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDuoi.Name = "tlpDuoi";
            this.tlpDuoi.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.tlpDuoi.RowCount = 1;
            this.tlpDuoi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDuoi.TabIndex = 2;
            //
            // cardBieuDo
            //
            this.cardBieuDo.Controls.Add(this.chartDoanhThu);
            this.cardBieuDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardBieuDo.Margin = new System.Windows.Forms.Padding(0);
            this.cardBieuDo.Name = "cardBieuDo";
            this.cardBieuDo.Padding = new System.Windows.Forms.Padding(22, 56, 22, 18);
            this.cardBieuDo.Subtitle = "· 12 tháng gần nhất";
            this.cardBieuDo.TabIndex = 0;
            this.cardBieuDo.Title = "Doanh thu thuần";
            //
            // chartDoanhThu
            //
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.TabIndex = 0;
            //
            // cardSapBay
            //
            this.cardSapBay.Controls.Add(this.dgvSapBay);
            this.cardSapBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardSapBay.Margin = new System.Windows.Forms.Padding(0);
            this.cardSapBay.Name = "cardSapBay";
            this.cardSapBay.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardSapBay.TabIndex = 1;
            this.cardSapBay.Title = "Sắp khởi hành";
            //
            // dgvSapBay
            //
            this.dgvSapBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSapBay.Name = "dgvSapBay";
            this.dgvSapBay.TabIndex = 0;
            //
            // ucTongQuan
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.tlpDuoi);
            this.Controls.Add(this.tlpSoLieu);
            this.Controls.Add(this.flpCongCu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucTongQuan";
            this.Size = new System.Drawing.Size(1140, 760);
            this.flpCongCu.ResumeLayout(false);
            this.flpCongCu.PerformLayout();
            this.tlpSoLieu.ResumeLayout(false);
            this.tlpDuoi.ResumeLayout(false);
            this.cardBieuDo.ResumeLayout(false);
            this.cardSapBay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSapBay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCongCu;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboNam;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboThang;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnXem;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnDatVeNhanh;
        private System.Windows.Forms.TableLayoutPanel tlpSoLieu;
        private QuanLyBanVeMayBay.Controls.StatCard statChuyenBay;
        private QuanLyBanVeMayBay.Controls.StatCard statVe;
        private QuanLyBanVeMayBay.Controls.StatCard statVeHuy;
        private QuanLyBanVeMayBay.Controls.StatCard statDoanhThu;
        private System.Windows.Forms.TableLayoutPanel tlpDuoi;
        private QuanLyBanVeMayBay.Controls.CardPanel cardBieuDo;
        private QuanLyBanVeMayBay.Controls.BarChart chartDoanhThu;
        private QuanLyBanVeMayBay.Controls.CardPanel cardSapBay;
        private System.Windows.Forms.DataGridView dgvSapBay;
    }
}
