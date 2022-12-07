using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class BandeiraCartao
    {
        [CampoTabela("IDBANDEIRACARTAO")]
        public decimal IDBandeiraCartao { get; set; } = -1;

        [CampoTabela("CODIGO")]
         public decimal Codigo { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
         public string Descricao { get; set; }

        [CampoTabela("CODIGODESCRICAO")]
        public string CodigoDescricao { get; set; }

        public BandeiraCartao()
        {
        }
    }
}
