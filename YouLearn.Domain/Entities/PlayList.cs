using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entities
{
    public class PlayList : EntityBase
    {
        public PlayList(string nome, Usuario usuario)
        {
            Nome = nome;
            Usuario = usuario;
            Status = EnumStatus.EmAnalise;
                new AddNotifications<PlayList>(this)
                    .IfNullOrInvalidLength(x => x.Nome, 2, 50, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("2", "50"));

                AddNotifications(usuario);

        }

        //public Guid Id { get; set; }
        public string Nome { get; private set; }
        public Usuario Usuario { get; private set; }
        //EmAnalise, Aprovado ou Recusado
        public EnumStatus Status { get; private set; }

    }
}
