namespace Application.Models.Infrastructure;

public class Email
{
    public string To { get; private set; }
    public string Subject { get; private set; }
    public string Body { get; private set; } 
    
    private Email()
    {
        
    }

    public static Email Create(string to, string subject, string body)
    {
        return new Email
        {
            To = to,
            Subject = subject,
            Body = body
        };
    }

}