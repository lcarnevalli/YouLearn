using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayList
    {
        IEnumerable<PlayList> Listar(Guid IdUsuario);
        PlayList Obter(Guid idPlayList);
        PlayList Adicionar(PlayList playList);
        void Excluir(PlayList playList);
    }
}
