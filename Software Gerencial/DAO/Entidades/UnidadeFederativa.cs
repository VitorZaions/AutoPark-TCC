using AutoDAO.Atributos;


namespace AutoDAO.Entidades
{
    public class UnidadeFederativa
    {
        [CampoTabela("IDUNIDADEFEDERATIVA")]
        public decimal IDUnidadeFederativa { get; set; } = -1;

        [CampoTabela("IDPAIS")]
        public decimal IDPais { get; set; } = -1;

        [CampoTabela("PAIS")]
        public string Pais { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("SIGLA")]
        public string Sigla { get; set; }

        [CampoTabela("CODIGO")]
        public decimal Codigo { get; set; }

        // JOINS

        [CampoTabela("ALIQUOTAINTER")]
        public decimal IALIQUOTAINTER { get; set; }

        [CampoTabela("ALIQUOTAINTRA")]
        public decimal ALIQUOTAINTRA { get; set; }

        [CampoTabela("ALIQUOTAFCP")]
        public decimal ALIQUOTAFCP { get; set; }

        public UnidadeFederativa() { }
    }
}
