using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class RelatorioSaida
    {
        [CampoTabela("IDSAIDA")]
        public decimal IDSaida { get; set; } = -1;

        [CampoTabela("DATASAIDA")]
        public DateTime DataSaida { get; set; } = DateTime.Now;

        [CampoTabela("TIPO")]
        public string Tipo { get; set; }

        // Não é campo, somente para pegar o nome em parses
        [CampoTabela("CLIENTE")]
        public string Cliente { get; set; } = null;

        [CampoTabela("PLACA")]
        public string Placa { get; set; } = null;

        public RelatorioSaida() { }
    }
}
