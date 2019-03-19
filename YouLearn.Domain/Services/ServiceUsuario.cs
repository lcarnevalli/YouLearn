using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        public AdicionarUsuarioResponse AdiconarUsuario(AdicionarUsuarioRequest Request)
        {
            if (Request == null)
            {
                AddNotification("AdicionarUsuarioRequest", "Objeto Adicionar Usuario Respose é obrigatório");
            }
            //throw new System.NotImplementedException();
            var nome = new Nome(Request.PrimeiroNome, Request.UltimoNome);
            //AddNotifications(nome); // adiciono as notificacoes retornadas da classe de valor nome.
            // refatorado pois agora usuario adiciona os erros de nome

            //nome.PrimeiroNome = Request.PrimeiroNome;
            //nome.UltimoNome = Request.UltimoNome;
            //refatorado para ser colocado no objeto de valor, construtor, a validação
            var email = new Email(Request.Email);
            //email.Endereco = Request.Email;
            //refatorado para ser colocado no objeto de valor, construtor, a validação
            //AddNotifications(email); // adiciono as notificacoes retornadas da classe de valor email.
            // refatorado pois agora usuario adiciona os erros de email

            Usuario usuario = new Usuario(nome, email, Request.Senha);
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
            //AdicionarUsuarioResponse resposta = new RepositoryUsuario.save(usuario);
            //retorna sucesso ou erro
            return new AdicionarUsuarioResponse(Guid.NewGuid());



        }

        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
