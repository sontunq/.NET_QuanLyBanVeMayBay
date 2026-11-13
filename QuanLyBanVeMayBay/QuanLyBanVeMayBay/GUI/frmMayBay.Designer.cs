namespace QuanLyBanVeMayBay.GUI
{
    partial class frmMayBay
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
            this.lblSoHieu = new System.Windows.Forms.Label();
            this.ipSoHieu = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtSoHieu = new System.Windows.Forms.TextBox();
            this.lblHangSanXuat = new System.Windows.Forms.Label();
            this.ipHangSanXuat = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtHangSanXuat = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.ipLoai = new QuanLyBanVeMayBay.Controls.InputBox();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.lblSoHang = new System.Windows.Forms.Label();
            this.nudSoHang = new System.Windows.Forms.NumericUpDown();
            this.lblTongGhe = new System.Windows.Forms.Label();
            this.lblLuuY = new System.Windows.Forms.Label();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnTao = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.ipSoHieu.SuspendLayout();
            this.ipHangSanXuat.SuspendLayout();
            this.ipLoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoHang)).BeginInit();
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
            this.lblTieuDe.Text = "Thêm máy bay";
            //
            // lblSoHieu
            //
            this.lblSoHieu.AutoSize = true;
            this.lblSoHieu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblSoHieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblSoHieu.Location = new System.Drawing.Point(28, 70);
            this.lblSoHieu.Name = "lblSoHieu";
            this.lblSoHieu.Size = new System.Drawing.Size(55, 13);
            this.lblSoHieu.Text = "SỐ HIỆU *";
            //
            // ipSoHieu
            //
            this.ipSoHieu.Controls.Add(this.txtSoHieu);
            this.ipSoHieu.Location = new System.Drawing.Point(28, 90);
            this.ipSoHieu.Name = "ipSoHieu";
            this.ipSoHieu.Size = new System.Drawing.Size(424, 42);
            this.ipSoHieu.TabIndex = 1;
            //
            // txtSoHieu
            //
            this.txtSoHieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoHieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSoHieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoHieu.MaxLength = 20;
            this.txtSoHieu.Name = "txtSoHieu";
            this.txtSoHieu.PlaceholderText = "VD: VN-A321-03";
            this.txtSoHieu.TabIndex = 0;
            //
            // lblHangSanXuat
            //
            this.lblHangSanXuat.AutoSize = true;
            this.lblHangSanXuat.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblHangSanXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblHangSanXuat.Location = new System.Drawing.Point(28, 144);
            this.lblHangSanXuat.Name = "lblHangSanXuat";
            this.lblHangSanXuat.Size = new System.Drawing.Size(100, 13);
            this.lblHangSanXuat.Text = "HÃNG SẢN XUẤT *";
            //
            // ipHangSanXuat
            //
            this.ipHangSanXuat.Controls.Add(this.txtHangSanXuat);
            this.ipHangSanXuat.Location = new System.Drawing.Point(28, 164);
            this.ipHangSanXuat.Name = "ipHangSanXuat";
            this.ipHangSanXuat.Size = new System.Drawing.Size(204, 42);
            this.ipHangSanXuat.TabIndex = 2;
            //
            // txtHangSanXuat
            //
            this.txtHangSanXuat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHangSanXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHangSanXuat.Name = "txtHangSanXuat";
            this.txtHangSanXuat.TabIndex = 0;
            this.txtHangSanXuat.Text = "Airbus";
            //
            // lblLoai
            //
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblLoai.Location = new System.Drawing.Point(248, 144);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(93, 13);
            this.lblLoai.Text = "LOẠI MÁY BAY *";
            //
            // ipLoai
            //
            this.ipLoai.Controls.Add(this.txtLoai);
            this.ipLoai.Location = new System.Drawing.Point(248, 164);
            this.ipLoai.Name = "ipLoai";
            this.ipLoai.Size = new System.Drawing.Size(204, 42);
            this.ipLoai.TabIndex = 3;
            //
            // txtLoai
            //
            this.txtLoai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.TabIndex = 0;
            this.txtLoai.Text = "A321";
            //
            // lblSoHang
            //
            this.lblSoHang.AutoSize = true;
            this.lblSoHang.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblSoHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblSoHang.Location = new System.Drawing.Point(28, 218);
            this.lblSoHang.Name = "lblSoHang";
            this.lblSoHang.Size = new System.Drawing.Size(80, 13);
            this.lblSoHang.Text = "SỐ HÀNG GHẾ";
            //
            // nudSoHang
            //
            this.nudSoHang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudSoHang.Location = new System.Drawing.Point(28, 240);
            this.nudSoHang.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.nudSoHang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoHang.Name = "nudSoHang";
            this.nudSoHang.Size = new System.Drawing.Size(120, 27);
            this.nudSoHang.TabIndex = 4;
            this.nudSoHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSoHang.Value = new decimal(new int[] { 4, 0, 0, 0 });
            this.nudSoHang.ValueChanged += new System.EventHandler(this.nudSoHang_ValueChanged);
            //
            // lblTongGhe
            //
            this.lblTongGhe.AutoSize = true;
            this.lblTongGhe.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTongGhe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(104)))), ((int)(((byte)(133)))));
            this.lblTongGhe.Location = new System.Drawing.Point(162, 244);
            this.lblTongGhe.Name = "lblTongGhe";
            this.lblTongGhe.Size = new System.Drawing.Size(220, 19);
            this.lblTongGhe.Text = "= 20 ghế";
            //
            // lblLuuY
            //
            this.lblLuuY.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblLuuY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblLuuY.Location = new System.Drawing.Point(28, 282);
            this.lblLuuY.Name = "lblLuuY";
            this.lblLuuY.Size = new System.Drawing.Size(424, 36);
            this.lblLuuY.Text = "Mỗi hàng có 5 ghế A–E: A, B, C là Phổ thông, D là Phổ thông đặc biệt, E là Thương gia.";
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(214, 332);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 44);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy bỏ";
            //
            // btnTao
            //
            this.btnTao.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnTao.Location = new System.Drawing.Point(328, 332);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(124, 44);
            this.btnTao.TabIndex = 5;
            this.btnTao.Text = "Tạo máy bay";
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            //
            // frmMayBay
            //
            this.AcceptButton = this.btnTao;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(480, 400);
            this.Controls.Add(this.btnTao);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblLuuY);
            this.Controls.Add(this.lblTongGhe);
            this.Controls.Add(this.nudSoHang);
            this.Controls.Add(this.lblSoHang);
            this.Controls.Add(this.ipLoai);
            this.Controls.Add(this.lblLoai);
            this.Controls.Add(this.ipHangSanXuat);
            this.Controls.Add(this.lblHangSanXuat);
            this.Controls.Add(this.ipSoHieu);
            this.Controls.Add(this.lblSoHieu);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMayBay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Máy bay";
            this.ipSoHieu.ResumeLayout(false);
            this.ipSoHieu.PerformLayout();
            this.ipHangSanXuat.ResumeLayout(false);
            this.ipHangSanXuat.PerformLayout();
            this.ipLoai.ResumeLayout(false);
            this.ipLoai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblSoHieu;
        private QuanLyBanVeMayBay.Controls.InputBox ipSoHieu;
        private System.Windows.Forms.TextBox txtSoHieu;
        private System.Windows.Forms.Label lblHangSanXuat;
        private QuanLyBanVeMayBay.Controls.InputBox ipHangSanXuat;
        private System.Windows.Forms.TextBox txtHangSanXuat;
        private System.Windows.Forms.Label lblLoai;
        private QuanLyBanVeMayBay.Controls.InputBox ipLoai;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.Label lblSoHang;
        private System.Windows.Forms.NumericUpDown nudSoHang;
        private System.Windows.Forms.Label lblTongGhe;
        private System.Windows.Forms.Label lblLuuY;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTao;
    }
}
