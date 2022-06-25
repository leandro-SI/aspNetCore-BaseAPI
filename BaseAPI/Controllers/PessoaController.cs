using AutoMapper;
using BaseAPI.Data;
using BaseAPI.Data.Dtos.PessoaDto;
using BaseAPI.Models;
using BaseAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
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
        private readonly PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionarPessoa([FromBody] CreatePessoaDto pessoaDto)
        {
            var pessoa = _pessoaService.CreatePessoa(pessoaDto);

            return CreatedAtAction(nameof(RecuperarPessoaPorId), new { Id = pessoa.Id }, pessoa);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular")]
        public IActionResult RecuperarPessoas()
        {
            var pessoas = _pessoaService.ReadPessoa();

            if (pessoas == null) return NotFound();

            return Ok(pessoas); 
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPessoaPorId(int id)
        {
            var pessoa = _pessoaService.ReadPessoaforId(id);

            if (pessoa == null) return NotFound();

            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPessoa([FromBody] UpdatePessoaDto pessoaDto, int id)
        {
            Result resultado = _pessoaService.UpdatePessoa(pessoaDto, id);

            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPessoa(int id)
        {
            Result resultado = _pessoaService.DeletePessoa(id);

            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }

    }
}
