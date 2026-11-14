namespace QuanLyBanVeMayBay.GUI
{
    partial class ucTraCuuVe
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
            this.ipMaVe = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtMaVe = new System.Windows.Forms.TextBox();
            this.ipMaChuyenBay = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtMaChuyenBay = new System.Windows.Forms.TextBox();
            this.ipSoGiayTo = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtSoGiayTo = new System.Windows.Forms.TextBox();
            this.btnTraCuu = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnXoaLoc = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnHuyVe = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.cardKetQua = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.flpCongCu.SuspendLayout();
            this.ipMaVe.SuspendLayout();
            this.ipMaChuyenBay.SuspendLayout();
            this.ipSoGiayTo.SuspendLayout();
            this.cardKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            //
            // flpCongCu
            //
            this.flpCongCu.Controls.Add(this.ipMaVe);
            this.flpCongCu.Controls.Add(this.ipMaChuyenBay);
            this.flpCongCu.Controls.Add(this.ipSoGiayTo);
            this.flpCongCu.Controls.Add(this.btnTraCuu);
            this.flpCongCu.Controls.Add(this.btnXoaLoc);
            this.flpCongCu.Controls.Add(this.btnHuyVe);
            this.flpCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCongCu.Name = "flpCongCu";
            this.flpCongCu.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.flpCongCu.Size = new System.Drawing.Size(1140, 56);
            this.flpCongCu.TabIndex = 0;
            this.flpCongCu.WrapContents = false;
            //
            // ipMaVe
            //
            this.ipMaVe.Controls.Add(this.txtMaVe);
            this.ipMaVe.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.ipMaVe.Name = "ipMaVe";
            this.ipMaVe.Size = new System.Drawing.Size(140, 42);
            this.ipMaVe.TabIndex = 0;
            //
            // txtMaVe
            //
            this.txtMaVe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaVe.Name = "txtMaVe";
            this.txtMaVe.PlaceholderText = "Mã vé";
            this.txtMaVe.TabIndex = 0;
            this.txtMaVe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.O_Tim_KeyDown);
            //
            // ipMaChuyenBay
            //
            this.ipMaChuyenBay.Controls.Add(this.txtMaChuyenBay);
            this.ipMaChuyenBay.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.ipMaChuyenBay.Name = "ipMaChuyenBay";
            this.ipMaChuyenBay.Size = new System.Drawing.Size(170, 42);
            this.ipMaChuyenBay.TabIndex = 1;
            //
            // txtMaChuyenBay
            //
            this.txtMaChuyenBay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaChuyenBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaChuyenBay.Name = "txtMaChuyenBay";
            this.txtMaChuyenBay.PlaceholderText = "Mã chuyến bay";
            this.txtMaChuyenBay.TabIndex = 0;
            this.txtMaChuyenBay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.O_Tim_KeyDown);
            //
            // ipSoGiayTo
            //
            this.ipSoGiayTo.Controls.Add(this.txtSoGiayTo);
            this.ipSoGiayTo.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.ipSoGiayTo.Name = "ipSoGiayTo";
            this.ipSoGiayTo.Size = new System.Drawing.Size(230, 42);
            this.ipSoGiayTo.TabIndex = 2;
            //
            // txtSoGiayTo
            //
            this.txtSoGiayTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoGiayTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoGiayTo.Name = "txtSoGiayTo";
            this.txtSoGiayTo.PlaceholderText = "Số CCCD / hộ chiếu";
            this.txtSoGiayTo.TabIndex = 0;
            this.txtSoGiayTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.O_Tim_KeyDown);
            //
            // btnTraCuu
            //
            this.btnTraCuu.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(110, 42);
            this.btnTraCuu.TabIndex = 3;
            this.btnTraCuu.Text = "Tra cứu";
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            //
            // btnXoaLoc
            //
            this.btnXoaLoc.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnXoaLoc.Margin = new System.Windows.Forms.Padding(0, 4, 24, 4);
            this.btnXoaLoc.Name = "btnXoaLoc";
            this.btnXoaLoc.Size = new System.Drawing.Size(100, 42);
            this.btnXoaLoc.TabIndex = 4;
            this.btnXoaLoc.Text = "Xóa lọc";
            this.btnXoaLoc.Click += new System.EventHandler(this.btnXoaLoc_Click);
            //
            // btnHuyVe
            //
            this.btnHuyVe.AutoSize = true;
            this.btnHuyVe.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Danger;
            this.btnHuyVe.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnHuyVe.Name = "btnHuyVe";
            this.btnHuyVe.Size = new System.Drawing.Size(150, 42);
            this.btnHuyVe.TabIndex = 5;
            this.btnHuyVe.Text = "Hủy vé đã chọn";
            this.btnHuyVe.Click += new System.EventHandler(this.btnHuyVe_Click);
            //
            // cardKetQua
            //
            this.cardKetQua.Controls.Add(this.dgvKetQua);
            this.cardKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardKetQua.Name = "cardKetQua";
            this.cardKetQua.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardKetQua.TabIndex = 1;
            this.cardKetQua.Title = "Kết quả tra cứu";
            //
            // dgvKetQua
            //
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.TabIndex = 0;
            this.dgvKetQua.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellDoubleClick);
            //
            // ucTraCuuVe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.cardKetQua);
            this.Controls.Add(this.flpCongCu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucTraCuuVe";
            this.Size = new System.Drawing.Size(1140, 760);
            this.flpCongCu.ResumeLayout(false);
            this.flpCongCu.PerformLayout();
            this.ipMaVe.ResumeLayout(false);
            this.ipMaVe.PerformLayout();
            this.ipMaChuyenBay.ResumeLayout(false);
            this.ipMaChuyenBay.PerformLayout();
            this.ipSoGiayTo.ResumeLayout(false);
            this.ipSoGiayTo.PerformLayout();
            this.cardKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCongCu;
        private QuanLyBanVeMayBay.Controls.InputBox ipMaVe;
        private System.Windows.Forms.TextBox txtMaVe;
        private QuanLyBanVeMayBay.Controls.InputBox ipMaChuyenBay;
        private System.Windows.Forms.TextBox txtMaChuyenBay;
        private QuanLyBanVeMayBay.Controls.InputBox ipSoGiayTo;
        private System.Windows.Forms.TextBox txtSoGiayTo;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTraCuu;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnXoaLoc;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuyVe;
        private QuanLyBanVeMayBay.Controls.CardPanel cardKetQua;
        private System.Windows.Forms.DataGridView dgvKetQua;
    }
}
