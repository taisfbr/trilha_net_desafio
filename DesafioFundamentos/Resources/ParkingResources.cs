namespace DesafioFundamentos.Resources
{
    using System;
    /// <summary>
    /// Classe contendo as mensagens utilizadas na feature Estacionamento
    /// </summary>
    /// 
    public class ParkingResources
    {
        private readonly String _addVehicle;
        private readonly String _removeVehicle;
        private readonly String _hoursParked;
        private readonly String _vehicleNotLocated;
        private readonly String _availableVehicles;
        private readonly String _emptyVehicles;
        private readonly String _invalidVehiclePlate;
        private readonly String _invalidHours;
        private readonly String _emptyHours;
        private readonly String _vehiclePayment;

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        /// 
        public ParkingResources()
        {
            _addVehicle = "Digite a placa do veículo para estacionar: ";
            _removeVehicle = "Digite a placa do veículo para remover: ";
            _hoursParked = "Digite a quantidade de horas que o veículo permaneceu estacionado: ";
            _vehicleNotLocated = "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente";
            _availableVehicles = "Os veículos estacionados são: ";
            _emptyVehicles = "Não há veículos estacionados.";
            _invalidVehiclePlate = "Por favor, informe a placa do veículo.";
            _vehiclePayment = "O veículo {0} foi removido e o preço total foi de: R$ {1}";
            _invalidHours = "Valor informado inválido para o campo horas.";
            _emptyHours= "Por favor informe as horas.";
        }

        /// <summary>
        /// Mensagem solicitando a placa de um veículo para a entrada no estacionamento
        /// </summary>
        /// 
        public String AddVehicle => _addVehicle;

        /// <summary>
        /// Mensagem solicitando a placa de um veículo para a saída do estacionamento
        /// </summary>
        /// 
        public String RemoveVehicle => _removeVehicle;

        /// <summary>
        /// Mensagem solicitando a quantidade de horas em que o veículo ficou estacionado
        /// </summary>
        /// 
        public String HoursParked => _hoursParked;

        /// <summary>
        /// Mensagem informando que o veículo não foi estacionado
        /// </summary>
        /// 
        public String VehicleNotLocated => _vehicleNotLocated;

        /// <summary>
        /// Mensagem informando os veículos estacionados
        /// </summary>
        /// 
        public String AvailableVehicles => _availableVehicles;

        /// <summary>
        /// Mensagem informando que não há veículos estacionados
        /// </summary>
        /// 
        public String EmptyVehicles => _emptyVehicles;

        /// <summary>
        /// Mensagem informando que a placa do veículo é inválida.
        /// </summary>
        /// 
        public String InvalidVehiclePlate => _invalidVehiclePlate;

        /// <summary>
        /// Mensagem informando que o véiculo informado foi removido e o valor total do período em que o veículo ficou no estacionamento
        /// </summary>
        /// 
        public String VehiclePayment => _vehiclePayment;

        /// <summary>
        /// Mensagem informando que o total de horas informado é inválido.
        /// </summary>
        /// 
        public String InvalidHours => _invalidHours;

        /// <summary>
        /// Mensagem infomando que não foi informado o total de horas
        /// </summary>
        /// 
        public String EmptyHours => _emptyHours;
    }
}
