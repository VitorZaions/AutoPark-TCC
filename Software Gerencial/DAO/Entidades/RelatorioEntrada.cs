using AutoDAO.Atributos;
using System;

namespace AutoDAO.Entidades
{
    public class RelatorioEntrada
    {
        [CampoTabela("IDENTRADA")]
        public decimal IDEntrada { get; set; } = -1;

        [CampoTabela("IDVEICULO")]
        public decimal IDVeiculo { get; set; }

        [CampoTabela("DATAENTRADA")]
        public DateTime DataEntrada { get; set; } = DateTime.Now;

        [CampoTabela("TIPO")]
        public string Tipo { get; set; }

        // Não é campo, somente para pegar o nome em parses

        [CampoTabela("CLIENTE")]
        public string Cliente { get; set; } = null;

        [CampoTabela("PLACA")]
        public string Placa { get; set; } = null;

        [CampoTabela("VALORTOTAL")]
        public decimal ValorTotal { get; set; }

        [CampoTabela("STATUS")]
        public string Status { get; set; } = null;

        public RelatorioEntrada() { }
    }
}
