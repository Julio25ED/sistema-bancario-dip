using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRB_Solid_DIP.comDIP
{
    public class DescontoFidelidade : ICalculadoraDesconto
    {
        public decimal CalcularDesconto(decimal valor, int anosCliente)
        {
            if (anosCliente > 5)
            {
                return valor * 0.05m;
            }
            else if (anosCliente > 2)
            {
                return valor * 0.03m;
            }
            else
            {
                return 0m;
            }
        }
    }
}
