

using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class AgendaContato
    {
        [CampoTabela("IDCONTATO")]
        public decimal IDCONTATO { get; set; } = -1;

        [CampoTabela("NOME")]
        public string NOME { get; set; }

        [CampoTabela("CELULAR")]
        public string Telefone { get; set; }

        [CampoTabela("CELULAR2")]
        public string Celular { get; set; }

        [CampoTabela("EMAIL")]
        public string EMAIL { get; set; }

        [CampoTabela("OBSERVACAO")]
        public string OBSERVACAO { get; set; }

    }
}
