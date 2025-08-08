namespace Rifoms.Domain.Infrastructure.Settings
{
    /// <summary>
    /// Класс для настроек отправки писем
    /// образцы кода 
    /// https://codewithmukesh.com/blog/send-emails-with-aspnet-core/
    /// http://www.1gb.ru/hosting_email.php
    /// </summary>   
    /// <param name="Login">Login для авторизации на smtp servere 1gb.ru, в коде не используется</param>
    /// <param name="Password">Password для авторизации на smtp servere 1gb.ru, в коде не используется</param>
    /// <param name="Port">Port для connecta на smtp servere 1gb.ru</param>
    /// <param name="From">От кого отправляется письмо</param>
    /// <param name="DisplayName">Отображаемое имя в письме</param>
    /// <param name="Host">Host smtp-servera  с которого тправляется письмо</param>

    public class MailSettings
    {
        public string From { get; set; }
        public string DisplayName { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        //public string Password { get; set; }
        //public string Login { get; set; }
    }
}
