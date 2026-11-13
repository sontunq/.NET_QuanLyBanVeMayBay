namespace QuanLyBanVeMayBay.GUI
{
    partial class ucMayBay
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
            this.btnTrangThai = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.cardMayBay = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvMayBay = new System.Windows.Forms.DataGridView();
            this.flpCongCu.SuspendLayout();
            this.cardMayBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMayBay)).BeginInit();
            this.SuspendLayout();
            //
            // flpCongCu
            //
            this.flpCongCu.Controls.Add(this.btnThem);
            this.flpCongCu.Controls.Add(this.btnTrangThai);
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
            this.btnThem.Text = "+ Thêm máy bay";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // btnTrangThai
            //
            this.btnTrangThai.AutoSize = true;
            this.btnTrangThai.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnTrangThai.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnTrangThai.Name = "btnTrangThai";
            this.btnTrangThai.Size = new System.Drawing.Size(150, 42);
            this.btnTrangThai.TabIndex = 1;
            this.btnTrangThai.Text = "Đổi trạng thái";
            this.btnTrangThai.Click += new System.EventHandler(this.btnTrangThai_Click);
            //
            // cardMayBay
            //
            this.cardMayBay.Controls.Add(this.dgvMayBay);
            this.cardMayBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardMayBay.Name = "cardMayBay";
            this.cardMayBay.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardMayBay.Subtitle = "· mỗi hàng 5 ghế: A B C phổ thông, D phổ thông đặc biệt, E thương gia";
            this.cardMayBay.TabIndex = 1;
            this.cardMayBay.Title = "Đội máy bay";
            //
            // dgvMayBay
            //
            this.dgvMayBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMayBay.Name = "dgvMayBay";
            this.dgvMayBay.TabIndex = 0;
            //
            // ucMayBay
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.cardMayBay);
            this.Controls.Add(this.flpCongCu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucMayBay";
            this.Size = new System.Drawing.Size(1140, 760);
            this.flpCongCu.ResumeLayout(false);
            this.flpCongCu.PerformLayout();
            this.cardMayBay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMayBay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCongCu;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnThem;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnTrangThai;
        private QuanLyBanVeMayBay.Controls.CardPanel cardMayBay;
        private System.Windows.Forms.DataGridView dgvMayBay;
    }
}
