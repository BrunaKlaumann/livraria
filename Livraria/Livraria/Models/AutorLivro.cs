using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class AutorLivro
    {
        public int id_autor { get; set; }
        public string nome_autor { get; set; }
        public int id_livro { get; set; }
        public string nome_livro { get; set; }
    }
}
