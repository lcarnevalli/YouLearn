using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryVideo
    {
        IEnumerable<Video> Listar(string tags);
        IEnumerable<Video> Listar(Guid IdPlayList);
        //IEnumerable<Video> ListarPlayList(Guid IdUsuario, Guid idPlayList);
        bool ExisteCanalAssociado(Guid idCanal);
        bool ExistePlayListAssociada(Guid idPlayList);

        Video Obter(Guid idVideo);
        Video Adcionar(Video video);
        void Excluir(Video video);

    }
}
