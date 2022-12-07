using AutoDAO.Atributos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDAO.Entidades
{
    public class TipoPagamento
    {
        [CampoTabela("CODIGOTIPOPAGAMENTO")]
        public decimal CodigoTipoPagamento { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public TipoPagamento()
        {

        }
    }
}
