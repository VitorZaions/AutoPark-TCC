﻿using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class Banco
    {
        [CampoTabela("IDBANCO")]
        public decimal IDBanco { get; set; }

        [CampoTabela("CODBACEN")]
        public decimal? CodBacen { get; set; }

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        [CampoTabela("SITE")]
        public string Site { get; set; }

        public Banco() { }
    }
}
