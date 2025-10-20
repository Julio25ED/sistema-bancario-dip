using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRB_Solid_DIP.comDIP
{
    public interface ICalculadoraDesconto     //injeçao de dependencia 
    {                                           // depende de abstrações e não de classes concretas
        decimal CalcularDesconto(decimal valor, int anosCliente);

    }
}
