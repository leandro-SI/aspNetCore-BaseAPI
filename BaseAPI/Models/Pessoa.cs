using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public int Idade { get; set; }
    }
}
