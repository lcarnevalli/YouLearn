using System;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AutenticarUsuarioResponse
    {
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }

        public static explicit operator AutenticarUsuarioResponse(Entities.Usuario entidadeUsuario)
        {
            return new AutenticarUsuarioResponse()
            {
                Id = entidadeUsuario.Id,
                PrimeiroNome = entidadeUsuario.Nome.PrimeiroNome
            };
        }
    }
}
