using AutoMapper;
using BaseAPI.Data;
using BaseAPI.Data.Dtos.PessoaDto;
using BaseAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Services
{
    public class PessoaService
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public PessoaService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadPessoaDto CreatePessoa(CreatePessoaDto pessoaDto)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return _mapper.Map<ReadPessoaDto>(pessoa);
        }

        public List<ReadPessoaDto> ReadPessoa()
        {
            var pessoas = _context.Pessoas.ToList();

            return _mapper.Map<List<ReadPessoaDto>>(pessoas);
        }

        public ReadPessoaDto ReadPessoaforId(int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

            return _mapper.Map<ReadPessoaDto>(pessoa);
        }

        public Result UpdatePessoa(UpdatePessoaDto pessoaDto, int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa == null) return Result.Fail("Pessoa não encontrada");

            _mapper.Map(pessoaDto, pessoa);
            _context.SaveChanges();

            return Result.Ok();

        }

        public Result DeletePessoa(int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa == null) return Result.Fail("Pessoa não encontrada");

            _context.Pessoas.Remove(pessoa)                ;
            _context.SaveChanges();

            return Result.Ok();
        }

    }
}
