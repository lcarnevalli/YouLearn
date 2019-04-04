using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Arguments.Canal
{
    public class CanalResponse
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string UrlLogo { get; private set; }

        public static explicit operator CanalResponse(Entities.Canal entidade)
        {
            return new CanalResponse()
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                UrlLogo = entidade.UrlLogo
            };
        }
    }
}
