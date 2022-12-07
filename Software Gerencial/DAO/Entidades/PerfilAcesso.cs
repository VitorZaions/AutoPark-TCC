using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class PerfilAcesso
    {
        [CampoTabela("IDPERFILACESSO")]
        [MaxLength(18)]
        public decimal IDPerfilAcesso { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [CampoTabela("ATIVO")]
        [MaxLength(1)]
        public decimal Ativo { get; set; } = 1;

        public PerfilAcesso()
        {
        }
    }
}
