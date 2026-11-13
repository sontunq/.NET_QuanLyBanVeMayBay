using System.ComponentModel;
using System.Drawing.Drawing2D;
using QuanLyBanVeMayBay.Utils;

namespace QuanLyBanVeMayBay.Controls
{
    [DesignerCategory("Code")]
    public class FlatComboBox : ComboBox
    {
        private const int WM_PAINT = 0x000F;

        public FlatComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            FlatStyle = FlatStyle.Flat;
            ItemHeight = 34;
            Font = new Font("Segoe UI", 10.5F);
            BackColor = Color.White;
            ForeColor = AppTheme.Heading;
            Cursor = Cursors.Hand;
            IntegralHeight = false;
            MaxDropDownItems = 12;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            bool chon = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            bool laMat = (e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit;
            using (var b = new SolidBrush(chon && !laMat ? AppTheme.PrimarySoft : Color.White))
                e.Graphics.FillRectangle(b, e.Bounds);
            var r = new Rectangle(e.Bounds.X + 10, e.Bounds.Y, e.Bounds.Width - 14, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, GetItemText(Items[e.Index]), Font, r, AppTheme.Heading,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        protected override void OnGotFocus(EventArgs e) { base.OnGotFocus(e); Invalidate(); }
        protected override void OnLostFocus(EventArgs e) { base.OnLostFocus(e); Invalidate(); }
        protected override void OnSelectedIndexChanged(EventArgs e) { base.OnSelectedIndexChanged(e); Invalidate(); }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT && IsHandleCreated)
                using (var g = Graphics.FromHwnd(Handle))
                    VeMat(g);
        }

        private void VeMat(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(AppTheme.BackgroundOf(this));
            var r = new RectangleF(1, 1, Width - 3, Height - 3);
            using (var path = AppTheme.RoundedRect(r, 8))
            {
                using (var b = new SolidBrush(Enabled ? Color.White : AppTheme.Disabled)) g.FillPath(b, path);
                using (var p = new Pen(Focused || DroppedDown ? AppTheme.Primary : AppTheme.InputBorder, Focused ? 2f : 1f))
                    g.DrawPath(p, path);
            }

            string text = SelectedIndex >= 0 ? GetItemText(SelectedItem) : "";
            TextRenderer.DrawText(g, text, Font, new Rectangle(12, 0, Width - 44, Height),
                Enabled ? AppTheme.Heading : AppTheme.DisabledText,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            // Mũi tên
            float cx = Width - 20, cy = Height / 2f;
            using (var p = new Pen(AppTheme.Muted, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                g.DrawLines(p, new[] { new PointF(cx - 5, cy - 2.5f), new PointF(cx, cy + 2.5f), new PointF(cx + 5, cy - 2.5f) });
        }
    }
}
