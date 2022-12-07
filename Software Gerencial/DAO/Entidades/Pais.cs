using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class Pais
    {
        [CampoTabela("IDPAIS")]
        [MaxLength(18)]
        public decimal IDPais { get; set; } = -1;


        [CampoTabela("CODIGO")]
        [MaxLength(50)]
        public string Codigo { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        public Pais() { }
    }
}
