using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.ValueObjects
{
    public class Email: Notifiable
    {
        protected Email()
        {

        }
        public Email(string endereco)
        {
            //if (endereco.IndexOf("@") < 1)
            //{
            //    throw new Exception("Email Invalido!");
            //}
            Endereco = endereco;
            new AddNotifications<Email>(this)
                .IfNotEmail(x=> x.Endereco, MSG.X0_INVALIDO.ToFormat("E-mail"));
            
        }

        public string Endereco { get; private set; }

    }
}
