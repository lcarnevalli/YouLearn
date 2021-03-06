﻿using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServiceVideo : Notifiable, IServiceVideo
    {
        //dependencias do serviço usuário
        // quando alguém for usar meu serviço, ele deverá passar esse dado
        // quem faz isso é a configuração de injeção de dependencia.

        private readonly IRepositoryVideo _repositoryVideo;
        private readonly IRepositoryCanal _repositoryCanal;
        private readonly IRepositoryPlayList _repositoryPlayList;
        private readonly IRepositoryUsuario _repositoryUsuario;


        //construtor
        public ServiceVideo(IRepositoryVideo repositoryVideo, IRepositoryCanal repositoryCanal, IRepositoryPlayList repositoryPlayList, IRepositoryUsuario repositoryUsuario)
        {
            _repositoryVideo = repositoryVideo;
            _repositoryCanal = repositoryCanal;
            _repositoryPlayList = repositoryPlayList;
            _repositoryUsuario = repositoryUsuario;
        }

        public AdicionarVideoResponse AdicionarVideo(AdicionarVideoRequest request, Guid idUsuario)
        {
            if (request == null)
            {
                AddNotification("AdicionarVideoRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarVideoRequest"));

            }

            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            if (usuario == null)
            {
                AddNotification("usuario", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("usuario"));

            }

            Canal canal = _repositoryCanal.Obter(request.idCanal);
            if (canal == null)
            {
                AddNotification("canal", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("canal"));

            }
            PlayList playList = null;
            if (request.idPlayList != Guid.Empty)
            {
                playList = _repositoryPlayList.Obter(request.idPlayList);
                if (playList == null)
                {
                    AddNotification("PlayList", MSG.X0_NAO_INFORMADA.ToFormat("PlayList"));

                }

            }

            Video video = new Video(canal, playList, request.Titulo, request.Descricao, request.Tags, request.OrdemNaPlayList, request.IdVideoYoutube, usuario);

            AddNotifications(video);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositoryVideo.Adcionar(video);

            return new AdicionarVideoResponse(video.Id);

        }

        public Response ExcluirVideo(Guid idVideo)
        {
            Video video = _repositoryVideo.Obter(idVideo);

            if (video == null)
            {
                AddNotification("Video", MSG.DADOS_NAO_ENCONTRADOS);

            }

            if (this.IsInvalid()) return null;

            _repositoryVideo.Excluir(video);

            return new Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        //public IEnumerable<VideoResponse> ListarCanal(Guid idUsuario, Guid idCanal)
        //{
        //    IEnumerable<Video> videoCollection = _repositoryVideo.ListarCanal(idUsuario, idCanal);

        //    var response = videoCollection.ToList().Select(x => (VideoResponse)x);

        //    return response;
        //}

        //public IEnumerable<VideoResponse> ListarPlayList(Guid idUsuario, Guid idPlayList)
        //{
        //    IEnumerable<Video> videoCollection = _repositoryVideo.ListarPlayList(idUsuario, idPlayList);

        //    var response = videoCollection.ToList().Select(x => (VideoResponse)x);

        //    return response;
        //}


        public IEnumerable<VideoResponse> Listar(string tags)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.Listar(tags);

            var response = videoCollection.ToList().Select(x => (VideoResponse)x);

            return response;
        }
        public IEnumerable<VideoResponse> Listar(Guid idPlayList)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.Listar(idPlayList);

            var response = videoCollection.ToList().Select(x => (VideoResponse)x);

            return response;
        }
    }
}
