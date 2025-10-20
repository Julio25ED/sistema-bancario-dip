using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRB_Solid_DIP.Sem_DIP
{
    public class CalculadoraFidelidade
    {
        public decimal Calcular(decimal valor, int anosCliente)
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

    public class ProcessarPagamentoSemDip
    {
        private CalculadoraFidelidade calculadora; // Clase de alto nivel depende de uma classe de baixo nível

        public ProcessarPagamentoSemDip()
        {
            calculadora = new CalculadoraFidelidade();  // Dependência direta da implementação concreta
        }

        public decimal ProcessarPagamento(decimal valor, int anosCliente)
        {
            Console.WriteLine($"O valor sem deconto e: R$ {valor:F2}");

            decimal desconto = calculadora.Calcular(valor, anosCliente); // Uso direto da classe concreta
            decimal valorFinal = valor - desconto;

            Console.WriteLine($"Desconto: R$ {desconto:F2}");
            Console.WriteLine($"Valor final: R$ {valorFinal:F2}");

            return valorFinal;
        }
    }
}
