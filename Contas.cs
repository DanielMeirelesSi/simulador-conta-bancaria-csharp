namespace SimuladorContaBancaria
{
// Classe que representa uma conta corrente.
// Nesse projeto ela herda o comportamento básico da ContaBancaria.
// A ideia é mostrar o uso de herança mesmo que a regra seja simples.
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente(string titular, string numero)
            : base(titular, numero)
        {
        }
    }

// Classe que representa um cofrinho.
// Funciona como uma conta separada para guardar dinheiro,
// mas sem rendimento automático.
    public class Cofrinho : ContaBancaria
    {
        public Cofrinho(string titular, string numero)
            : base(titular, numero)
        {
        }
    }
}