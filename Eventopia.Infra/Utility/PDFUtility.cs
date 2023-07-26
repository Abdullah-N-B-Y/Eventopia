using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Infra.Utility
{
	public static class PDFUtility
	{
		public static byte[] GeneratePdf(string body)
		{
			using (var stream = new MemoryStream())
			{
				var document = new PdfDocument();
				var page = document.AddPage();

				var font = new XFont("Arial", 12);
				var gfx = XGraphics.FromPdfPage(page);

				var xRect = new XRect(10, 50, page.Width.Point, 0);
				gfx.DrawString(body, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

				document.Save(stream);
				return stream.ToArray();
			}
		}
	}
}
