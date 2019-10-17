﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrariaServer.Models
{
    class Locacao
    {
        public int id_locacao { get; set; }
        public int id_usuario { get; set; }
        public string nome_usuario { get; set; }
        public DateTime data_locacao { get; set; }
        public DateTime data_devolucao { get; set; }
        public int id_livro { get; set; }
        public string nome_livro { get; set; }
        public DateTime data_devolvido { get; set; }
    }
}
