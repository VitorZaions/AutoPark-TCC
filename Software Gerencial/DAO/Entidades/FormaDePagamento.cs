using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class FormaDePagamento
    {
        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal IDFormaDePagamento { get; set; } = -1;

        [CampoTabela("CODIGOTIPOPAGAMENTO")]
        public decimal CodigoTipoPagamento { get; set; } = -1;

        [CampoTabela("IDBANDEIRACARTAO")]
        public decimal? IDBandeiraCartao { get; set; }

        [CampoTabela("CARTAOBANDEIRA")]
        public string CartaoBandeira { get; set; }

        [CampoTabela("FORMADEPAGAMENTOBANDEIRA")]
        public string FormaDePagamentoBandeira { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("IDENTIFICACAO")]
        public string Identificacao { get; set; }

        [CampoTabela("DESCRICAOTIPOPAGAMENTO")]
        public string DescricaoTipoPagamento { get; set; }

        [CampoTabela("CNPJCREDENCIADORA")]
        public string CNPJCredenciadora { get; set; }
        
        public FormaDePagamento()
        {
        }
    }
}
