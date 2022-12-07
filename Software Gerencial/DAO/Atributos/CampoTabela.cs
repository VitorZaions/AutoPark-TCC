using System;

namespace AutoDAO.Atributos
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Struct)]
    public class CampoTabela : Attribute
    {
        public string Nome;

        public CampoTabela(string Nome)
        {
            this.Nome = Nome;
        }
    }
}
