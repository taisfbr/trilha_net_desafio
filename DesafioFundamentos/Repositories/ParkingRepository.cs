namespace DesafioFundamentos.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Classe que implementa as ações de um veículo no estacionamento
    /// </summary>
    /// 
    public class ParkingRepository : IDisposable
    {
        private readonly List<String> _vehicles;
        private Boolean _disposable;

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        /// 
        public ParkingRepository()
        {
            _vehicles = [];
            _disposable = true;
        }

        /// <summary>
        /// Método destrutor da classe
        /// </summary>
        /// <param name="disposing">Executa ações adicionais</param>
        /// 
        protected virtual void Dispose(Boolean disposing)
        {
            if (_disposable && disposing)
            {
                _disposable = false;
                _vehicles.Clear();
            }
        }

        /// <summary>
        /// Método destrutor da classe, 
        /// </summary>
        /// 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Método destrutor da classe
        /// </summary>
        /// 
        ~ParkingRepository()
        {
            Dispose(false);
        }

        /// <summary>
        /// Adiciona um veículo a lista
        /// </summary>
        /// <param name="plate">Placa do veículo</param>
        /// 
        public void AddVehicle(String plate)
        {
            _vehicles.Add(plate);
        }

        /// <summary>
        /// Remove o veículo da lista
        /// </summary>
        /// <param name="plate">Placa do veículo</param>
        /// 
        public void RemoveVehicle(String plate) 
        { 
            _vehicles.Remove(plate);
        }

        /// <summary>
        /// Lista os veículos estacionados
        /// </summary>
        /// <returns>Os veículos estacionados</returns>
        /// 
        public IEnumerable<String> ListVehicles() 
        { 
            return _vehicles;
        }

        /// <summary>
        /// Verifica se o veículo foi estacionado
        /// </summary>
        /// <param name="plate">Placa do veículo</param>
        /// <returns>O status da consulta</returns>
        /// 
        public Boolean VehicleExists(String plate)
        {
            return _vehicles.Any(x => x.ToUpper(CultureInfo.CurrentCulture).Equals(plate.ToUpper(CultureInfo.CurrentCulture), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Efeuta a contagem de veículos estacionados
        /// </summary>
        /// <returns>Total de veículos estacionados</returns>
        /// 
        public Int32 CountVehicles() 
        {
            return _vehicles.Count;
        }
    }
}
