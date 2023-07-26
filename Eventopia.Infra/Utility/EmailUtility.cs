using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace Eventopia.Infra.Utility
{
	public static class EmailUtility
	{
		public static async Task SendEmailAsync(string subject
			, string body
			, string toEmail
			, string fromEmail= "giftmaker1@outlook.com")
		{
			SmtpClient _smtpClient = new SmtpClient();
			_smtpClient.Connect("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
			_smtpClient.Authenticate("giftmaker1@outlook.com", "Q2W3e4r5@");

			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Sender", fromEmail));
			message.To.Add(new MailboxAddress("Recipient", toEmail));
			message.Subject = subject;

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = body;

			message.Body = bodyBuilder.ToMessageBody();

			await _smtpClient.SendAsync(message);
			_smtpClient.Disconnect(true);
		}

		public static async Task SendEmailWithPDFAsync(string subject
			, string body
			, string pdfSubject
			, string pdfBody
			, string toEmail
			, string fromEmail = "giftmaker1@outlook.com")
		{
			SmtpClient _smtpClient = new SmtpClient();
			_smtpClient.Connect("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
			_smtpClient.Authenticate("giftmaker1@outlook.com", "Q2W3e4r5@");

			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Sender", fromEmail));
			message.To.Add(new MailboxAddress("Recipient", toEmail));
			message.Subject = subject;

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = body;

			var pdfBytes = PDFUtility.GeneratePdf(pdfBody);
			bodyBuilder.Attachments.Add($"{pdfSubject}.pdf", pdfBytes, ContentType.Parse("application/pdf"));

			message.Body = bodyBuilder.ToMessageBody();

			await _smtpClient.SendAsync(message);
			_smtpClient.Disconnect(true);
		}


	}
}
