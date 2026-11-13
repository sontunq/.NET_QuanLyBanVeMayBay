namespace QuanLyBanVeMayBay.GUI
{
    partial class ucBaoCao
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
            this.btnTheoThang = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnTheoChuyen = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnTheoNhanVien = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnLamMoi = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.pnlTheoThang = new System.Windows.Forms.TableLayoutPanel();
            this.cardBieuDo = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.chartThang = new QuanLyBanVeMayBay.Controls.BarChart();
            this.cardThang = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvThang = new System.Windows.Forms.DataGridView();
            this.cardTheoChuyen = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvTheoChuyen = new System.Windows.Forms.DataGridView();
            this.cardTheoNhanVien = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvTheoNhanVien = new System.Windows.Forms.DataGridView();
            this.flpCongCu.SuspendLayout();
            this.pnlTheoThang.SuspendLayout();
            this.cardBieuDo.SuspendLayout();
            this.cardThang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThang)).BeginInit();
            this.cardTheoChuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoChuyen)).BeginInit();
            this.cardTheoNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoNhanVien)).BeginInit();
            this.SuspendLayout();
            //
            // flpCongCu
            //
            this.flpCongCu.Controls.Add(this.btnTheoThang);
            this.flpCongCu.Controls.Add(this.btnTheoChuyen);
            this.flpCongCu.Controls.Add(this.btnTheoNhanVien);
            this.flpCongCu.Controls.Add(this.btnLamMoi);
            this.flpCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCongCu.Name = "flpCongCu";
            this.flpCongCu.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.flpCongCu.Size = new System.Drawing.Size(1140, 56);
            this.flpCongCu.TabIndex = 0;
            this.flpCongCu.WrapContents = false;
            //
            // btnTheoThang
            //
            this.btnTheoThang.Margin = new System.Windows.Forms.Padding(0, 4, 8, 4);
            this.btnTheoThang.Name = "btnTheoThang";
            this.btnTheoThang.Radius = 21;
            this.btnTheoThang.Size = new System.Drawing.Size(130, 42);
            this.btnTheoThang.TabIndex = 0;
            this.btnTheoThang.Text = "Theo tháng";
            this.btnTheoThang.Click += new System.EventHandler(this.Tab_Click);
            //
            // btnTheoChuyen
            //
            this.btnTheoChuyen.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnTheoChuyen.Margin = new System.Windows.Forms.Padding(0, 4, 8, 4);
            this.btnTheoChuyen.Name = "btnTheoChuyen";
            this.btnTheoChuyen.Radius = 21;
            this.btnTheoChuyen.Size = new System.Drawing.Size(160, 42);
            this.btnTheoChuyen.TabIndex = 1;
            this.btnTheoChuyen.Text = "Theo chuyến bay";
            this.btnTheoChuyen.Click += new System.EventHandler(this.Tab_Click);
            //
            // btnTheoNhanVien
            //
            this.btnTheoNhanVien.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnTheoNhanVien.Margin = new System.Windows.Forms.Padding(0, 4, 24, 4);
            this.btnTheoNhanVien.Name = "btnTheoNhanVien";
            this.btnTheoNhanVien.Radius = 21;
            this.btnTheoNhanVien.Size = new System.Drawing.Size(160, 42);
            this.btnTheoNhanVien.TabIndex = 2;
            this.btnTheoNhanVien.Text = "Theo nhân viên";
            this.btnTheoNhanVien.Click += new System.EventHandler(this.Tab_Click);
            //
            // btnLamMoi
            //
            this.btnLamMoi.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 42);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // pnlTheoThang
            //
            this.pnlTheoThang.ColumnCount = 2;
            this.pnlTheoThang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.pnlTheoThang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.pnlTheoThang.Controls.Add(this.cardBieuDo, 0, 0);
            this.pnlTheoThang.Controls.Add(this.cardThang, 1, 0);
            this.pnlTheoThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTheoThang.Name = "pnlTheoThang";
            this.pnlTheoThang.RowCount = 1;
            this.pnlTheoThang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTheoThang.TabIndex = 1;
            //
            // cardBieuDo
            //
            this.cardBieuDo.Controls.Add(this.chartThang);
            this.cardBieuDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardBieuDo.Margin = new System.Windows.Forms.Padding(0);
            this.cardBieuDo.Name = "cardBieuDo";
            this.cardBieuDo.Padding = new System.Windows.Forms.Padding(22, 56, 22, 18);
            this.cardBieuDo.Subtitle = "· tiền thu trừ tiền hoàn";
            this.cardBieuDo.TabIndex = 0;
            this.cardBieuDo.Title = "Doanh thu thuần";
            //
            // chartThang
            //
            this.chartThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartThang.Name = "chartThang";
            this.chartThang.TabIndex = 0;
            //
            // cardThang
            //
            this.cardThang.Controls.Add(this.dgvThang);
            this.cardThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardThang.Margin = new System.Windows.Forms.Padding(0);
            this.cardThang.Name = "cardThang";
            this.cardThang.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardThang.TabIndex = 1;
            this.cardThang.Title = "Chi tiết theo tháng";
            //
            // dgvThang
            //
            this.dgvThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThang.Name = "dgvThang";
            this.dgvThang.TabIndex = 0;
            //
            // cardTheoChuyen
            //
            this.cardTheoChuyen.Controls.Add(this.dgvTheoChuyen);
            this.cardTheoChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTheoChuyen.Name = "cardTheoChuyen";
            this.cardTheoChuyen.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardTheoChuyen.Subtitle = "· chuyến có vé còn hiệu lực, sắp theo doanh thu vé";
            this.cardTheoChuyen.TabIndex = 2;
            this.cardTheoChuyen.Title = "Doanh thu theo chuyến bay";
            this.cardTheoChuyen.Visible = false;
            //
            // dgvTheoChuyen
            //
            this.dgvTheoChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTheoChuyen.Name = "dgvTheoChuyen";
            this.dgvTheoChuyen.TabIndex = 0;
            //
            // cardTheoNhanVien
            //
            this.cardTheoNhanVien.Controls.Add(this.dgvTheoNhanVien);
            this.cardTheoNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTheoNhanVien.Name = "cardTheoNhanVien";
            this.cardTheoNhanVien.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardTheoNhanVien.Subtitle = "· số đơn đã lập và doanh thu các đơn đã thanh toán";
            this.cardTheoNhanVien.TabIndex = 3;
            this.cardTheoNhanVien.Title = "Doanh thu theo nhân viên";
            this.cardTheoNhanVien.Visible = false;
            //
            // dgvTheoNhanVien
            //
            this.dgvTheoNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTheoNhanVien.Name = "dgvTheoNhanVien";
            this.dgvTheoNhanVien.TabIndex = 0;
            //
            // ucBaoCao
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.pnlTheoThang);
            this.Controls.Add(this.cardTheoChuyen);
            this.Controls.Add(this.cardTheoNhanVien);
            this.Controls.Add(this.flpCongCu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucBaoCao";
            this.Size = new System.Drawing.Size(1140, 760);
            this.flpCongCu.ResumeLayout(false);
            this.pnlTheoThang.ResumeLayout(false);
            this.cardBieuDo.ResumeLayout(false);
            this.cardThang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThang)).EndInit();
            this.cardTheoChuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoChuyen)).EndInit();
            this.cardTheoNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheoNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCongCu;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTheoThang;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTheoChuyen;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTheoNhanVien;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnLamMoi;
        private System.Windows.Forms.TableLayoutPanel pnlTheoThang;
        private QuanLyBanVeMayBay.Controls.CardPanel cardBieuDo;
        private QuanLyBanVeMayBay.Controls.BarChart chartThang;
        private QuanLyBanVeMayBay.Controls.CardPanel cardThang;
        private System.Windows.Forms.DataGridView dgvThang;
        private QuanLyBanVeMayBay.Controls.CardPanel cardTheoChuyen;
        private System.Windows.Forms.DataGridView dgvTheoChuyen;
        private QuanLyBanVeMayBay.Controls.CardPanel cardTheoNhanVien;
        private System.Windows.Forms.DataGridView dgvTheoNhanVien;
    }
}
