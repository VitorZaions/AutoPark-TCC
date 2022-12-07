using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class Natureza
    {
        [CampoTabela("IDNATUREZA")]
        public decimal IDNatureza { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("APLICACAO")]
        public string Aplicacao { get; set; }

        [CampoTabela("TIPO")]
        public decimal Tipo { get; set; }

        [CampoTabela("IDNATUREZASUPERIOR")]
        public decimal? IDNaturezaSuperior { get; set; }

        public Natureza() { }
    }
}