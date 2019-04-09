using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLearn.Api4.Controllers
{
    public class UtilController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/Versao")]
        public object Versao()
        {
            return new { Desenvolvedor = "Leonido", VersaoApi = "0.0.1" };

        }
    }
}
