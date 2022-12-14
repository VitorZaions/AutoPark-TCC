using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class BaixaPagamento
    {
        [CampoTabela("IDBAIXAPAGAMENTO")]
        public decimal IDBaixaPagamento { get; set; }

        [CampoTabela("IDCONTAPAGAR")]
        public decimal IDContaPagar { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal IDFormaDePagamento { get; set; }

        [CampoTabela("IDCONTABANCARIA")]
        public decimal IDContaBancaria { get; set; }

        [CampoTabela("COMPLEMENTO")]
        public string Complemento { get; set; }

        [CampoTabela("ORIGEM")]
        public string Origem { get; set; } = "Financeiro";

        [CampoTabela("BAIXA")]
        public DateTime Baixa { get; set; }

        [CampoTabela("MULTA")]
        public decimal Multa { get; set; }

        [CampoTabela("JUROS")]
        public decimal Juros { get; set; }

        [CampoTabela("DESCONTO")]
        public decimal Desconto { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("DATACONCILIACAO")]
        public DateTime? DataConciliacao { get; set; }

        public BaixaPagamento() { }
    }
}