namespace DesafioFundamentos.Models
{
    using System;

    /// <summary>
    /// Implementação da classe Estacionamento
    /// </summary>
    /// 
    public class Parking
    {
        private readonly Decimal _initialPrice;
        private readonly Decimal _pricePerHour;

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        /// <param name="initialPrice">Valor da entrada no estacionamento</param>
        /// <param name="pricePerHour">Valor cobrado a cada hora estacionado</param>
        /// 
        public Parking(Decimal initialPrice, Decimal pricePerHour)
        {
            _initialPrice = initialPrice;
            _pricePerHour = pricePerHour;
        }

        /// <summary>
        /// Calcula o valor do período em que o veículo esteve estacionado
        /// </summary>
        /// <param name="hours">Horas em que o veículo esteve estacionado</param>
        /// <returns></returns>
        ///
        public Decimal CalculateVehicleStay(Int32 hours)
        {
            if (hours < 1) return (_initialPrice + _pricePerHour);
            return  (_initialPrice + _pricePerHour) * hours;
        }

        /// <summary>
        /// Valor inicial ao estacionar o veículo
        /// </summary>
        public Decimal InitialPrice => _initialPrice;

        /// <summary>
        /// Preço por hora em que o veículo fica estacionado
        /// </summary>
        public Decimal PricePerHour => _pricePerHour;
    }
}
