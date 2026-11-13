using System.Drawing.Text;

namespace QuanLyBanVeMayBay.Utils
{
    public static class IconFont
    {
        public const string Home = "";
        public const string Cart = "";
        public const string Document = "";
        public const string Search = "";
        public const string People = "";
        public const string Calendar = "";
        public const string Airplane = "";
        public const string Chart = "";
        public const string Lock = "";
        public const string History = "";
        public const string SignOut = "";
        public const string Swap = "";
        public const string Check = "";
        public const string Info = "";
        public const string Warning = "";
        public const string Error = "";
        public const string Question = "";
        public const string Card = "";
        public const string Cancel = "";
        public const string Add = "";

        private static string _family;
        private static bool _checked;

        public static string FamilyName
        {
            get
            {
                if (!_checked)
                {
                    _checked = true;
                    using (var fonts = new InstalledFontCollection())
                    {
                        var names = fonts.Families.Select(f => f.Name).ToList();
                        if (names.Contains("Segoe Fluent Icons")) _family = "Segoe Fluent Icons";
                        else if (names.Contains("Segoe MDL2 Assets")) _family = "Segoe MDL2 Assets";
                    }
                }
                return _family;
            }
        }

        public static bool Available => FamilyName != null;

        public static Font Get(float size)
        {
            return new Font(FamilyName ?? "Segoe UI", size);
        }

        public static string Glyph(string glyph)
        {
            return Available ? glyph : "";
        }
    }
}
