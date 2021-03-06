using AutoMapper;
using ControleUsuario.Data.Dtos.UsuarioDto;
using ControleUsuario.Data.Requests;
using ControleUsuario.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ControleUsuario.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly EmailService _emailService;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result CadastroUsuario(CreateUsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            Task<IdentityResult> identityResult = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password);

            // var createRoleResult = _roleManager.CreateAsync(new IdentityRole<int>("regular")).Result;

            _userManager.AddToRoleAsync(usuarioIdentity, "regular");

            if (identityResult.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                // Corrigir E-mail
                //var encodedCode = HttpUtility.UrlEncode(code);
                //_emailService.EnviarEmail(new[] { usuarioIdentity.Email },
                //    "Link de Ativação", usuarioIdentity.Id, encodedCode);

                return Result.Ok().WithSuccess(code);
            } 

            return Result.Fail("Falha ao cadastrar usuário.!");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de usuário.!");
        }
    }
}
