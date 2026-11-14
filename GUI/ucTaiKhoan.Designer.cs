namespace QuanLyBanVeMayBay.GUI
{
    partial class ucTaiKhoan
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
            this.btnThem = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnKhoa = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.cardTaiKhoan = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.flpCongCu.SuspendLayout();
            this.cardTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.SuspendLayout();
            //
            // flpCongCu
            //
            this.flpCongCu.Controls.Add(this.btnThem);
            this.flpCongCu.Controls.Add(this.btnKhoa);
            this.flpCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCongCu.Name = "flpCongCu";
            this.flpCongCu.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.flpCongCu.Size = new System.Drawing.Size(1140, 56);
            this.flpCongCu.TabIndex = 0;
            this.flpCongCu.WrapContents = false;
            //
            // btnThem
            //
            this.btnThem.AutoSize = true;
            this.btnThem.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Accent;
            this.btnThem.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 42);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "+ Thêm tài khoản";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // btnKhoa
            //
            this.btnKhoa.AutoSize = true;
            this.btnKhoa.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnKhoa.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(150, 42);
            this.btnKhoa.TabIndex = 1;
            this.btnKhoa.Text = "Khóa / Mở khóa";
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            //
            // cardTaiKhoan
            //
            this.cardTaiKhoan.Controls.Add(this.dgvTaiKhoan);
            this.cardTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTaiKhoan.Name = "cardTaiKhoan";
            this.cardTaiKhoan.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardTaiKhoan.Subtitle = "· mọi thay đổi được tự động ghi vào nhật ký";
            this.cardTaiKhoan.TabIndex = 1;
            this.cardTaiKhoan.Title = "Tài khoản nhân viên";
            //
            // dgvTaiKhoan
            //
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.TabIndex = 0;
            //
            // ucTaiKhoan
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.cardTaiKhoan);
            this.Controls.Add(this.flpCongCu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucTaiKhoan";
            this.Size = new System.Drawing.Size(1140, 760);
            this.flpCongCu.ResumeLayout(false);
            this.flpCongCu.PerformLayout();
            this.cardTaiKhoan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCongCu;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnThem;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnKhoa;
        private QuanLyBanVeMayBay.Controls.CardPanel cardTaiKhoan;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
    }
}
