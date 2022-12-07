using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class BaixaMensalidade
    {
        [CampoTabela("IDBAIXAMENSALIDADE")]
        public decimal IDBaixaMensalidade { get; set; }

        [CampoTabela("IDMENSALIDADE")]
        public decimal IDMensalidade { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal IDFormaDePagamento { get; set; } = -1;

        [CampoTabela("IDCONTABANCARIA")]
        public decimal IDContaBancaria { get; set; }

        [CampoTabela("ORIGEM")]
        public string Origem { get; set; } = "Financeiro";

        [CampoTabela("COMPLEMENTO")]
        public string Complemento { get; set; }

        [CampoTabela("BAIXA")]
        public DateTime Baixa { get; set; } = DateTime.Now;

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

        public BaixaMensalidade() { }
    }
}