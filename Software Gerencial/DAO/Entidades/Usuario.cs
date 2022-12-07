using AutoDAO.Atributos;

namespace AutoDAO.Entidades
{
    public class Usuario
    {
        [CampoTabela("IDUSUARIO")]
        public decimal IDUsuario { get; set; } = -1;

        [CampoTabela("NOME")]
        public string Nome { get; set; }

        [CampoTabela("LOGIN")]
        public string Login { get; set; }

        [CampoTabela("SENHA")]
        public string Senha { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("EMAIL")]
        public string Email { get; set; }

        [CampoTabela("IDPERFILACESSO")]
        public decimal IDPerfilAcesso { get; set; } = -1;

        [CampoTabela("PERFILACESSO")]
        public string PerfilAcesso { get; set; }

        [CampoTabela("ROOT")]
        public decimal Root { get; set; }

        [CampoTabela("IDUSUARIOSUPERVISOR")]
        public decimal IDUsuarioSupervisor { get; set; }

        public Usuario()
        {
        }
    }
}
