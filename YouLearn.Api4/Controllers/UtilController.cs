using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouLearn.Api4.Controllers
{
    public class UtilController
    {
       [HttpGet]
       [Route("")]
       public object Versao()
        {
            return new { Desenvolvedor = "Leonido", VersaoApi = "0.0.1" };

        }

        [HttpPost]
        [Route("")]
        public string Post()
        {
            return "executou o post - insere informação";

        }

        [HttpPut]
        [Route("")]
        public string Put()
        {
            return "executou o PUT - atualiza informação";

        }

        [HttpDelete]
        [Route("")]
        public string Delete()
        {
            return "executou o DELETE - apaga informação";

        }
    }
}
