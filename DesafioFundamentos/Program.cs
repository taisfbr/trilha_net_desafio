using  ProjetoTeste.Models;

Estacionamento estacionamento = new Estacionamento();

Console.WriteLine ("Bem vindo ao registro de veiculos do estacionamento do junior");

bool exibirMenu = true;

while(exibirMenu){
    Console.Clear();
    Console.WriteLine (" 1 - Cadastrar Veiculo");
    Console.WriteLine (" 2 - Listar Veiculos");
    Console.WriteLine (" 3 - Remover Veiculos");
    Console.WriteLine (" 4 - Encerrar Programa");
    Console.WriteLine (" Digite sua Opcao: ");

    switch (Console.ReadLine()){
        
        case "1": estacionamento.AdicionarVeiculo();
        break;
        
        case "2": estacionamento.ListarVeiculos();
        break;

        case "3": estacionamento.RemoverVeiculo();
        break;

        case "4": exibirMenu = false;
        break;

        default: Console.WriteLine ("Opcao invalida");
        break;
    }
    Console.WriteLine ("Pressione enter para continuar: ");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");

