using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;
using YouLearn.Api4.Controllers.Base;


namespace YouLearn.Api4.Controllers
{
    public class UsuarioController : Base.ControllerBase
    {
        private readonly IServiceUsuario _serviceUsuario;

        public UsuarioController(IUnitOfWork unitOfWork, IServiceUsuario serviceUsuario) : base (unitOfWork)
        {
            _serviceUsuario = serviceUsuario;
        }

        //[AllowAnonymous]
        [HttpPost]
        [Route("api/v1/Usuario/Adicionar")]

        public async Task <IActionResult> Adicionar ([FromBody] AdicionarUsuarioRequest request)
        {
            try
            {
                var response = _serviceUsuario.AdiconarUsuario(request);
                return await ResponseAsync(response, _serviceUsuario);


            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }

        }


    }
}
