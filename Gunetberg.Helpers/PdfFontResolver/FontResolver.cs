using PdfSharp.Fonts;

namespace Gunetberg.Helpers.PdfFontResolver
{
    public class FontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            return LoadFontData("OpenSans");
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            return new FontResolverInfo("OpenSans");
        }

        private byte[] LoadFontData(string name)
        {
            return Resources.ResourceFonts.OpenSans_Regular;
        }
    }
}
