using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryCanal
    {
        IEnumerable<Canal> Listar(Guid IdUsuario);
        Canal Obter(Guid idCanal);
        Canal Adicionar(Canal canal);
        void Excluir(Canal canal);
    }
}
