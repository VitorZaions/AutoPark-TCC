using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class ChequeMensalidade
    {
        [CampoTabela("IDCHEQUEMENSALIDADE")]
        public decimal IDChequeMensalidade { get; set; } = -1;

        [CampoTabela("IDBAIXAMENSALIDADE")]
        public decimal IDBaixaMensalidade { get; set; }

        [CampoTabela("NUMERO")]
        public decimal Numero { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; } = DateTime.Now;

        [CampoTabela("VENCIMENTO")]
        public DateTime Vencimento { get; set; } = DateTime.Now;

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

        [CampoTabela("REPASSE")]
        public decimal Repasse { get; set; }

        [CampoTabela("DATAREPASSE")]
        public DateTime? DataRepasse { get; set; }

        [CampoTabela("OBSREPASSE")]
        public byte[] ObsRepasse { get; set; }

        public ChequeMensalidade() { }
    }
}