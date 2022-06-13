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
    public class LogoutController : ControllerBase
    {
        private readonly LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogarUsuario()
        {
            Result resultado = _logoutService.DeslogarUsuario();
            if (resultado.IsFailed) return Unauthorized();

            return Ok(resultado.Successes);
        }

    }
}
