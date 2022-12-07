using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class ContaPagar
    {
        [CampoTabela("IDCONTAPAGAR")]
        public decimal IDContaPagar { get; set; } = -1;

        [CampoTabela("IDFORNECEDOR")]
        public decimal IDFornecedor { get; set; }

        [CampoTabela("PARCELA")]
        public decimal Parcela { get; set; } = 1;

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; } = DateTime.Now;

        [CampoTabela("VENCIMENTO")]
        public DateTime Vencimento { get; set; } = DateTime.Now;

        [CampoTabela("COMPLEMENTO")]
        public string Complemento { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("ORIGEM")]
        public string Origem { get; set; } = "Financeiro";

        [CampoTabela("MULTA")]
        public decimal Multa { get; set; }

        [CampoTabela("JUROS")]
        public decimal Juros { get; set; }

        [CampoTabela("DESCONTO")]
        public decimal Desconto { get; set; }

        [CampoTabela("STATUS")]
        public decimal Status { get; set; } = 1;

        [CampoTabela("VALORTOTAL")]
        public decimal ValorTotal { get; set; }

        [CampoTabela("SALDO")]
        public decimal Saldo { get; set; }

        [CampoTabela("IDCENTROCUSTO")]
        public decimal IDCentroCusto { get; set; }

        [CampoTabela("IDNATUREZA")]
        public decimal IDNatureza { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal? IDFormaDePagamento { get; set; }

        [CampoTabela("FORNECEDOR")]
        public string Fornecedor { get; set; }

        public ContaPagar() { }
    }
}