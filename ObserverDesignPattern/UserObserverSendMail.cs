using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MimeKit;
using ObserverDesignPattern.Upschool.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverDesignPattern.Upschool.ObserverDesignPattern
{
    public class UserObserverSendMail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendMail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin Observer","testozge8@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",appUser.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var budyBuilder = new BodyBuilder();
            budyBuilder.TextBody = "Observer Design Pattern dersimizde bu adıma gelebildiğiniz için size indirim kodu tanımladık. İndirim Kodunuz: GIF2023";

            mimeMessage.Body = budyBuilder.ToMessageBody();
            mimeMessage.Subject = "Hoş Geldin İndirimi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("testozge8@gmail.com", "enodxsnicrvxqoap");
            client.Send(mimeMessage);
            client.Disconnect(true);

            logger.LogInformation($"{appUser.Name + " " + appUser.Surname} isimli kullanıcının {appUser.Email} adlı mail adresine indirim kodu maili başarıyla gönderilmiştir.");
        }
    }
}
