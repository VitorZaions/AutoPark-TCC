using System.Collections.Generic;

namespace AutoDAO.Entidades
{
    public class StatusConta
    {
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }

        public StatusConta() { }

        public StatusConta(decimal _Codigo, string _Descricao)
        {
            Codigo = _Codigo;
            Descricao = _Descricao;
        }

        public static List<StatusConta> GetSituacoesConta()
        {
            List<StatusConta> Situacoes = new List<StatusConta>();
            Situacoes.Add(new StatusConta(1, "Aberto"));
            Situacoes.Add(new StatusConta(2, "Parcial"));
            Situacoes.Add(new StatusConta(3, "Baixado"));
            Situacoes.Add(new StatusConta(0, "Cancelado"));
            return Situacoes;
        }

    }
}
