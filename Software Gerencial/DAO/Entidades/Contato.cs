﻿using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class Contato
    {
        [CampoTabela("IDCONTATO")]
        [MaxLength(18)]
        public decimal IDContato { get; set; } = -1;

        [CampoTabela("EMAIL")]
        [MaxLength(100)]
        public string Email { get; set; }

        [CampoTabela("EMAILALTERNATIVO")]
        [MaxLength(100)]
        public string EmailAlternativo { get; set; }

        [CampoTabela("EMAILALTERNATIVO")]
        [MaxLength(11)]
        public string Celular { get; set; }

        [CampoTabela("TELEFONE")]
        [MaxLength(11)]
        public string Telefone { get; set; }

        public Contato()
        {
        }
    }
}
