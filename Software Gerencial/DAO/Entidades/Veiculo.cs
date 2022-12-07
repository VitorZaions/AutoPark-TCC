using AutoDAO.Atributos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AutoDAO.Entidades
{
    public class Veiculo
    {
        [CampoTabela("IDVEICULO")]
        public decimal IDVeiculo { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("PLACA")]
        public string Placa { get; set; }

        [CampoTabela("IDUNIDADEFEDERATIVA")]
        public decimal IDUnidadeFederativa { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; }

        [CampoTabela("IDPAIS")]
        public decimal IDPais { get; set; } = -1;

        [CampoTabela("TIPO")]
        public decimal Tipo { get; set; } = -1;

        //VEM DO CLIENTE

        [CampoTabela("CLIENTE")]
        public string Cliente { get; set; }

        [CampoTabela("IDCLIENTE")]
        public decimal? IDCLIENTE { get; set; }

        public Veiculo()
        {
        }
    }
}
