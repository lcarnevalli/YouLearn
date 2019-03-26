using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario
    {
        Usuario Obter(Guid id);
        Usuario Obter(Email email, Senha senha);
        void Salvar(Usuario usuario);
        bool Existe(Email email);
    }
}
