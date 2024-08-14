namespace DesafioFundamentos
{
    using DesafioFundamentos.Extensions;
    using DesafioFundamentos.Models;
    using DesafioFundamentos.Repositories;
    using DesafioFundamentos.Resources;
    using DesafioFundamentos.Views;
    using System;
    using System.Globalization;

    /// <summary>
    /// Implementação da classe Program 
    /// </summary>
    public partial class Program : IDisposable
    {
        private readonly LocalizationResources _resources;
        private readonly ParkingRepository _repository;
        private readonly ParkingController _controller;
        private Boolean _disposable;
        /// <summary>
        /// Método construtor da classe
        /// </summary>
        /// <param name="resources">classe contendo as mensagens de recurso da feature Program</param>
        public Program(LocalizationResources resources)
        {
            // Coloca o encoding para UTF8 para exibir acentuação
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            _resources = resources;
            _repository = new ParkingRepository();
            _controller = new ParkingController(_repository, _resources.ParkingResources);
            _disposable = true;
        }

        /// <summary>
        /// Método utilizado para recuperar e validar um valor decimal informado pelo usuário
        /// </summary>
        /// <param name="message">Mensagem solicitando um valor decimal para o usuário</param>
        /// <param name="value">Valor retornado pela rotina</param>
        /// <param name="isValid">Status de execução da rotina</param>
        private void ReadDecimalData(String message, out Decimal value, out Boolean isValid)
        {
            var execute = true;
            isValid = true;
            value = Decimal.Zero;
            var counter = 0;

            while (execute)
            {
                Console.Write(message);
                var data = Console.ReadLine().Trim();
                var result = Decimal.TryParse(data, out Decimal validated);

                if (result)
                {
                    value = validated;
                    execute = false;
                }
                else 
                {
                    Console.WriteLine(_resources.ProgramResources.InvalidValueMessage);
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
        /// Método contendo as rotinas de execução do programa
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(CreateLine());
            Console.WriteLine(_resources.ProgramResources.WelcomeMessage);
            Console.WriteLine(CreateLine());

            ReadDecimalData(_resources.ProgramResources.InitialPriceMessage, out Decimal initialPrice, out Boolean isValid);

            if (isValid)
            {
                ReadDecimalData(_resources.ProgramResources.PricePerHourMessage, out Decimal pricePerHour, out isValid);
                if (isValid)
                {
                    // Instancia a classe Estacionamento, já com os valores obtidos anteriormente
                    var parking = new Parking(initialPrice, pricePerHour);
                    _controller.SetParking(parking);

                    var showMenu = true;

                    while (showMenu)
                    {
                        Console.Clear();
                        Console.WriteLine(CreateLine());
                        Console.WriteLine(_resources.ProgramResources.ApplicationNameMessage);
                        Console.WriteLine(CreateLine());
                        Console.WriteLine(String.Format(CultureInfo.CurrentCulture, _resources.ProgramResources.InitialPriceInfoMessage, initialPrice.FormatCurrency()));
                        Console.WriteLine(String.Format(CultureInfo.CurrentCulture, _resources.ProgramResources.PricePerHourInfoMessage, pricePerHour.FormatCurrency()));
                        Console.WriteLine(CreateLine());
                        Console.WriteLine(_resources.ProgramResources.ApplicationMenuMessage);
                        Console.WriteLine(_resources.ProgramResources.AddVehicleOptionMessage);
                        Console.WriteLine(_resources.ProgramResources.RemoveVehicleOptionMessage);
                        Console.WriteLine(_resources.ProgramResources.ListVehiclesOptionMessage);
                        Console.WriteLine(_resources.ProgramResources.FinishOptionMessage);
                        Console.Write(_resources.ProgramResources.SelectOptionMessage);

                        if (Int32.TryParse(Console.ReadLine(), out Int32 action))
                        {
                            switch (action)
                            {
                                case 1:
                                    Console.WriteLine(CreateLine());
                                    _controller.AddVehicle();
                                    break;

                                case 2:
                                    Console.WriteLine(CreateLine());
                                    _controller.RemoveVehicle();
                                    break;

                                case 3:
                                    Console.WriteLine(CreateLine());
                                    _controller.ListVehicles();
                                    break;

                                case 4:
                                    showMenu = false;
                                    break;

                                default:
                                    Console.WriteLine(CreateLine());
                                    Console.WriteLine(_resources.ProgramResources.InvalidOptionMessage);
                                    Console.ReadKey();
                                    break;
                            }

                        }
                    }

                    Console.WriteLine(CreateLine());
                    Console.WriteLine(_resources.ProgramResources.FinishMessage);
                    Console.ReadKey();
                }
            }

            if (!isValid)
            {
                Console.WriteLine(CreateLine());
                Console.WriteLine(_resources.ProgramResources.ErrorMessage);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Cria uma nova linha 
        /// </summary>
        /// <returns></returns>
        private static String CreateLine()
        {
            return new String('-', 40);
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
                _repository.Dispose();
                _controller.Dispose();
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
        ~Program()
        {
            Dispose(false);
        }

        /// <summary>
        /// Método de entrada do aplicativo
        /// </summary>
        public static void Main(String[] _)
        {
            var resources = new LocalizationResources();
            var program = new Program(resources);
            try
            {
                program.Execute();
                Console.WriteLine(resources.ProgramResources.PostFinishMessage);
                Console.ReadKey();
            }
            catch (ApplicationException ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            finally
            {
                program.Dispose();
            }

        }
    }
}