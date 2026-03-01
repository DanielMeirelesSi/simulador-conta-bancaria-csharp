using System;
using System.Globalization;

namespace SimuladorContaBancaria
{
    // Classe principal do sistema.
    // Aqui está o menu interativo que simula as operações bancárias
    // utilizando as classes criadas anteriormente.
    class Program
    {
        // Método principal.
        // Inicializa as contas e controla o fluxo do menu.
        static void Main()
        {
            string titular;

            do
            {
                Console.Write("Qual o nome do titular da conta? ");
                titular = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(titular));

            // Deixa o nome mais apresentável (primeira letra de cada palavra em maiúsculo)
            titular = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(titular.Trim().ToLower());

            var corrente = new ContaCorrente(titular, "0001-CC");
            var cofrinho = new Cofrinho(titular, "0001-CF");

            while (true)
            {
                Console.Clear();
                Titulo($"BANCO MEIRELES - TITULAR: {titular}");

                Console.WriteLine("1) Ver saldo");
                Console.WriteLine("2) Depositar");
                Console.WriteLine("3) Sacar");
                Console.WriteLine("4) Simular rendimento de 30 dias a 1%");
                Console.WriteLine("0) Sair");
                Linha();

                Console.Write("Opção: ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        VerSaldo(corrente, cofrinho);
                        break;
                    case "2":
                        Depositar(corrente, cofrinho);
                        break;
                    case "3":
                        Sacar(corrente, cofrinho);
                        break;
                    case "4":
                        SimularRendimento();
                        break;
                    case "0":
                        return;
                    default:
                        Pausa("Opção inválida.");
                        break;
                }
            }
        }

        // Exibe os saldos atuais da conta corrente e do cofrinho.
        static void VerSaldo(ContaCorrente corrente, Cofrinho cofrinho)
        {
            Console.Clear();
            Titulo("SALDOS");

            Console.WriteLine($"Conta Corrente ({corrente.Numero})");
            Console.WriteLine($"Saldo atual: R$ {corrente.Saldo:N2}");
            Linha();

            Console.WriteLine($"Cofrinho ({cofrinho.Numero})");
            Console.WriteLine($"Saldo atual: R$ {cofrinho.Saldo:N2}");
            Linha();

            Pausa("Consulta finalizada.");
        }

        // Controla as operações de depósito.
        // Pode representar entrada de dinheiro na corrente
        // ou transferência da corrente para o cofrinho.
        static void Depositar(ContaCorrente corrente, Cofrinho cofrinho)
        {
            Console.Clear();
            Titulo("DEPÓSITO");

            Console.WriteLine("Escolha a operação:");
            Console.WriteLine("1) Depositar na Conta Corrente");
            Console.WriteLine("2) Guardar no Cofrinho");
            Linha();

            Console.Write("Opção: ");
            string? opcao = Console.ReadLine();

            if (opcao != "1" && opcao != "2")
            {
                Pausa("Opção inválida.");
                return;
            }

            decimal valor = LerValor("Valor: ");
            if (valor <= 0)
            {
                Pausa("Valor inválido.");
                return;
            }

            if (opcao == "1")
            {
                // Entrada de dinheiro na conta corrente
                corrente.Depositar(valor);
                Pausa("Depósito realizado na conta corrente.");
                return;
            }

            // Guardar no cofrinho = transferir da corrente para o cofrinho
            if (valor > corrente.Saldo)
            {
                Pausa("Saldo insuficiente na conta corrente.");
                return;
            }

            corrente.Sacar(valor);
            cofrinho.Depositar(valor);

            Pausa("Valor guardado no cofrinho.");
        }

        // Controla as operações de saque.
        // Pode representar um gasto direto da conta corrente
        // ou a retirada de dinheiro do cofrinho para a corrente.
        static void Sacar(ContaCorrente corrente, Cofrinho cofrinho)
        {
            Console.Clear();
            Titulo("SAQUE");

            Console.WriteLine("Escolha a operação:");
            Console.WriteLine("1) Sacar da Conta Corrente");
            Console.WriteLine("2) Retirar do Cofrinho");
            Linha();

            Console.Write("Opção: ");
            string? opcao = Console.ReadLine();

            if (opcao != "1" && opcao != "2")
            {
                Pausa("Opção inválida.");
                return;
            }

            decimal valor = LerValor("Valor: ");
            if (valor <= 0)
            {
                Pausa("Valor inválido.");
                return;
            }

            if (opcao == "1")
            {
                // Saque da corrente = dinheiro sai do sistema (pagamento)
                bool ok = corrente.Sacar(valor);
                Pausa(ok ? "Saque realizado na conta corrente." : "Saldo insuficiente na conta corrente.");
                return;
            }

            // Retirar do cofrinho = transferir do cofrinho para a corrente
            if (valor > cofrinho.Saldo)
            {
                Pausa("Saldo insuficiente no cofrinho.");
                return;
            }

            cofrinho.Sacar(valor);
            corrente.Depositar(valor);

            Pausa("Valor retirado do cofrinho e devolvido para a conta corrente.");
        }

        // Simula um rendimento fixo de 1% em 30 dias.
        // Essa operação é apenas ilustrativa e não altera os saldos reais.
        static void SimularRendimento()
        {
            while (true)
            {
                Console.Clear();
                Titulo("SIMULAR RENDIMENTO (30 DIAS / 1%)");

                decimal valor = LerValor("Valor para simular: ");
                if (valor <= 0)
                {
                    Pausa("Valor inválido.");
                    continue;
                }

                decimal resultado = valor * 1.01m;
                decimal ganho = resultado - valor;

                Linha();
                Console.WriteLine($"Valor inicial:     R$ {valor:N2}");
                Console.WriteLine($"Após 30 dias:      R$ {resultado:N2}");
                Console.WriteLine($"Ganho estimado:    R$ {ganho:N2}");
                Linha();

                Console.WriteLine("1) Fazer outra simulação");
                Console.WriteLine("0) Voltar ao menu principal");
                Linha();

                Console.Write("Opção: ");
                string? opcao = Console.ReadLine();

                if (opcao == "0")
                    return;
            }
        }

        // Método auxiliar para leitura de valores decimais.
        // Aceita vírgula ou ponto como separador.
        static decimal LerValor(string mensagem)
        {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine();

            entrada = entrada?.Replace(',', '.');

            if (decimal.TryParse(entrada, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valor))
                return valor;

            return -1m;
        }

        // Método auxiliar para padronizar os títulos das telas.
        static void Titulo(string texto)
        {
            Linha();
            Console.WriteLine(texto);
            Linha();
        }

        // Método auxiliar que imprime uma linha separadora no console.
        static void Linha()
        {
            Console.WriteLine(new string('-', 40));
        }

        // Método auxiliar para pausar o sistema
        // até que o usuário pressione ENTER.
        static void Pausa(string mensagem)
        {
            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}