namespace QuanLyBanVeMayBay.GUI
{
    partial class frmThongBao
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
            this.picIcon = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.flpNut = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.btnHuy = new QuanLyBanVeMayBay.Controls.RoundedButton();
            this.flpNut.SuspendLayout();
            this.SuspendLayout();
            //
            // picIcon
            //
            this.picIcon.Location = new System.Drawing.Point(28, 28);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(52, 52);
            this.picIcon.TabIndex = 0;
            this.picIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.picIcon_Paint);
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.lblTieuDe.Location = new System.Drawing.Point(96, 28);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(92, 23);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "Thông báo";
            //
            // lblNoiDung
            //
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.lblNoiDung.Location = new System.Drawing.Point(97, 60);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(330, 40);
            this.lblNoiDung.TabIndex = 2;
            this.lblNoiDung.Text = "Nội dung";
            //
            // flpNut
            //
            this.flpNut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flpNut.AutoSize = true;
            this.flpNut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpNut.Controls.Add(this.btnOK);
            this.flpNut.Controls.Add(this.btnHuy);
            this.flpNut.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpNut.Location = new System.Drawing.Point(196, 124);
            this.flpNut.Name = "flpNut";
            this.flpNut.Size = new System.Drawing.Size(236, 46);
            this.flpNut.TabIndex = 3;
            this.flpNut.WrapContents = false;
            //
            // btnOK
            //
            this.btnOK.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Primary;
            this.btnOK.Location = new System.Drawing.Point(119, 3);
            this.btnOK.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(117, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Đóng";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // btnHuy
            //
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Kind = QuanLyBanVeMayBay.Controls.ButtonKind.Outline;
            this.btnHuy.Location = new System.Drawing.Point(0, 3);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(111, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.Visible = false;
            //
            // frmThongBao
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(460, 196);
            this.Controls.Add(this.flpNut);
            this.Controls.Add(this.lblNoiDung);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.picIcon);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmThongBao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông báo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThongBao_KeyDown);
            this.flpNut.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel picIcon;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.FlowLayoutPanel flpNut;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnOK;
        private QuanLyBanVeMayBay.Controls.RoundedButton btnHuy;
    }
}
