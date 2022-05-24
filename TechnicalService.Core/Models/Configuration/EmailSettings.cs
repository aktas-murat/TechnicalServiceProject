namespace TechnicalService.Core.Models.Configuration;

public class EmailSettings
{
    public string SenderMail { get; set; }
    public string Password { get; set; }
    public string Smtp { get; set; }
    public int SmtpPort { get; set; }
}