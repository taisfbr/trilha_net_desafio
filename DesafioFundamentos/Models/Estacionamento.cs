using System.Text.RegularExpressions;
using Microsoft.Win32.SafeHandles;
using System;


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
            //Pedir para o usuário digitar uma placa e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa);
            var resultado = ValidarPlaca(placa);
            var mensagem = resultado ? "é válida" : "não é válida";

            Console.WriteLine($"A placa informada {mensagem}");
            Console.ReadKey();
        }

        public static bool ValidarPlaca(string placa1)
        {
            if (string.IsNullOrWhiteSpace(placa1)) { return false; }

            if (placa1.Length > 8) { return false; }

            placa1 = placa1.Replace("-", "").Trim();

            if (char.IsLetter(placa1, 4))
            {
                var padraoMercoSul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercoSul.IsMatch(placa1);
            }
            else
            {
                var placaNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return placaNormal.IsMatch(placa1);
            }
        }



        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            // Pedir para o usuário digitar a placa e armazenar na variável placa

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                //Pede para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                //Realiza o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                

                int horas = 0;
                horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas;
                // Remove a placa digitada da lista de veículos

                veiculos.Remove(placa);
                // Usa códigos ANSI para negrito no console 
                Console.WriteLine($"O veículo de placa:\u001b[1m{placa}\u001b[0m foi removido e o preço total a se pagar é de:R$\u001b[1m{valorTotal}\u001b[0m");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Realiza um laço de repetição, exibindo os veículos estacionados
                int contadorForeach = 1;
                foreach (string item in veiculos)
                {
                    Console.WriteLine($"Veículo N° {contadorForeach} - {item}");
                    contadorForeach++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
