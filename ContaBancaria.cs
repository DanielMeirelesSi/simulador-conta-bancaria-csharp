using System;

namespace SimuladorContaBancaria
{
// Classe base que representa uma conta bancária genérica.
// Aqui centralizo as regras principais como saldo, depósito e saque.
// O saldo é protegido para garantir encapsulamento, ou seja,
// ele só pode ser alterado através dos métodos da própria classe.
    public abstract class ContaBancaria
    {
        public string Titular { get; }
        public string Numero { get; }
        public decimal Saldo { get; protected set; }

        // Construtor da conta.
        // Toda conta começa com saldo zerado.
        protected ContaBancaria(string titular, string numero)
        {
            Titular = titular;
            Numero = numero;
            Saldo = 0m;
        }

        // Método responsável por adicionar dinheiro à conta.
        // Só permite valores positivos.
        public bool Depositar(decimal valor)
        {
            if (valor <= 0) return false;

            Saldo += valor;
            return true;
        }

        // Método responsável por retirar dinheiro da conta.
        // Verifica se o valor é válido e se existe saldo suficiente.
        public bool Sacar(decimal valor)
        {
            if (valor <= 0) return false;
            if (valor > Saldo) return false;

            Saldo -= valor;
            return true;
        }
    }
}