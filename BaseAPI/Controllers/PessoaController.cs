using BaseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        [HttpPost]
        public void AdicionarPessoa([FromBody] Pessoa pessoa)
        {
            // lógica
        }
    }
}
