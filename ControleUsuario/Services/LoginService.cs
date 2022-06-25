using ControleUsuario.Data.Requests;
using ControleUsuario.Models;
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
        private readonly TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(u => u.NormalizedUserName == request.UserName.ToUpper());

                Token token = _tokenService.CreateToken(identityUser, 
                    _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login Falhou");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperarUserPorEmail(request.Email);

            if (identityUser != null)
            {
                string codigoRecuperacao = _signInManager
                    .UserManager
                    .GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoRecuperacao);
            }

            return Result.Fail("falha ao solicitar redefinição");
        }

        public Result ResetarSenhaUsuario(EfetuarResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperarUserPorEmail(request.Email);

            IdentityResult resultadoIdentity = _signInManager
                .UserManager
                .ResetPasswordAsync(identityUser, request.Token, request.Password)
                .Result;

            if (resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso");

            return Result.Fail("Houve um erro na operação");
        }

        private IdentityUser<int> RecuperarUserPorEmail(string email)
        {
            return _signInManager
                .UserManager
                .Users
                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
