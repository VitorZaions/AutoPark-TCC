using AutoDAO.Atributos;
using System;

namespace PDV.DAO.Entidades
{
    public class ChequeContasPagar
    {
        [CampoTabela("IDCHEQUECONTASPAGAR")]
        public decimal IDChequeContasPagar { get; set; }

        [CampoTabela("IDCONTAPAGAR")]
        public decimal IDContaPagar { get; set; }

        [CampoTabela("IDTALONARIO")]
        public decimal IDTalonario { get; set; }

        [CampoTabela("IDBAIXAPAGAMENTO")]
        public decimal IDBaixaPagamento { get; set; }

        [CampoTabela("NUMERO")]
        public decimal Numero { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; }

        [CampoTabela("VENCIMENTO")]
        public DateTime Vencimento { get; set; }

        [CampoTabela("CRUZADO")]
        public decimal Cruzado { get; set; }

        [CampoTabela("COMPENSADO")]
        public decimal Compensado { get; set; }

        [CampoTabela("DATACOMPENSACAO")]
        public DateTime? DataCompensacao { get; set; }

        [CampoTabela("DEVOLVIDO")]
        public decimal Devolvido { get; set; }

        [CampoTabela("DATADEVOLUCAO")]
        public DateTime? DataDevolucao { get; set; }

        public ChequeContasPagar() { }
    }
}