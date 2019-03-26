using System;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        //public Nome()
        //{

        //}
        public Nome(string primeiroNome, string ultimoNome)
        {
            //if (primeiroNome.Length < 3 || primeiroNome.Length > 50)
            //{
            //    AddNotification ("AdicionarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUsuarioRequest"));
            //    //throw new Exception("Primeiro nome é obrigatório e deve ter entre 3 a 50 characteres!");
            //    return null;
            //}
            // Refatorado utilizando addnotifications

            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES)
                .IfNullOrInvalidLength(x => x.UltimoNome, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES);


            //if (ultimoNome.Length < 3 || ultimoNome.Length > 50)
            //{
            //    //AddNotification("AdicionarUsuarioRequest", "Objeto Adicionar Usuario Respose é obrigatório");
            //    throw new Exception("Ultimo nome é obrigatório e deve ter entre 3 a 50 characteres!");
            //}
            //new AddNotifications<Nome>(this)
            //     .IfNullOrInvalidLength(x => x.UltimoNome, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES);

            //REFATORADO --> colocado tudo dentro do mesmo notifications.

        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        //centralizo a validação do nome dentro da classe de valueObject nome.
    }
}
