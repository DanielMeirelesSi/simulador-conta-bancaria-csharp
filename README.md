# Simulador Bancário em C# (Utilizando Programação Orientada a Objetos)

Esse projeto foi desenvolvido com o objetivo de praticar conceitos de Programação Orientada a Objetos (POO), especialmente encapsulamento, herança e organização de código.

Minha ideia foi criar um pequeno sistema de console que simula operações bancárias básicas, incluindo uma conta corrente e um "cofrinho" separado, com comportamento semelhante ao de um banco real.

---

## Conceitos Aplicados

**Encapsulamento**  
O saldo das contas não pode ser alterado diretamente. Ele só pode ser modificado através dos métodos definidos na própria classe (Depósito e Saque).

**Herança**  
As classes `ContaCorrente` e `Cofrinho` herdam de `ContaBancaria`, reaproveitando regras básicas e mantendo o código organizado.

**Regras de Negócio Implementadas**
- Depositar na conta corrente representa entrada de dinheiro.
- Guardar dinheiro no cofrinho retira o valor da conta corrente.
- Retirar dinheiro do cofrinho devolve o valor para a conta corrente.
- Sacar da conta corrente representa um pagamento (o dinheiro sai do sistema).
- A simulação de rendimento é apenas ilustrativa e não altera os saldos reais.

---

## Funcionalidades

- Definição dinâmica do titular no início do sistema
- Visualização de saldo da conta corrente e do cofrinho
- Depósito na conta corrente
- Transferência da corrente para o cofrinho
- Retirada do cofrinho para a corrente
- Saque direto da conta corrente
- Simulação de rendimento de 30 dias a 1%
- Menu interativo no console

---

## Estrutura do Projeto

SimuladorContaBancaria/
- ContaBancaria.cs
- Contas.cs
- Program.cs

- `ContaBancaria.cs` → Classe base com as regras principais de saldo, depósito e saque.
- `Contas.cs` → Implementação da ContaCorrente e do Cofrinho.
- `Program.cs` → Menu interativo e controle do fluxo do sistema.

---

## Como Executar

É necessário ter o .NET SDK instalado.

No terminal, dentro da pasta do projeto, basta executar o comando: dotnet run

## Demonstração

### Menu Principal
![Menu](assets/print%201.png)

### Consulta de Saldos
![Saldos](assets/print%202.png)

### Simulação de Rendimento
![Simulação](assets/print%203.png)