using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Services;

namespace YouLearn.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AdicionarUsuarioRequest request = new AdicionarUsuarioRequest()
            {
                Email = "lcarnevalli@globo.com",
                PrimeiroNome = "Leonildo",
                UltimoNome = "Carnevalli Junior",
                Senha = "12"
            };

            //var response = new ServiceUsuario().AdiconarUsuario(request);
            

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
