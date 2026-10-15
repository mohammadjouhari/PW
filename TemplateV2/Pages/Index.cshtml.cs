using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using MailKit.Net.Smtp;
using MimeKit;

namespace Talal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public ContactInputModel ContactForm { get; set; } = new();

        [TempData]
        public string? SuccessMessage { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 465; // or 587
                string smtpUser = "Mohammad.Jouhari@gmail.com";
                string smtpPass = "xcuj rafr oqwa ahny";
                string recipientEmail = "Mohammad.Jouhari@gmail.com";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Mohammad.dev Portfolio", smtpUser));
                message.To.Add(new MailboxAddress("", recipientEmail));
                message.Subject = $"[Portfolio Contact] {ContactForm.Subject}";

                message.ReplyTo.Add(new MailboxAddress(ContactForm.Name, ContactForm.Email));

                message.Body = new TextPart("plain")
                {
                    Text = $"You have a new message from your portfolio contact form:\n\n" +
                           $"Name: {ContactForm.Name}\n" +
                           $"Email: {ContactForm.Email}\n" +
                           $"Subject: {ContactForm.Subject}\n\n" +
                           $"Message:\n{ContactForm.Message}"
                };

                using var client = new SmtpClient();

                // Port 465 requires SecureSocketOptions.SslOnConnect
                // Port 587 requires SecureSocketOptions.StartTls
                await client.ConnectAsync(smtpHost, smtpPort, MailKit.Security.SecureSocketOptions.SslOnConnect);

                await client.AuthenticateAsync(smtpUser, smtpPass);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                SuccessMessage = "Your message has been sent successfully! Thank you for reaching out.";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred while sending your message: {ex.Message}";
            }

            return Page();
        }
    }

    public class ContactInputModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Subject is required.")]
        [StringLength(150, ErrorMessage = "Subject cannot exceed 150 characters.")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(2000, ErrorMessage = "Message cannot exceed 2000 characters.")]
        public string Message { get; set; } = string.Empty;
    }
}