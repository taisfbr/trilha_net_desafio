namespace DesafioFundamentos.Resources
{
    using System;
    /// <summary>
    /// Classe contendo as mensagens utilizadas na feature Program
    /// </summary>
    ///
    public class ProgramResources
    {
        private readonly String _welcomeMessage;
        private readonly String _initialPriceMessage;
        private readonly String _pricePerHourMessage;
        private readonly String _invalidOptionMessage;
        private readonly String _finishMessage;
        private readonly String _postFinishMessage;
        private readonly String _errorMessage;
        private readonly String _selectOptionMessage;
        private readonly String _addVehicleOptionMessage;
        private readonly String _removeVehicleOptionMessage;
        private readonly String _listVehiclesOptionMessage;
        private readonly String _finishOptionMessage;
        private readonly String _invalidValueMessage;
        private readonly String _applicationNameMessage;
        private readonly String _applicationMenuMessage;
        private readonly String _initialPriceInfoMessage;
        private readonly String _pricePerHourInfoMessage;

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public ProgramResources()
        {
            _welcomeMessage = "Seja bem vindo ao sistema de estacionamento!";
            _initialPriceMessage = "Digite o preço inicial: ";
            _pricePerHourMessage = "Agora digite o preço por hora: ";
            _invalidOptionMessage = "Opção inválida.";
            _finishMessage = "Pressione uma tecla para finalizar o programa...";
            _postFinishMessage = "O programa finalizou.";
            _errorMessage = "Houve um ou mais erros na execução do aplicativo.";
            _selectOptionMessage = "Digite a sua opção: ";
            _addVehicleOptionMessage = "1 - Cadastrar veículo";
            _removeVehicleOptionMessage = "2 - Remover veículo";
            _listVehiclesOptionMessage = "3 - Listar veículos";
            _finishOptionMessage = "4 - Encerrar";
            _invalidValueMessage = "Valor informado inválido.";
            _applicationNameMessage = "Sistema de estacionamento";
            _applicationMenuMessage = "Menu do sistema";
            _initialPriceInfoMessage = "Valor inicial : {0}";
            _pricePerHourInfoMessage = "Preço por hora: {0}";
        }

        /// <summary>
        /// Mensagem de início do programa
        /// </summary>
        public String WelcomeMessage => _welcomeMessage;

        /// <summary>
        /// Mensagem solicitando o valor inicial de estacionamento do veículo
        /// </summary>
        public String InitialPriceMessage => _initialPriceMessage;

        /// <summary>
        /// Mensagem solicitando o valor por hora em que o veículo fica no estacionamento
        /// </summary>
        public String PricePerHourMessage => _pricePerHourMessage;

        /// <summary>
        /// Mensagem informando que foi informada uma opção inválida na seleção de um item do menu
        /// </summary>
        public String InvalidOptionMessage => _invalidOptionMessage;

        /// <summary>
        /// Exibe a mensagem de término de execução do aplicativo
        /// </summary>
        public String FinishMessage => _finishMessage;

        /// <summary>
        /// Mensagem adicional de término de execução do aplicativo
        /// </summary>
        public String PostFinishMessage => _postFinishMessage;

        /// <summary>
        /// Mensagem de erro ao informar um valor inválido para os campos valor inicial ou preço por hora
        /// </summary>
        public String ErrorMessage => _errorMessage;

        /// <summary>
        /// Mensagem solicitando que o usuário selecione uma opção do menu
        /// </summary>
        public String SelectOptionMessage => _selectOptionMessage;

        /// <summary>
        /// Mensagem exibindo opção para cadastrar um veículo
        /// </summary>
        public String AddVehicleOptionMessage => _addVehicleOptionMessage;

        /// <summary>
        /// Mensagem exibindo opção para remover e exibir o total do valor referente ao período em que o veículo ficou estacionado
        /// </summary>
        public String RemoveVehicleOptionMessage => _removeVehicleOptionMessage;

        /// <summary>
        /// Mensagem exibindo opção para listar veículos
        /// </summary>
        public String ListVehiclesOptionMessage => _listVehiclesOptionMessage;

        /// <summary>
        /// Mensagem exibindo opção para finalizar o programa
        /// </summary>
        public String FinishOptionMessage => _finishOptionMessage;

        /// <summary>
        /// Mensagem informando que foi digitado um valor inválido para o campo
        /// </summary>
        public String InvalidValueMessage => _invalidValueMessage;

        /// <summary>
        /// Mensagem informando o nome do aplicativo
        /// </summary>
        public String ApplicationNameMessage => _applicationNameMessage;

        /// <summary>
        /// Mensagem informando o menu do aplicativo
        /// </summary>
        public String ApplicationMenuMessage => _applicationMenuMessage;

        /// <summary>
        /// Mensagem que exibe o valor inicial ao estacionar o veículo
        /// </summary>
        public String InitialPriceInfoMessage => _initialPriceInfoMessage;
        
        /// <summary>
        /// Mensagem que exibe o valor por hora em que o veículo fique estacionado
        /// </summary>
        public String PricePerHourInfoMessage => _pricePerHourInfoMessage;

    }
}
