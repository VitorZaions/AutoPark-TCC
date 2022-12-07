using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class CentroCusto
    {
        [CampoTabela("IDCENTROCUSTO")]
        public decimal IDCentroCusto { get; set; } = -1;

        [CampoTabela("IDCENTROCUSTOSUPERIOR")]
        public decimal? IDCentroCustoSuperior { get; set; }

        [CampoTabela("CENTRO")]
        public string Centro { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("OBSERVACAO")]
        public string Observacao { get; set; }

        public CentroCusto() { }
    }
}
