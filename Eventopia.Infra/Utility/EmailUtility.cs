using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Eventopia.Infra.Utility;

public static class EmailUtility
{
	public static void SendEmailAsync(string subject
		, string body
		, string toEmail
		, string fromEmail= "your email address")
	{
		SmtpClient _smtpClient = new SmtpClient();
		_smtpClient.Connect("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
		_smtpClient.Authenticate("your email address", "your password");

		var message = new MimeMessage();
		message.From.Add(new MailboxAddress("Sender", fromEmail));
		message.To.Add(new MailboxAddress("Recipient", toEmail));
		message.Subject = subject;

		var bodyBuilder = new BodyBuilder();
		bodyBuilder.TextBody = body;

		message.Body = bodyBuilder.ToMessageBody();

		_smtpClient.Send(message);
		_smtpClient.Disconnect(true);
	}

	public static void SendEmailWithPDFAsync(string subject
		, string body
		, string pdfSubject
		, string pdfBody
		, string toEmail
		, string fromEmail = "email")
	{
		SmtpClient _smtpClient = new SmtpClient();
		_smtpClient.Connect("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
		_smtpClient.Authenticate("email", "auth code");

		var message = new MimeMessage();
		message.From.Add(new MailboxAddress("Eventopia", fromEmail));
		message.To.Add(new MailboxAddress("Customer", toEmail));
		message.Subject = subject;

		var bodyBuilder = new BodyBuilder();
		bodyBuilder.TextBody = body;

		var pdfBytes = PDFUtility.GeneratePdf(pdfBody);
		bodyBuilder.Attachments.Add($"{pdfSubject}.pdf", pdfBytes, ContentType.Parse("application/pdf"));

		message.Body = bodyBuilder.ToMessageBody();

		_smtpClient.Send(message);
		_smtpClient.Disconnect(true);
	}
}
