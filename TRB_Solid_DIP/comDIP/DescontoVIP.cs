using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRB_Solid_DIP.comDIP
{
    public class DescontoVIP : ICalculadoraDesconto
    {
        public decimal CalcularDesconto(decimal valor, int anosCliente)
        {
            return valor * 0.10m;
        }
    }
}
