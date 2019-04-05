using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryVideo
    {
        IEnumerable<Video> Listar(Guid IdUsuario);
        IEnumerable<Video> ListarCanal(Guid IdUsuario, Guid idCanal);
        IEnumerable<Video> ListarPlayList(Guid IdUsuario, Guid idPlayList);
        Video Obter(Guid idVideo);
        Video Adcionar(Video video, Guid idUsuario);
        void Excluir(Video video);

    }
}
