namespace QuanLyBanVeMayBay.GUI
{
    partial class ucKhachHang
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
            this.ipTim = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTim = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnThem = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnSua = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnXetHang = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.tlpNoiDung = new System.Windows.Forms.TableLayoutPanel();
            this.cardKhachHang = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.cardLichSu = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.flpCongCu.SuspendLayout();
            this.ipTim.SuspendLayout();
            this.tlpNoiDung.SuspendLayout();
            this.cardKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.cardLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            //
            // flpCongCu
            //
            this.flpCongCu.Controls.Add(this.ipTim);
            this.flpCongCu.Controls.Add(this.btnTim);
            this.flpCongCu.Controls.Add(this.btnThem);
            this.flpCongCu.Controls.Add(this.btnSua);
            this.flpCongCu.Controls.Add(this.btnXetHang);
            this.flpCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCongCu.Name = "flpCongCu";
            this.flpCongCu.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.flpCongCu.Size = new System.Drawing.Size(1140, 56);
            this.flpCongCu.TabIndex = 0;
            this.flpCongCu.WrapContents = false;
            //
            // ipTim
            //
            this.ipTim.Controls.Add(this.txtTim);
            this.ipTim.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.ipTim.Name = "ipTim";
            this.ipTim.Size = new System.Drawing.Size(300, 42);
            this.ipTim.TabIndex = 0;
            //
            // txtTim
            //
            this.txtTim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTim.Name = "txtTim";
            this.txtTim.PlaceholderText = "Tên, số giấy tờ hoặc số điện thoại";
            this.txtTim.TabIndex = 0;
            this.txtTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTim_KeyDown);
            //
            // btnTim
            //
            this.btnTim.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnTim.Margin = new System.Windows.Forms.Padding(0, 4, 24, 4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 42);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            //
            // btnThem
            //
            this.btnThem.AutoSize = true;
            this.btnThem.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnThem.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(140, 42);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "+ Thêm khách";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // btnSua
            //
            this.btnSua.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnSua.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 42);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            //
            // btnXetHang
            //
            this.btnXetHang.AutoSize = true;
            this.btnXetHang.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnXetHang.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnXetHang.Name = "btnXetHang";
            this.btnXetHang.Size = new System.Drawing.Size(140, 42);
            this.btnXetHang.TabIndex = 4;
            this.btnXetHang.Text = "Xét lại hạng";
            this.btnXetHang.Click += new System.EventHandler(this.btnXetHang_Click);
            //
            // tlpNoiDung
            //
            this.tlpNoiDung.ColumnCount = 1;
            this.tlpNoiDung.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNoiDung.Controls.Add(this.cardKhachHang, 0, 0);
            this.tlpNoiDung.Controls.Add(this.cardLichSu, 0, 1);
            this.tlpNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNoiDung.Name = "tlpNoiDung";
            this.tlpNoiDung.RowCount = 2;
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpNoiDung.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpNoiDung.TabIndex = 1;
            //
            // cardKhachHang
            //
            this.cardKhachHang.Controls.Add(this.dgvKhachHang);
            this.cardKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardKhachHang.Margin = new System.Windows.Forms.Padding(0);
            this.cardKhachHang.Name = "cardKhachHang";
            this.cardKhachHang.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardKhachHang.Subtitle = "· Thành viên · Bạc 8% · Vàng 10% · Bạch Kim 12% · Kim Cương 15%";
            this.cardKhachHang.TabIndex = 0;
            this.cardKhachHang.Title = "Khách hàng";
            //
            // dgvKhachHang
            //
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.TabIndex = 0;
            this.dgvKhachHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellDoubleClick);
            this.dgvKhachHang.SelectionChanged += new System.EventHandler(this.dgvKhachHang_SelectionChanged);
            //
            // cardLichSu
            //
            this.cardLichSu.Controls.Add(this.dgvLichSu);
            this.cardLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardLichSu.Margin = new System.Windows.Forms.Padding(0);
            this.cardLichSu.Name = "cardLichSu";
            this.cardLichSu.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardLichSu.TabIndex = 1;
            this.cardLichSu.Title = "Lịch sử vé";
            //
            // dgvLichSu
            //
            this.dgvLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.TabIndex = 0;
            //
            // ucKhachHang
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.tlpNoiDung);
            this.Controls.Add(this.flpCongCu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucKhachHang";
            this.Size = new System.Drawing.Size(1140, 760);
            this.flpCongCu.ResumeLayout(false);
            this.flpCongCu.PerformLayout();
            this.ipTim.ResumeLayout(false);
            this.ipTim.PerformLayout();
            this.tlpNoiDung.ResumeLayout(false);
            this.cardKhachHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.cardLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCongCu;
        private QuanLyBanVeMayBay.Controls.InputBox ipTim;
        private System.Windows.Forms.TextBox txtTim;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTim;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnThem;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnSua;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnXetHang;
        private System.Windows.Forms.TableLayoutPanel tlpNoiDung;
        private QuanLyBanVeMayBay.Controls.CardPanel cardKhachHang;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private QuanLyBanVeMayBay.Controls.CardPanel cardLichSu;
        private System.Windows.Forms.DataGridView dgvLichSu;
    }
}
