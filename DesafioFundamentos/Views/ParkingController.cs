namespace DesafioFundamentos.Views
{
    using DesafioFundamentos.Extensions;
    using DesafioFundamentos.Models;
    using DesafioFundamentos.Repositories;
    using DesafioFundamentos.Resources;
    using System;
    using System.Globalization;

    /// <summary>
    /// Classe que implementa os métodos para acesso as ações de um estacionamento.
    /// </summary>
    /// <param name="repository">classe contendo os métodos para gerenciamento do estacionamento</param>
    /// <param name="resources">classe contendo as mensagens de recurso da feature.</param>        
    /// 
    public class ParkingController(ParkingRepository repository, ParkingResources resources) : IDisposable
    {
        private Parking _parking;
        private Boolean _disposable = true;

        /// <summary>
        /// Método utilizado para configurar a entidade Estacionamento
        /// </summary>
        /// <param name="parking">>classe contendo valores padrão e métodos para o cálculo do valor conforme o período em que o veículo esteve estacionado.</param>
        public void SetParking(Parking parking)
        {
            _parking = parking;
        }

        /// <summary>
        /// Método destrutor da classe 
        /// </summary>
        /// <param name="disposing">Executa rotinas adicionais</param>
        /// 
        protected virtual void Dispose(Boolean disposing) 
        {
            if (_disposable && disposing) 
            {
                _disposable = false;
            }
        }

        /// <summary>
        /// Método destrutor da classe
        /// </summary>
        /// 
        public void Dispose() 
        { 
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Método destrutor da classe no Garbage Collection
        /// </summary>
        ~ParkingController() 
        {
            Dispose(false);
        }

        /// <summary>
        /// Entrada de um veículo no estacionamento
        /// </summary>
        /// 
        public void AddVehicle()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.Write(resources.AddVehicle);
            var vehicle = Console.ReadLine();
            if (vehicle.ContainsValue())
            {
                repository.AddVehicle(vehicle);
            }
            else
            {
                Console.WriteLine(resources.InvalidVehiclePlate);
            }
        }

        /// <summary>
        /// Método utilizado para recuperar e validar um valor decimal informado pelo usuário
        /// </summary>
        /// <param name="message">Mensagem solicitando um valor decimal para o usuário</param>
        /// <param name="value">Valor retornado pela rotina</param>
        /// <param name="isValid">Status de execução da rotina</param>
        private void ReadIntegerData(String message, out Int32 value, out Boolean isValid)
        {
            var execute = true;
            isValid = true;
            value = 0;
            var counter = 0;

            while (execute)
            {
                Console.Write(message);
                var data = Console.ReadLine().Trim();
                var result = Int32.TryParse(data, out Int32 validated);

                if (result)
                {
                    value = validated;
                    execute = false;
                }
                else
                {
                    Console.WriteLine(resources.InvalidHours);
                }

                counter++;
                if (counter > 2 && execute)
                {
                    isValid = false;
                    execute = false;
                }
            }
        }


        /// <summary>
        /// Saída de um veículo do estacionamento
        /// </summary>
        /// 
        public void RemoveVehicle()
        {
            Console.Write(resources.RemoveVehicle);

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            var vehiclePlate = Console.ReadLine();

            // Verifica se o veículo existe
            if (repository.VehicleExists(vehiclePlate)) {
                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                ReadIntegerData(resources.HoursParked, out Int32 hours, out Boolean isValid);
                if (isValid) 
                {
                    Decimal total = _parking.CalculateVehicleStay(hours);
                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    repository.RemoveVehicle(vehiclePlate);
                    Console.WriteLine(String.Format(CultureInfo.CurrentCulture, resources.VehiclePayment, [vehiclePlate, total.FormatCurrency()]));
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(resources.VehicleNotLocated);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Veículos estacionados
        /// </summary>
        public void ListVehicles()
        {
            // Verifica se há veículos no estacionamento
            if (repository.CountVehicles() > 0)
            {
                Console.WriteLine(resources.AvailableVehicles);
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                var vehicles = repository.ListVehicles();
                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine(vehicle);
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(resources.EmptyVehicles);
                Console.ReadKey();
            }
        }
    }
}
