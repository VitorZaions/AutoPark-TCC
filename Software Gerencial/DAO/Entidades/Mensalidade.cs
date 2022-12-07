using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class Mensalidade
    {
        [CampoTabela("IDMENSALIDADE")]
        public decimal IDMensalidade { get; set; } = -1;

        [CampoTabela("IDCLIENTE")]
        public decimal IDCliente { get; set; } = -1;

        [CampoTabela("IDVEICULO")]
        public decimal IDVeiculo { get; set; }

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

        [CampoTabela("IDNATUREZA")]
        public decimal IDNatureza { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal? IDFormaDePagamento { get; set; }

        // Não é campo, somente para pegar o nome em parses
        [CampoTabela("CLIENTE")]
        public string Cliente { get; set; } = null;

        [CampoTabela("VEICULO")]
        public string Veiculo { get; set; } = null;

        public Mensalidade() { }
    }
}
