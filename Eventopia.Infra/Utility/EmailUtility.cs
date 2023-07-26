using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Eventopia.Infra.Utility;

public static class EmailUtility
{
	public static async Task SendEmailAsync(string subject
		, string body
		, string toEmail
		, string fromEmail= "EventOpiaTeam@outlook.com")
	{
		SmtpClient _smtpClient = new SmtpClient();
		_smtpClient.Connect("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
		_smtpClient.Authenticate("EventOpiaTeam@outlook.com", "EventOpia123!@#");

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
		, string fromEmail = "EventOpiaTeam@outlook.com")
	{
		SmtpClient _smtpClient = new SmtpClient();
		_smtpClient.Connect("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
		_smtpClient.Authenticate("EventOpiaTeam@outlook.com", "EventOpia123!@#@");

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
