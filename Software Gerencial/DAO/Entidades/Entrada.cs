using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class Entrada
    {
        [CampoTabela("IDENTRADA")]
        public decimal IDEntrada { get; set; } = -1;

        [CampoTabela("IDVEICULO")]
        public decimal IDVeiculo { get; set; }

        [CampoTabela("DATAENTRADA")]
        public DateTime DataEntrada { get; set; } = DateTime.Now;

        [CampoTabela("TEMPO")]
        public decimal Tempo { get; set; }

        [CampoTabela("TIPO")]
        public decimal Tipo { get; set; }

        // Não é campo, somente para pegar o nome em parses
        [CampoTabela("CLIENTE")]
        public string Cliente { get; set; } = null;

        public Entrada() { }
    }
}
