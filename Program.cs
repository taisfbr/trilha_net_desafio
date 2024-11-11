using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
//Possivel excepção pelo input do úsuario
do
{
    try //Verificar se o código da erro
    {   
        Console.WriteLine("Digite o preço inicial:");
        precoInicial = Convert.ToDecimal(Console.ReadLine()); //Números negativos permitidos

        Console.WriteLine("Agora digite o preço por hora:");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());
        break; // Se o "try" não detecta nenhuma excepção, quebrar o loop e continuar o programa.
        // Poderia dar uma melhorada para que o úsuario não tivesse que inserir o preço inicial duas veces em caso de falha no preco por hora, mais isso funciona :^)
    }
    catch
    {
        Console.WriteLine("Entrada Inválida, tente novamente");
        continue; // Se o "try" for pegar uma exepção, tentar de novo.
    }
}
while (true); //Comecei com booleano mais lembrei que o "break" e "continue" existiam então usei eles.

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
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

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
