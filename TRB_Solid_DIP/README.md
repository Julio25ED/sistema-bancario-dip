# 🏦 Sistema Bancário - Princípio DIP

> Demonstração prática do **Dependency Inversion Principle (DIP)** através de um sistema de cálculo de descontos bancários.

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SOLID](https://img.shields.io/badge/SOLID-Principles-blue?style=for-the-badge)

---

## 📋 Índice

- [Sobre o Projeto](#-sobre-o-projeto)
- [O que é DIP?](#-o-que-é-dip)
- [Estrutura do Projeto](#-estrutura-do-projeto)
- [Tecnologias](#-tecnologias)
- [Como Executar](#-como-executar)
- [Exemplos de Uso](#-exemplos-de-uso)
- [Comparação: SEM DIP vs COM DIP](#-comparação-sem-dip-vs-com-dip)
- [Onde o DIP está aplicado](#-onde-o-dip-está-aplicado)
- [Aprendizados](#-aprendizados)
- [Autor](#-autor)

---

## 🎯 Sobre o Projeto

Este projeto foi desenvolvido para demonstrar a aplicação do **Princípio da Inversão de Dependência (DIP)**, um dos cinco princípios SOLID da programação orientada a objetos.

O sistema simula um **processador de pagamentos bancários** que calcula descontos baseados em diferentes tipos de cliente:
- 💼 **Cliente Comum** - Descontos básicos
- ⭐ **Cliente Fidelidade** - Descontos progressivos por tempo de relacionamento
- 👑 **Cliente VIP** - Desconto fixo de 10%

---

## 📚 O que é DIP?

**DIP** significa **Dependency Inversion Principle** (Princípio da Inversão de Dependência).

### Definição:

> *"Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações (interfaces)."*

### Em outras palavras:

- ❌ **Errado:** Uma classe criar seus próprios objetos internamente
- ✅ **Certo:** Uma classe receber objetos por meio de interfaces

### Analogia:

É como um **controle remoto universal**: ele não precisa conhecer a marca da TV, apenas precisa saber que a TV responde a sinais infravermelhos. A **interface** é o infravermelho!

---

## 📁 Estrutura do Projeto

```
TRB_Solid_DIP/
│
├── 📁 SemDIP/                          ❌ Código SEM aplicar DIP (exemplo ruim)
│   └── SistemaSemDIP.cs
│
├── 📁 comDIP/                          ✅ Código COM DIP aplicado (exemplo correto)
│   ├── ICalculadoraDesconto.cs        → Interface (abstração)
│   ├── DescontoComum.cs               → Implementação para cliente comum
│   ├── DescontoFidelidade.cs          → Implementação para cliente fidelidade
│   ├── DescontoVIP.cs                 → Implementação para cliente VIP
│   └── ProcessadorPagamento.cs        → Classe que usa DIP
│
└── Program.cs                          → Demonstração e testes
```

---

## 🛠 Tecnologias

- **Linguagem:** C# 12
- **Framework:** .NET 8.0
- **IDE:** Visual Studio 2022
- **Paradigma:** Programação Orientada a Objetos (POO)
- **Princípio:** SOLID - DIP

---

## 🚀 Como Executar

### Pré-requisitos:

- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/) ou superior
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Passos:

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/SEU-USUARIO/sistema-bancario-dip.git
   ```

2. **Abra o projeto:**
   - Abra o arquivo `TRB_Solid_DIP.sln` no Visual Studio

3. **Execute:**
   - Pressione `F5` ou clique em "Start"

---

## 💡 Exemplos de Uso

### Exemplo 1: Desconto Fidelidade

```csharp
// Criar calculadora de fidelidade
ICalculadoraDesconto calculadora = new DescontoFidelidade();

// Injetar no processador
ProcessadorPagamento processador = new ProcessadorPagamento(calculadora);

// Processar pagamento
decimal valorFinal = processador.ProcessarPagamento(1000, 3);
```

**Saída:**
```
💰 Valor original: R$ 1000.00
🎁 Desconto: R$ 30.00 (3% - cliente há 3 anos)
✅ Valor final: R$ 970.00
```

---

### Exemplo 2: Desconto VIP

```csharp
// Trocar para calculadora VIP
ICalculadoraDesconto calculadora = new DescontoVIP();

// Mesmo processador, calculadora diferente!
ProcessadorPagamento processador = new ProcessadorPagamento(calculadora);

decimal valorFinal = processador.ProcessarPagamento(1000, 3);
```

**Saída:**
```
💰 Valor original: R$ 1000.00
🎁 Desconto: R$ 100.00 (10% - cliente VIP)
✅ Valor final: R$ 900.00
```

> **Note:** O `ProcessadorPagamento` não foi modificado! Apenas trocamos a implementação.

---

## 🔄 Comparação: SEM DIP vs COM DIP

### ❌ SEM DIP (Código Acoplado)

```csharp
public class ProcessadorPagamentoSemDIP
{
    // ❌ Dependência DIRETA de classe concreta
    private CalculadoraFidelidade calculadora;
    
    public ProcessadorPagamentoSemDIP()
    {
        // ❌ Cria a dependência INTERNAMENTE
        calculadora = new CalculadoraFidelidade();
    }
}
```

**Problemas:**
- 🔴 Acoplamento forte
- 🔴 Difícil de testar
- 🔴 Difícil de estender
- 🔴 Para trocar o tipo, precisa MODIFICAR a classe

---

### ✅ COM DIP (Código Desacoplado)

```csharp
public class ProcessadorPagamento
{
    // ✅ Dependência de INTERFACE (abstração)
    private ICalculadoraDesconto _calculadora;
    
    // ✅ INJEÇÃO DE DEPENDÊNCIA via construtor
    public ProcessadorPagamento(ICalculadoraDesconto calculadora)
    {
        _calculadora = calculadora;
    }
}
```

**Benefícios:**
- 🟢 Baixo acoplamento
- 🟢 Fácil de testar (mocks)
- 🟢 Fácil de estender (novas implementações)
- 🟢 Flexível (troca implementação sem modificar código)

---

## 🎯 Onde o DIP está aplicado

### 1️⃣ Interface (Abstração)

```csharp
public interface ICalculadoraDesconto
{
    decimal CalcularDesconto(decimal valor, int anosCliente);
}
```

> A interface define o **CONTRATO** que todas as calculadoras devem seguir.

---

### 2️⃣ Tipo da Variável

```csharp
// ✅ Tipo INTERFACE (não tipo concreto)
private ICalculadoraDesconto _calculadora;
```

> A variável é do tipo **interface**, permitindo receber **qualquer implementação**.

---

### 3️⃣ Injeção de Dependência

```csharp
// ✅ Recebe de FORA, não cria DENTRO
public ProcessadorPagamento(ICalculadoraDesconto calculadora)
{
    _calculadora = calculadora;  // Guarda o que veio de fora
}
```

> O processador **não decide** qual calculadora usar. **Você decide** ao criar o objeto!

---

### 4️⃣ Uso Polimórfico

```csharp
// ✅ Usa através da interface
decimal desconto = _calculadora.CalcularDesconto(valor, anosCliente);
```

> O processador **não sabe** se é Fidelidade, VIP ou Comum. Só sabe que tem o método!

---

## 📊 Diagrama de Arquitetura

```
┌─────────────────────────────────────────────────────────────┐
│                   ProcessadorPagamento                      │
│                  (Módulo de Alto Nível)                     │
└─────────────────────────┬───────────────────────────────────┘
                          │
                          │ (depende de)
                          ↓
                ┌──────────────────────┐
                │ ICalculadoraDesconto │  ← ABSTRAÇÃO (Interface)
                └──────────────────────┘
                          ↑
            ┌─────────────┼─────────────┐
            │             │             │
    ┌───────┴──────┐ ┌───┴────┐ ┌─────┴──────┐
    │DescontoComum │ │Fidelidade│ │ DescontoVIP │
    └──────────────┘ └─────────┘ └────────────┘
         (Implementações - Módulos de Baixo Nível)
```

---

## 📖 Aprendizados

Durante o desenvolvimento deste projeto, aprendi:

✅ O que é o princípio DIP e por que é importante  
✅ Como criar e usar interfaces em C#  
✅ O conceito de Injeção de Dependência  
✅ A diferença entre acoplamento forte e fraco  
✅ Como tornar código mais flexível e testável  
✅ Polimorfismo na prática  
✅ Organização de código seguindo boas práticas  

---

## 🎓 Conceitos Importantes

### Interface
> Um contrato que define métodos que as classes devem implementar. Não contém implementação, apenas assinaturas.

### Injeção de Dependência
> Padrão onde uma classe recebe suas dependências de fora (geralmente via construtor) ao invés de criá-las internamente.

### Polimorfismo
> Capacidade de tratar objetos diferentes de forma uniforme através de uma interface comum.

### Acoplamento
> Grau de dependência entre classes. Quanto menor, melhor (mais flexível).

---

## 🔮 Possíveis Melhorias

- [ ] Adicionar persistência de dados (banco de dados)
- [ ] Criar interface gráfica (WPF ou WinForms)
- [ ] Implementar sistema de logging
- [ ] Adicionar testes unitários
- [ ] Criar API REST para o sistema
- [ ] Implementar outros princípios SOLID (SRP, OCP, LSP, ISP)

---

## 📚 Referências

- [Princípios SOLID - Microsoft Docs](https://docs.microsoft.com/pt-br/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)
- [C# Documentation](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [Clean Code by Robert C. Martin](https://www.amazon.com.br/C%C3%B3digo-Limpo-Robert-C-Martin/dp/8576082675)

---

## 👨‍💻 Autor

**Seu Nome**

- GitHub: [@seu-usuario](https://github.com/seu-usuario)
- LinkedIn: [Seu Nome](https://linkedin.com/in/seu-perfil)
- Email: seu.email@exemplo.com

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 🌟 Agradecimentos

Agradecimentos especiais ao professor [Nome do Professor] pela orientação no aprendizado dos princípios SOLID.

---

<div align="center">

**⭐ Se este projeto te ajudou, deixe uma estrela!**


</div>