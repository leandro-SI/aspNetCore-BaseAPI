using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleUsuario.Models
{
    public class Mensagem
    {
        public List<?> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string codigo)
        {
            Destinatario = ???
                Assunto = assunto;
            Conteudo = $"http://localhost:6001/ativa?UsuarioId={usuarioId}&CodigoDeAtivacao={codigo}";
        }

    }
}
