namespace DesafioFundamentos.Resources
{
    using System;
    /// <summary>
    /// Classe contendo as mensagens utilizadas no programa 
    /// </summary>
    public class LocalizationResources
    {
        private readonly ProgramResources _programResources;
        private readonly ParkingResources _parkingResources;

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public LocalizationResources()
        {
            _programResources = new ProgramResources();
            _parkingResources = new ParkingResources();
        }

        /// <summary>
        /// Classe contendo as mensagens utilizadas na feature Program
        /// </summary>
        public ProgramResources ProgramResources => _programResources;

        /// <summary>
        /// Classe contendo as mensagens utilizadas na feature Estacionamento
        /// </summary>
        public ParkingResources ParkingResources => _parkingResources;
    }
}
