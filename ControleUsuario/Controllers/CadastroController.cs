using ControleUsuario.Data.Dtos.UsuarioDto;
using ControleUsuario.Services;
using FluentResults;
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
        private readonly CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastroUsuario(CreateUsuarioDto usuarioDto)
        {
            Result result = _cadastroService.CadastroUsuario(usuarioDto);

            if (result.IsFailed) return StatusCode(500);

            return Ok(result.Successes);
        }
    }
}
