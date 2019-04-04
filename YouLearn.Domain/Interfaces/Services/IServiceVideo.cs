
using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceVideo : IServiceBase
    {

        IEnumerable<VideoResponse> ListarUsuario(Guid idUsuario);
        IEnumerable<VideoResponse> ListarCanal(Guid idUsuario, Guid idCanal);
        IEnumerable<VideoResponse> ListarPlayList(Guid idUsuario, Guid idCanal);
        VideoResponse AdicionarVideo(AdicionarVideoRequest request, Guid idUsuario);
        Response ExcluirVideo(Guid idVideo);
    }
}
