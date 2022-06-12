using AutoMapper;
using ControleUsuario.Data.Dtos.UsuarioDto;
using ControleUsuario.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleUsuario.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastroUsuario(CreateUsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            Task<IdentityResult> identityResult = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password);

            if (identityResult.Result.Succeeded) return Result.Ok();

            return Result.Fail("Falha ao cadastrar usuário.!");
        }
    }
}
