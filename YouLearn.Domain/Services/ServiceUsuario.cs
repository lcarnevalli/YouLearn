using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObjects;


namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        //dependencias do serviço usuário
        // quando alguém for usar meu serviço, ele deverá passar esse dado
        // quem faz isso é a configuração de injeção de dependencia.

        private readonly IRepositoryUsuario _repositoryUsuario;

        //construtor
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public AdicionarUsuarioResponse AdiconarUsuario(AdicionarUsuarioRequest request)
        {
            if (request == null)
            {
                //AddNotification("AdicionarUsuarioRequest", "Objeto Adicionar Usuario Respose é obrigatório");
                AddNotification("AdicionarUsuarioRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUsuarioRequest"));
            }
            //throw new System.NotImplementedException();
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            //AddNotifications(nome); // adiciono as notificacoes retornadas da classe de valor nome.
            // refatorado pois agora usuario adiciona os erros de nome

            //nome.PrimeiroNome = Request.PrimeiroNome;
            //nome.UltimoNome = Request.UltimoNome;
            //refatorado para ser colocado no objeto de valor, construtor, a validação
            var email = new Email(request.Email);
            //email.Endereco = Request.Email;
            //refatorado para ser colocado no objeto de valor, construtor, a validação
            //AddNotifications(email); // adiciono as notificacoes retornadas da classe de valor email.
            // refatorado pois agora usuario adiciona os erros de email
            // 
            var senha = new Senha(request.Senha);

            Usuario usuario = new Usuario(nome, email, senha);
            AddNotifications(usuario);
            //usuario.Nome.PrimeiroNome = Request.PrimeiroNome;
            //usuario.Nome.UltimoNome =Request.UltimoNome ;
            //refatorado para não mais acessar as propriedades do objeto de valor e sim atribuir o objeto de valor todo.
            //usuario.Nome = nome; // REFATORADO. COLOCADO NO CONSTRUTOR
            //usuario.Email.Endereco = Request.Email;
            //usuario.Email = email;// REFATORADO. COLOCADO NO CONSTRUTOR
            //usuario.Senha = Request.Senha;// REFATORADO. COLOCADO NO CONSTRUTOR

            //validações
            //if (usuario.Nome.PrimeiroNome.Length < 3 || usuario.Nome.PrimeiroNome.Length > 50)
            //{
            //    AddNotification("AdicionarUsuarioRequest",MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUsuarioRequest"));
            //    //throw new Exception("Primeiro nome é obrigatório e deve ter entre 3 a 50 characteres!");
            //    return null;
            //}
            //if (usuario.Nome.UltimoNome.Length < 3 || usuario.Nome.UltimoNome.Length > 50)
            //{
            //    //AddNotification("AdicionarUsuarioRequest", "Objeto Adicionar Usuario Respose é obrigatório");
            //    throw new Exception("Ultimo nome é obrigatório e deve ter entre 3 a 50 characteres!");
            //}
            // A responsabilidade de fazer estas validações são do objeto de valor
            //if (usuario.Email.Endereco.IndexOf("@") < 1)
            //{
            //    throw new Exception("Email Invalido!");
            //}
            // responsabilidade do objeto de valor se validar.
            //if (usuario.Senha.Length < 4)
            //{
            //    throw new Exception("Senha deve ter no mínimo 3 caracteres!");
            //}
            //REFATORADO --> LEVADO PARA A VALIDAÇÃO DO USUARIO E NÁO DENTRO DE SERVICOUSUARIO

            if (this.IsInvalid()) return null;

            // persiste no banco de dados

            _repositoryUsuario.Salvar(usuario);

            //AdicionarUsuarioResponse resposta = new RepositoryUsuario.save(usuario);
            //retorna sucesso ou erro
            return new AdicionarUsuarioResponse(usuario.Id);



        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            if (request == null)
            {
                //AddNotification("AdicionarUsuarioRequest", "Objeto Adicionar Usuario Respose é obrigatório");
                AddNotification("AutenticarUsuarioResponse", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AutenticarUsuarioResponse"));
            }

            var email = new Email(request.Email);
            var senha = new Senha(request.Senha);
            var usuario = new Usuario(email, senha);

            AddNotifications(usuario);

            if (this.IsInvalid()) return null;

            usuario = _repositoryUsuario.Obter(email, senha);

            if (usuario == null)
            {
                AddNotification("Usuario", MSG.DADOS_NAO_ENCONTRADOS);
            }

            //var response = new AutenticarUsuarioResponse()
            //{
            //    Id = usuario.Id,
            //    PrimeiroNome = usuario.Nome.PrimeiroNome
            //};
            //refatorando com conversao explicita
            // faz um cast para usuário e em autenticar usuário você mapeia a resposta

            return (AutenticarUsuarioResponse)usuario;
        }
    }
}
