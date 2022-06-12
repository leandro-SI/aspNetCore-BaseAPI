using AutoMapper;
using BaseAPI.Data;
using BaseAPI.Data.Dtos.PessoaDto;
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
        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public PessoaController(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarPessoa([FromBody] CreatePessoaDto pessoaDto)
        {

            var pessoa = _mapper.Map<Pessoa>(pessoaDto);

            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarPessoaPorId), new { Id = pessoa.Id }, pessoa);
        }

        [HttpGet]
        public IActionResult RecuperarPessoas()
        {
            return Ok(_context.Pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPessoaPorId(int id)
        {
            Pessoa pessoa = _context.Pessoas.FirstOrDefault(filme => filme.Id == id);

            if (pessoa != null)
            {
                var pessoaDto = _mapper.Map<ReadPessoaDto>(pessoa);

                return Ok(pessoaDto);

            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPessoa([FromBody] UpdatePessoaDto pessoaDto, int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa == null) return NotFound();

            _mapper.Map(pessoaDto, pessoa);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPessoa(int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa == null) return NotFound();
            _context.Remove(pessoa);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
