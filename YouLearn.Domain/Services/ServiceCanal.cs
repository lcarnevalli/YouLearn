using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServiceCanal : Notifiable, IServiceCanal
    {
        //dependencias do serviço usuário
        // quando alguém for usar meu serviço, ele deverá passar esse dado
        // quem faz isso é a configuração de injeção de dependencia.

        private readonly IRepositoryCanal _repositoryCanal;

        private readonly IRepositoryUsuario _repositoryUsuario;

        //construtor
        public ServiceCanal(IRepositoryUsuario repositoryUsuario , IRepositoryCanal repositoryCanal)
        {
            _repositoryCanal = repositoryCanal;
            _repositoryUsuario = repositoryUsuario;
        }

        public CanalResponse AdicionarCanal(AdicionarCanalRequest request, Guid idUsuario)
        {
            Usuario usuario = _repositoryUsuario.Obter(idUsuario);

            Canal canal = new Canal(request.Nome, request.UrlLogo, usuario);

            AddNotifications(canal);

            if (this.IsInvalid())
            {
                return null;
            }

            _repositoryCanal.Adicionar(canal);

            return (CanalResponse)canal;

        }

        public Response ExcluirCanal(Guid idCanal)
        {
            //bool existe _repositoryVideo.ExisteCanalAssociada(idCanal)
            bool existe = false;
            if (existe)
            {
                AddNotification("Canal", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("Canal", "Video"));
            }

            Canal canal = _repositoryCanal.Obter(idCanal);

            if (canal == null)
            {
                AddNotification("Canal", MSG.DADOS_NAO_ENCONTRADOS);

            }

            if (this.IsInvalid()) return null;

            _repositoryCanal.Excluir(canal);

            return new Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public IEnumerable<CanalResponse> Listar(Guid idUsuario)
        {
            IEnumerable<Canal> canalCollection = _repositoryCanal.Listar(idUsuario);

            var response = canalCollection.ToList().Select(x => (CanalResponse)x);

            return response;
        }
    }
}
