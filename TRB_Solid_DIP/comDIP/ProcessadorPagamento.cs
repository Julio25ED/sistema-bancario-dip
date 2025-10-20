using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRB_Solid_DIP.comDIP
{
    public class ProcessadorPagamento
    {
        private ICalculadoraDesconto _calculadora; // Dependência da abstração e não mais da clase concreta

        public ProcessadorPagamento(ICalculadoraDesconto calculadora)
        {
            _calculadora = calculadora; // Injeção de dependência via construtor
        }

        public decimal ProcessarPagamento(decimal valor, int anosCliente)
        {
            Console.WriteLine($"O valor sem deconto e: R$ {valor:F2}");

            decimal desconto = _calculadora.CalcularDesconto(valor, anosCliente); // Uso da abstração, nao precisa saber 
            decimal valorFinal = valor - desconto;

            return valorFinal;
        }

    }
}
