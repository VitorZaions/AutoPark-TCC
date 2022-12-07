using System;

namespace AutoDAO.Atributos
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Struct)]
    public class MaxLength : Attribute
    {
        public double Length;

        public MaxLength(double Length)
        {
            this.Length = Length;
        }
    }
}
