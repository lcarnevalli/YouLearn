using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Extensions;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Entities
{
    public class Usuario : EntityBase
    {
        protected Usuario() {
            }

        public Usuario(Email email, Senha senha)
        {
            Email = email;
            Senha = senha;

            AddNotifications(email, senha);
        }

        public Usuario(Nome nome, Email email, Senha senha)
        {
            //if (usuario.Senha.Length < 4)
            //{
            //    throw new Exception("Senha deve ter no mínimo 3 caracteres!");
            //}
            Senha = senha;
            Nome = nome;
            Email = email;
            
            AddNotifications(nome, email, senha);

            

        }

        //public Guid Id { get; set; }
        // por herança criamos uma entidade para gerar o id e herdar nesta
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }

    }
}
