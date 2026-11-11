List<string> fila = new();
int opcao = -1;

while (opcao != 0)
{
    Console.WriteLine();
    Console.WriteLine("=== Barbearia Corte Certo ===");
    Console.WriteLine("1 - Adicionar pessoa à fila");
    Console.WriteLine("2 - Listar fila");
    Console.WriteLine("3 - Atender próximo cliente");
    Console.WriteLine("0 - Encerrar o programa");
    Console.Write("Escolha: ");

    bool converteu = int.TryParse(Console.ReadLine(), out opcao);
    if (!converteu)
    {
        opcao = -1;
        Console.WriteLine("Entrada inválida. Digite apenas números.");
        continue;
    }

    switch (opcao)
    {
        case 1:
        {
            // Entrada
            Console.Write("Digite o nome para entrar na fila: ");
            string nome = Console.ReadLine();

            // Validação
            if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length < 3)
            {
                Console.WriteLine("Nome inválido. Não pode ser vazio e deve ter pelo menos 3 caracteres.");
            }
            else
            {
                nome = nome.Trim();
                fila.Add(nome);
                Console.WriteLine($"{nome} entrou no final da fila.");
            }
            break;
        }

        case 2:
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("A fila está vazia.");
            }
            else
            {
                Console.WriteLine("Fila de atendimento:");
                for (int i = 0; i < fila.Count; i++)
                    Console.WriteLine($"{i + 1} {fila[i]}");
            }
            break;
        }

        case 3:
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("Não há pessoas aguardando.");
                break;
            }

            string atual = fila[0];

            Console.Write("Serviço escolhido (1, 2 ou 3): ");
            bool leuCodigo = int.TryParse(Console.ReadLine(), out int codigo);

            if (!leuCodigo)
            {
                Console.WriteLine($"Entrada inválida. Digite apenas números. {atual} continua no início da fila.");
                break;
            }

            if (!Enum.IsDefined(typeof(TipoServico), codigo))
            {
                Console.WriteLine($"Código de serviço inválido. {atual} continua no início da fila.");
                break;
            }

            TipoServico servico = (TipoServico)codigo;
            string nomeServico;
            decimal preco;

            switch (servico)
            {
                case TipoServico.CorteCabelo:
                    nomeServico = "Corte de cabelo";
                    preco = 40.00m;
                    break;
                case TipoServico.Barba:
                    nomeServico = "Barba";
                    preco = 25.00m;
                    break;
                case TipoServico.CorteBarba:
                    nomeServico = "Corte + barba";
                    preco = 55.00m;
                    break;
                default:
                    nomeServico = "Desconhecido";
                    preco = 0m;
                    break;
            }

            fila.RemoveAt(0);

            Console.WriteLine($"Atendimento de {atual} concluído. Serviço: {nomeServico}. Valor cobrado: R$ {preco:N2}.");
            break;
        }

        case 0:
            Console.WriteLine("Encerrando o programa. Até logo!");
            break;

        default:
            Console.WriteLine("Opção inválida. Escolha 1, 2, 3 ou 0.");
            break;
    }
}

enum TipoServico { CorteCabelo = 1, Barba = 2, CorteBarba = 3 }