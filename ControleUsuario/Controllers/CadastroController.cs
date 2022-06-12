using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {

        [HttpPost]
        public IActionResult CadastroUsuario()
        {
            // service

            return Ok();
        }
    }
}
