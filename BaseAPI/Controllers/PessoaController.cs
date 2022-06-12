using BaseAPI.Data;
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

        public PessoaController(BaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarPessoa([FromBody] Pessoa pessoa)
        {
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

            if (pessoa != null) return Ok(pessoa);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPessoa([FromBody] Pessoa pessoaRequest, int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa == null) return NotFound();

            pessoa.Nome = pessoaRequest.Nome;
            pessoa.Sobrenome = pessoaRequest.Sobrenome;
            pessoa.Idade = pessoaRequest.Idade;

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
