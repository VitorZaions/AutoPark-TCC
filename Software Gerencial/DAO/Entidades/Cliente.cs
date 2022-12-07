using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class Cliente
    {
        [CampoTabela("IDCLIENTE")]
        public decimal IDCliente { get; set; } = -1; //= Sequence.GetMaxID("CLIENTE", "IDCLIENTE");

        [CampoTabela("TIPODOCUMENTO")]
        public decimal TipoDocumento { get; set; } // 0 = cnpj, 1 = cpf

        [CampoTabela("CNPJ")]
        public string CNPJ { get; set; }

        [CampoTabela("CPF")]
        public string CPF { get; set; }

        [CampoTabela("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }

        [CampoTabela("NOMEFANTASIA")]
        public string NomeFantasia { get; set; }

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        [CampoTabela("IDENDERECO")]
        public decimal IDEndereco { get; set; } = -1;

        [CampoTabela("IDCONTATO")]
        public decimal IDContato { get; set; } = -1;

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("DOCESTRANGEIRO")]
        public string DocEstrangeiro { get; set; }

        public Cliente()
        {
        }
    }
}
