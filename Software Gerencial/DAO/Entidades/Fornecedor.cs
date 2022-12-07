using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class Fornecedor
    {
        [CampoTabela("IDFORNECEDOR")]
        public decimal IDFornecedor { get; set; } = -1;

        [CampoTabela("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }

        [CampoTabela("CPFCNPJ")]
        public string CPFCNPJ { get; set; }

        [CampoTabela("INSCRICAOESTADUAL")]
        public decimal? InscricaoEstadual { get; set; }

        [CampoTabela("IDENDERECO")]
        public decimal ?IDEndereco { get; set; }

        [CampoTabela("IDCONTATO")]
        public decimal? IDContato { get; set; }

        [CampoTabela("NOMEFANTASIA")]
        public string NomeFantasia { get; set; }

        [CampoTabela("TIPODOCUMENTO")]
        public decimal TipoDocumento { get; set; }

        // Relatórios

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public Fornecedor() { }
    }
}