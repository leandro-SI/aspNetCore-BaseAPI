using ControleUsuario.Data.Requests;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleUsuario.Services
{
    public class LoginService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultadoIdentity.Result.Succeeded) return Result.Ok();

            return Result.Fail("Login Falhou");
        }
    }
}
