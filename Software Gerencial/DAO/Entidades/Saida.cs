using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class Saida
    {
        [CampoTabela("IDSAIDA")]
        public decimal IDSaida { get; set; } = -1;

        [CampoTabela("IDVEICULO")]
        public decimal IDVeiculo { get; set; }

        [CampoTabela("DATASAIDA")]
        public DateTime DataSaida { get; set; } = DateTime.Now;

        [CampoTabela("TIPO")]
        public decimal Tipo { get; set; }

        // Não é campo, somente para pegar o nome em parses
        [CampoTabela("CLIENTE")]
        public string Cliente { get; set; } = null;

        public Saida() { }
    }
}
