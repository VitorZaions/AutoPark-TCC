using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class RelatorioContaReceber
    {
        [CampoTabela("IDCONTARECEBER")]
        public decimal IDContaReceber { get; set; } = -1;               

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; } = DateTime.Now;

        [CampoTabela("VENCIMENTO")]
        public DateTime Vencimento { get; set; } = DateTime.Now;

        [CampoTabela("ORIGEM")]
        public string Origem { get; set; } = "Financeiro";

         [CampoTabela("STATUS")]
        public string Status { get; set; }

        [CampoTabela("VALORTOTAL")]
        public decimal ValorTotal { get; set; }               

        // Não é campo, somente para pegar o nome em parses
        [CampoTabela("CLIENTE")]
        public string Cliente { get; set; } = null;

        public RelatorioContaReceber() { }
    }
}
