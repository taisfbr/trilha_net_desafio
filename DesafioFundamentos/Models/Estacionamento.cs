using System.Collections;
using System.Globalization;
using System.IO.Compression;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // implementado
            Console.Clear();
            string Carro;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite a placa do veículo para estacionar: ou 'menu' para voltar");
                Carro = Console.ReadLine().ToUpper();
            } while (string.IsNullOrWhiteSpace(Carro) || Carro == "menu");

            if (Carro != "MENU")
            {
                try
                {
                    veiculos.Add(Carro);
                    if (veiculos.Any(x => x.ToUpper() == Carro.ToUpper()))
                    {
                        Console.WriteLine("Veiculo cadastrado com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, o Veiculo não foi cadastrado no sistema \n tente novamente");
                    }
                }
                catch
                {
                    Console.WriteLine("Desculpe ouve um erro ao cadastra o veiculo \n tente novamente");
                }
            }
            else
            {

            }
        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            Console.WriteLine("***************************************");
            //implementado

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                //implementado
                int horas = 0;
                decimal valorTotal = 0;
                bool VerificaSeDeletou = false;

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                horas = int.Parse(Console.ReadLine());
                Console.Clear();

                //caldulo do valor das horas a pagar pele estacionamento
                valorTotal = precoInicial + precoPorHora * horas;

                try
                {
                    Console.WriteLine($"Deseja DELETAR o carro: {placa} S/N");
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "S":
                            veiculos.Remove(placa);
                            VerificaSeDeletou = true;
                            break;
                        case "N":
                            Console.WriteLine($"Veiculo: {placa}, NÂO deletado");
                            break;
                    }

                    Console.Clear();
                    if (VerificaSeDeletou)
                    {
                        if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                        {
                            Console.WriteLine("*******************************************************");
                            Console.WriteLine("* Desculpe, ouve um erro e o veiculo não foi deletado *");
                            Console.WriteLine("*******************************************************");
                        }
                        else
                        {
                            Console.WriteLine("*************************************************************************");
                            Console.WriteLine($"* O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}         *");
                            Console.WriteLine("*************************************************************************");
                        }
                    }

                }
                catch
                {

                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            // Verifica se há veículos no estacionamento
            try
            {
                if (veiculos.Any())
                {
                    Console.WriteLine("Os veículos estacionados são:");
                    //implementado
                    bool tracos = false;
                    Console.WriteLine($"*************************");
                    foreach (string carro in veiculos)
                    {
                        if (tracos)
                        {
                            Console.WriteLine($"* --------------------- *");
                        }
                        Console.WriteLine($"* carro placa: {carro} *");
                        tracos = true;
                    }
                    Console.WriteLine($"*************************");
                }
                else
                {
                    Console.WriteLine("Não há veículos estacionados.");
                }
            }
            catch
            {
                Console.WriteLine("desculpe, ouve um erro e não foi possivem listar os carros");
            }
        }
    }
}