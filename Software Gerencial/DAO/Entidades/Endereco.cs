using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class Endereco
    {
        [CampoTabela("IDENDERECO")]
        [MaxLength(18)]
        public decimal IDEndereco { get; set; } = -1;

        [CampoTabela("LOGRADOURO")]
        [MaxLength(150)]
        public string Logradouro { get; set; }

        [CampoTabela("NUMERO")]
        [MaxLength(6)]
        public decimal? Numero { get; set; }

        [CampoTabela("CEP")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [CampoTabela("COMPLEMENTO")]
        [MaxLength(150)]
        public string Complemento { get; set; }

        [CampoTabela("BAIRRO")]
        [MaxLength(150)]
        public string Bairro { get; set; }

        [CampoTabela("IDPAIS")]
        [MaxLength(18)]
        public decimal? IDPais { get; set; }

        [CampoTabela("PAIS")]
        [MaxLength(150)]
        public string Pais { get; set; }

        [CampoTabela("IDUNIDADEFEDERATIVA")]
        [MaxLength(18)]
        public decimal? IDUnidadeFederativa { get; set; }

        [CampoTabela("IDMUNICIPIO")]
        [MaxLength(18)]
        public decimal ?IDMunicipio { get; set; }

        [CampoTabela("MUNICIPIO")]
        [MaxLength(150)]
        public string Municipio { get; set; }

        public Endereco() { }
    }
}
