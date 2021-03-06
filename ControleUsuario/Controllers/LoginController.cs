using ControleUsuario.Data.Requests;
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
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogarUsuario(request);

            if (resultado.IsFailed) return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }

        [HttpPost("/solicitar-reset")]
        public IActionResult SolicitarResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaResetSenhaUsuario(request);

            if (resultado.IsFailed) return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }

        [HttpPost("/efeturar-reset")]
        public IActionResult ResetarSenhaUsuario(EfetuarResetRequest request)
        {
            Result resultado = _loginService.ResetarSenhaUsuario(request);

            if (resultado.IsFailed) return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }

    }
}
