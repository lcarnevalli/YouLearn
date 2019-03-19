using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario
    {
        Usuario Obter(Guid id);
        Usuario Obter(string email, string sennha);

        void Salvar(Usuario usuario);

        bool Existe(string email);
    }
}
