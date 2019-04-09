using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api4.Controllers
{
    public class CanalController : Base.ControllerBase
    {
        private readonly IServiceCanal _serviceCanal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CanalController(IHttpContextAccessor httpContextAccessor, IUnitOfWork iUnitOfWork, IServiceCanal serviceCanal) : base(iUnitOfWork)
        {
            _serviceCanal = serviceCanal;
            _httpContextAccessor = httpContextAccessor;
        }


        //[AllowAnonymous]
        [HttpGet]
        [Route("api/v1/canal/Listar")]
        public async Task<IActionResult> Listar()
        {

            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);


                var response = _serviceCanal.Listar(usuarioResponse.Id);

                return await ResponseAsync(response, _serviceCanal);

            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);

                throw;
            }
        }

        [HttpPost]
        [Route("api/v1/canal/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarCanalRequest request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _serviceCanal.AdicionarCanal(request, usuarioResponse.Id);

                return await ResponseAsync(response, _serviceCanal);

            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }

        }

        [HttpDelete]
        [Route("api/v1/Canal/Excluir/{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var response = _serviceCanal.ExcluirCanal(id);

                return await ResponseAsync(response, _serviceCanal);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
