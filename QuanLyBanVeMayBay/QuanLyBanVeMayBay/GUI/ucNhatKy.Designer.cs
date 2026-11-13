namespace QuanLyBanVeMayBay.GUI
{
    partial class ucNhatKy
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
            this.btnLamMoi = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.cardNhatKy = new QuanLyBanVeMayBay.Controls.CardPanel();
            this.dgvNhatKy = new System.Windows.Forms.DataGridView();
            this.flpCongCu.SuspendLayout();
            this.cardNhatKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKy)).BeginInit();
            this.SuspendLayout();
            //
            // flpCongCu
            //
            this.flpCongCu.Controls.Add(this.btnLamMoi);
            this.flpCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCongCu.Name = "flpCongCu";
            this.flpCongCu.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.flpCongCu.Size = new System.Drawing.Size(1140, 56);
            this.flpCongCu.TabIndex = 0;
            this.flpCongCu.WrapContents = false;
            //
            // btnLamMoi
            //
            this.btnLamMoi.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0, 4, 10, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 42);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // cardNhatKy
            //
            this.cardNhatKy.Controls.Add(this.dgvNhatKy);
            this.cardNhatKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardNhatKy.Name = "cardNhatKy";
            this.cardNhatKy.Padding = new System.Windows.Forms.Padding(22, 50, 22, 16);
            this.cardNhatKy.Subtitle = "· 500 thao tác gần nhất";
            this.cardNhatKy.TabIndex = 1;
            this.cardNhatKy.Title = "Nhật ký hoạt động";
            //
            // dgvNhatKy
            //
            this.dgvNhatKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhatKy.Name = "dgvNhatKy";
            this.dgvNhatKy.TabIndex = 0;
            //
            // ucNhatKy
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.cardNhatKy);
            this.Controls.Add(this.flpCongCu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ucNhatKy";
            this.Size = new System.Drawing.Size(1140, 760);
            this.flpCongCu.ResumeLayout(false);
            this.cardNhatKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCongCu;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnLamMoi;
        private QuanLyBanVeMayBay.Controls.CardPanel cardNhatKy;
        private System.Windows.Forms.DataGridView dgvNhatKy;
    }
}
