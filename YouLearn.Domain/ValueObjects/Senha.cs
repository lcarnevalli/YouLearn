using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Extensions;

namespace YouLearn.Domain.ValueObjects
{
    public class Senha: Notifiable 
    {
        protected Senha()
        {

        }
        public Senha(string valorSenha)
        {
            ValorSenha = valorSenha;

            new AddNotifications<Senha>(this).IfNullOrInvalidLength(x => x.ValorSenha, 3, 32);

            ValorSenha = ValorSenha.ConvertToMD5();

        }

        public string ValorSenha { get; private set; }
    }
}
