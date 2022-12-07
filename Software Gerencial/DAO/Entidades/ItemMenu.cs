using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class ItemMenu
    {
        [CampoTabela("IDITEMMENU")]
        [MaxLength(18)]
        public decimal IDItemMenu { get; set; }

        [CampoTabela("CODIGO")]
        [MaxLength(4)]
        public decimal Codigo { get; set; }

        [CampoTabela("DESCRICAO")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        public ItemMenu()
        {
        }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
