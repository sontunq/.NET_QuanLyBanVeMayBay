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
            this.lblHangTG = new System.Windows.Forms.Label();
            this.lblHangPTDB = new System.Windows.Forms.Label();
            this.lblHangPT = new System.Windows.Forms.Label();
            this.nudHangTG = new System.Windows.Forms.NumericUpDown();
            this.nudHangPTDB = new System.Windows.Forms.NumericUpDown();
            this.nudHangPT = new System.Windows.Forms.NumericUpDown();
            this.lblTongGhe = new System.Windows.Forms.Label();
            this.lblLuuY = new System.Windows.Forms.Label();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnTao = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.ipSoHieu.SuspendLayout();
            this.ipHangSanXuat.SuspendLayout();
            this.ipLoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHangTG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHangPTDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHangPT)).BeginInit();
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
            this.lblSoHang.Size = new System.Drawing.Size(240, 13);
            this.lblSoHang.Text = "SỐ HÀNG GHẾ THEO HẠNG (TỪ MŨI VỀ ĐUÔI)";
            //
            // lblHangTG
            //
            this.lblHangTG.AutoSize = true;
            this.lblHangTG.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblHangTG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblHangTG.Location = new System.Drawing.Point(28, 238);
            this.lblHangTG.Name = "lblHangTG";
            this.lblHangTG.Size = new System.Drawing.Size(90, 13);
            this.lblHangTG.Text = "Thương gia (2-2)";
            //
            // lblHangPTDB
            //
            this.lblHangPTDB.AutoSize = true;
            this.lblHangPTDB.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblHangPTDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblHangPTDB.Location = new System.Drawing.Point(176, 238);
            this.lblHangPTDB.Name = "lblHangPTDB";
            this.lblHangPTDB.Size = new System.Drawing.Size(95, 13);
            this.lblHangPTDB.Text = "PT đặc biệt (3-3)";
            //
            // lblHangPT
            //
            this.lblHangPT.AutoSize = true;
            this.lblHangPT.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblHangPT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblHangPT.Location = new System.Drawing.Point(324, 238);
            this.lblHangPT.Name = "lblHangPT";
            this.lblHangPT.Size = new System.Drawing.Size(85, 13);
            this.lblHangPT.Text = "Phổ thông (3-3)";
            //
            // nudHangTG
            //
            this.nudHangTG.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudHangTG.Location = new System.Drawing.Point(28, 256);
            this.nudHangTG.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.nudHangTG.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudHangTG.Name = "nudHangTG";
            this.nudHangTG.Size = new System.Drawing.Size(128, 27);
            this.nudHangTG.TabIndex = 4;
            this.nudHangTG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHangTG.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.nudHangTG.ValueChanged += new System.EventHandler(this.nudSoHang_ValueChanged);
            //
            // nudHangPTDB
            //
            this.nudHangPTDB.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudHangPTDB.Location = new System.Drawing.Point(176, 256);
            this.nudHangPTDB.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.nudHangPTDB.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudHangPTDB.Name = "nudHangPTDB";
            this.nudHangPTDB.Size = new System.Drawing.Size(128, 27);
            this.nudHangPTDB.TabIndex = 5;
            this.nudHangPTDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHangPTDB.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.nudHangPTDB.ValueChanged += new System.EventHandler(this.nudSoHang_ValueChanged);
            //
            // nudHangPT
            //
            this.nudHangPT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudHangPT.Location = new System.Drawing.Point(324, 256);
            this.nudHangPT.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.nudHangPT.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudHangPT.Name = "nudHangPT";
            this.nudHangPT.Size = new System.Drawing.Size(128, 27);
            this.nudHangPT.TabIndex = 6;
            this.nudHangPT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHangPT.Value = new decimal(new int[] { 6, 0, 0, 0 });
            this.nudHangPT.ValueChanged += new System.EventHandler(this.nudSoHang_ValueChanged);
            //
            // lblTongGhe
            //
            this.lblTongGhe.AutoSize = true;
            this.lblTongGhe.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTongGhe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(104)))), ((int)(((byte)(133)))));
            this.lblTongGhe.Location = new System.Drawing.Point(28, 294);
            this.lblTongGhe.Name = "lblTongGhe";
            this.lblTongGhe.Size = new System.Drawing.Size(220, 19);
            this.lblTongGhe.Text = "= 56 ghế";
            //
            // lblLuuY
            //
            this.lblLuuY.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblLuuY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblLuuY.Location = new System.Drawing.Point(28, 322);
            this.lblLuuY.Name = "lblLuuY";
            this.lblLuuY.Size = new System.Drawing.Size(424, 36);
            this.lblLuuY.Text = "Thương gia ở các hàng đầu (ghế A, C, D, F), tiếp theo là Phổ thông đặc biệt, cuối cùng là Phổ thông (ghế A–F).";
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(214, 372);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 44);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy bỏ";
            //
            // btnTao
            //
            this.btnTao.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnTao.Location = new System.Drawing.Point(328, 372);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(124, 44);
            this.btnTao.TabIndex = 7;
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
            this.ClientSize = new System.Drawing.Size(480, 440);
            this.Controls.Add(this.btnTao);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblLuuY);
            this.Controls.Add(this.lblTongGhe);
            this.Controls.Add(this.nudHangPT);
            this.Controls.Add(this.nudHangPTDB);
            this.Controls.Add(this.nudHangTG);
            this.Controls.Add(this.lblHangPT);
            this.Controls.Add(this.lblHangPTDB);
            this.Controls.Add(this.lblHangTG);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudHangTG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHangPTDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHangPT)).EndInit();
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
        private System.Windows.Forms.Label lblHangTG;
        private System.Windows.Forms.Label lblHangPTDB;
        private System.Windows.Forms.Label lblHangPT;
        private System.Windows.Forms.NumericUpDown nudHangTG;
        private System.Windows.Forms.NumericUpDown nudHangPTDB;
        private System.Windows.Forms.NumericUpDown nudHangPT;
        private System.Windows.Forms.Label lblTongGhe;
        private System.Windows.Forms.Label lblLuuY;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTao;
    }
}
