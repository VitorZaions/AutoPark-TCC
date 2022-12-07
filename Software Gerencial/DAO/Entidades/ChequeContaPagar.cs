﻿using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class ChequeContaPagar
    {
        [CampoTabela("IDCHEQUECONTAPAGAR")]
        public decimal IDChequeContaPagar { get; set; }

        [CampoTabela("IDTALONARIO")]
        public decimal? IDTalonario { get; set; }

        [CampoTabela("IDBAIXAPAGAMENTO")]
        public decimal IDBaixaPagamento { get; set; }

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

        public ChequeContaPagar() { }
    }
}