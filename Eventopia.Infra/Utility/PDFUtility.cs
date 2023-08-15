using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Text.RegularExpressions;

namespace Eventopia.Infra.Utility;
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

			var lines = body.Split('\n');

			// Draw each line separately
			var yPosition = 50;
			foreach (var line in lines)
			{
				var unescapedLine = Regex.Unescape(line); // Remove escape sequences
				var xRect = new XRect(10, yPosition, page.Width.Point, 0);
				gfx.DrawString(unescapedLine, font, XBrushes.Black, xRect, XStringFormats.TopLeft);
				yPosition += (int)font.Height; // Move down by the height of the font
			}

			document.Save(stream);
			return stream.ToArray();
		}
	}
}
