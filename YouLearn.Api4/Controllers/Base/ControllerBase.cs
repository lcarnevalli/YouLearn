using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Domain.Interfaces.Services.Base;
using YouLearn.Infra.Transactions;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace YouLearn.Api4.Controllers.Base
{
    public class ControllerBase : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServiceBase _serviceBase;

        public ControllerBase (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ResponseAsync(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;
            if (!serviceBase.Notifications.Any())
            {
                try
                {
                    _unitOfWork.Commit();

                    return Ok(result);

                }
                catch (Exception ex)
                {

                    return BadRequest($"Houve um problema interno do servidor. Entre em contato com o administrador do Sistema");
                }
            }
            else
            {
                return BadRequest(new { errors = serviceBase.Notifications });
            }
        }

        public async Task <IActionResult> ResponseExceptionAsync (Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exeption = ex.ToString() });
        }

    }
}
