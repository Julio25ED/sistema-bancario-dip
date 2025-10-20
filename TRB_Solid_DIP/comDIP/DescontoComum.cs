using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRB_Solid_DIP.comDIP
{
    public class DescontoComum : ICalculadoraDesconto
    {
        public decimal CalcularDesconto(decimal valor, int anosCliente)
        {
            if (anosCliente > 3)
            {
                return valor * 0.02m;
            }
            else
            {
                return 0m;
            }
        }
    }
}
