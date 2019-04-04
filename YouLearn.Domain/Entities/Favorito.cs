using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Favorito : EntityBase
    {
        //public Guid Id { get; set; }
        public Video Video { get; private set; }
        public Usuario Usuario { get; private set; }

    }
}
