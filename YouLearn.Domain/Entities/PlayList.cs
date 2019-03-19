using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class PlayList : EntityBase
    {
        //public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        //EmAnalise, Aprovado ou Recusado
        public EnumStatus Status { get; set; }

    }
}
