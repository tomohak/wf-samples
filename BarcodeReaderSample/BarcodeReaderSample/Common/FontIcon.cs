
namespace BarcodeReaderSample.Common
{
    public class FontIcon
    {
        private static readonly System.Drawing.Color defaultFontColor = System.Drawing.Color.Black;
        private static System.Drawing.Color defaultBackgroundColor = System.Drawing.Color.Transparent;

        public enum Glyphs
        {
            QRCode = 0xED14,
            Play = 0xE768,
            Stop = 0xE71A,
            Setting = 0xE713,
            Info = 0xE946,
            SignOut = 0xF3B1,
            Camera = 0xE114
        }

        public static System.Drawing.Icon CreateGlyphIcon(Glyphs glyph, int iconWidth = 16, int iconHeight = 16, float emSize = 12, System.Drawing.Color? fontColor = null, System.Drawing.Color? backgroundColor = null)
        {
            using (var b = new System.Drawing.Bitmap(iconWidth, iconHeight))
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b))
            using (System.Drawing.Brush brush = new System.Drawing.SolidBrush(fontColor ?? defaultFontColor))
            using (var f = new System.Drawing.Font("Segoe MDL2 Assets", emSize, System.Drawing.FontStyle.Regular))
            using (var sf = new System.Drawing.StringFormat { Alignment = System.Drawing.StringAlignment.Center, LineAlignment = System.Drawing.StringAlignment.Center })
            {
                g.Clear(backgroundColor ?? defaultBackgroundColor);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.DrawString(((char)glyph).ToString(), f, brush, new System.Drawing.Rectangle(0, 0, iconWidth, iconHeight), sf);

                return System.Drawing.Icon.FromHandle(b.GetHicon());
            }
        }
    }
}
