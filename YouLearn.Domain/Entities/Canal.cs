using System;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Canal : EntityBase
    {
        //public Guid Id { get; set; } 
        // removido pois foi refatorado no EntityBase

        public string Nome { get; set; }
        public string UrlLogo { get; set; }
        public Usuario Usuario { get; set; }

    }
}
