using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Extensions;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario(Nome nome, Email email, string senha)
        {
            //if (usuario.Senha.Length < 4)
            //{
            //    throw new Exception("Senha deve ter no mínimo 3 caracteres!");
            //}
            

            senha = senha.ConvertToMD5();
            Nome = nome;
            Email = email;
            Senha = senha;

            AddNotifications(nome, email);

            new AddNotifications<Usuario>(this).IfNullOrInvalidLength(x => x.Senha, 3,32);

        }

        //public Guid Id { get; set; }
        // por herança criamos uma entidade para gerar o id e herdar nesta
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }

    }
}
