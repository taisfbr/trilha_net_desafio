using DesafioFundamentos;

Console.Clear();
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine($"Seja bem vindo ao sistema de estacionamento!\n\n" +
                  "Por gentileza digite o preço fixo para estacionar: \n");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine($"\nAgora digite o preço por hora: \n");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// TODO: Cadastro de usuario do Sistema e Cadastro de Usuario do Estacionamento vinculado a Placa!!
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine( 
        
                    $"Digite a sua opção: \n\n" + 
                    
                    "1 - Cadastrar veículo \n" +
                    "2 - Remover veículo \n" +
                    "3 - Listar veículos \n" +
                    "\n0 - Encerrar \n\n"
                    
                    );
    
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "0":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    if (opcao != "0" )
    {
    Console.WriteLine($"\nPressione uma tecla para continuar");
    Console.ReadLine();
    }
    
    }

Console.WriteLine("O programa se encerrou");
