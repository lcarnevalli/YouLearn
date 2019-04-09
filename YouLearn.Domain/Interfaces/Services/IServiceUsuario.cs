
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase
    {
        //void AdicionarUsuario(string PrimeiroNome, string UltimoNome, string Email, string Senha) { }
        // Dessa maneira, se em algum momento for incluído um novo parametro em usuário eu tenho que alterar a chamada da minha função. Por exemplo, adicionar endereço do usuário.
        // void AdicionarUsuario(string PrimeiroNome, string UltimoNome, string Email, string Senha, string Endereco) { }
        // e assim refatorar em todos os locais que é chamado o adiconar usuário.
        // uma forma mais elegante é eu trabalhar com objetos complexos (tanto para passagem de parametros como para resposta.
        // Adicona-se o sufixo Response ao nome da interface e é criado um objeto complexo com o nome da função mais o sufixo Request.
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest Request);

        AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request);
   
        

    }
}
