using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Favorito : EntityBase
    {
        //public Guid Id { get; set; }
        public Video Video { get; set; }
        public Usuario Usuario { get; set; }

    }
}
