namespace QuanLyBanVeMayBay.GUI
{
    partial class frmTrangThai
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
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new QuanLyBanVeMayBay.Controls.FlatComboBox();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnCapNhat = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.SuspendLayout();
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoEllipsis = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(340, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Đổi trạng thái";
            //
            // lblTrangThai
            //
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.lblTrangThai.Location = new System.Drawing.Point(28, 66);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(71, 13);
            this.lblTrangThai.Text = "TRẠNG THÁI";
            //
            // cboTrangThai
            //
            this.cboTrangThai.Location = new System.Drawing.Point(28, 86);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(336, 40);
            this.cboTrangThai.TabIndex = 1;
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(140, 148);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 44);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy bỏ";
            //
            // btnCapNhat
            //
            this.btnCapNhat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCapNhat.Location = new System.Drawing.Point(254, 148);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(110, 44);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập nhật";
            //
            // frmTrangThai
            //
            this.AcceptButton = this.btnCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(392, 214);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTrangThai";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trạng thái";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTrangThai;
        private QuanLyBanVeMayBay.Controls.FlatComboBox cboTrangThai;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnCapNhat;
    }
}
