using Gunetberg.Helpers.PdfFontResolver;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gunetberg.Helpers
{
    public class DownloaderHelper
    {
        private static DownloaderHelper instance;

        private DownloaderHelper()
        {
            GlobalFontSettings.FontResolver = new FontResolver();
        }

        public static DownloaderHelper GetInstance()
        {
            if (instance == null)
                instance = new DownloaderHelper();

            return instance;
        }

        public byte[] GeneratePostPdf(string title, string author, DateTime date,  IEnumerable<string> sections)
        {
            var document = new PdfDocument();
            var page = document.AddPage();
            var graphics = XGraphics.FromPdfPage(page);
            var textFormatter = new XTextFormatter(graphics);
            textFormatter.Alignment = XParagraphAlignment.Justify;

            var headerFont = new XFont("Open Sans", 30, XFontStyle.Regular);
            var subHeaderFont = new XFont("Open Sans", 12, XFontStyle.Regular);
            var paragraphFont = new XFont("Open Sans", 10, XFontStyle.Regular);

            var margin = 40;
            var top = margin + 30;
            graphics.DrawString(title, headerFont, XBrushes.Black, new XRect(margin, top, page.Width-margin*2, 20), XStringFormats.Center);
            top += 30;
            graphics.DrawString(author+", "+date.ToString("MM/dd/yyyy"), subHeaderFont, XBrushes.Black, new XRect(margin, top, page.Width - margin * 2, 20), XStringFormats.Center);

            top += 50;
            var charSize = 10;
            var lineSize = (int)Math.Ceiling(charSize * 1.5);
            var maxChars = ((int)(page.Width - margin * 2) / charSize)*2;
            
            foreach (var section in sections)
            {
                var numberOfLines = (int)Math.Round((float)section.Length / maxChars) +1;

                var rect = new XRect(margin, top, page.Width-margin*2, numberOfLines*lineSize);
                textFormatter.DrawString(section, paragraphFont, XBrushes.Black, rect, XStringFormats.TopLeft);

                top += numberOfLines * lineSize+10;
            }

            using (var ms = new MemoryStream())
            {
                document.Save(ms, true);

                return ms.ToArray();
            }

        }
    }
}
