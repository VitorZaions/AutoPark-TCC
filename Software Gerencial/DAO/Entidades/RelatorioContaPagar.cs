using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class RelatorioContaPagar
    {
        [CampoTabela("IDCONTAPAGAR")]
        public decimal IDContaPagar { get; set; } = -1;

        [CampoTabela("PARCELA")]
        public decimal Parcela { get; set; } = 1;

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

        [CampoTabela("FORNECEDOR")]
        public string Fornecedor { get; set; }

        public RelatorioContaPagar() { }
    }
}