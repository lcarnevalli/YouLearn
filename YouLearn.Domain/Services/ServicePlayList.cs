using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServicePlayList : Notifiable, IServicePlayList
    {
        //dependencias do serviço usuário
        // quando alguém for usar meu serviço, ele deverá passar esse dado
        // quem faz isso é a configuração de injeção de dependencia.

        private readonly IRepositoryPlayList _repositoryPlayList;

        private readonly IRepositoryUsuario _repositoryUsuario;

        private readonly IRepositoryVideo _repositoryVideo;

        public ServicePlayList(IRepositoryUsuario repositoryUsuario,IRepositoryPlayList repositoryPlayList,  IRepositoryVideo repositoryVideo)
        {
            _repositoryPlayList = repositoryPlayList;
            _repositoryUsuario = repositoryUsuario;
            _repositoryVideo = repositoryVideo;
        }

        //construtor


        public PlayListResponse AdicionarPlayList(AdicionarPlayListRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            PlayList playlist = new PlayList(request.Nome, usuario);

            AddNotifications(playlist);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositoryPlayList.Adicionar(playlist);

            return (PlayListResponse)playlist;

        }

        public Response ExcluirPlayList(Guid idPlayList)
        {
            bool existe = _repositoryVideo.ExistePlayListAssociada(idPlayList);
            
            if (existe)
            {
                AddNotification("PlayList", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("PlayList","Video"));
            }

            PlayList playList = _repositoryPlayList.Obter(idPlayList);

            if (playList == null)
            {
                AddNotification("PlayList", MSG.DADOS_NAO_ENCONTRADOS);

            }

            if (this.IsInvalid()) return null;

            _repositoryPlayList.Excluir(playList);

            return new Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<PlayListResponse> Listar(Guid idUsuario)
        {
            IEnumerable<PlayList> playListCollection = _repositoryPlayList.Listar(idUsuario);

            var response = playListCollection.ToList().Select(x => (PlayListResponse)x);

            return response;
        }
    }
}
