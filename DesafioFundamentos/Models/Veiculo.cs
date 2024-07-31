namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }

        public Veiculo() { }
        public Veiculo(string placa)
        {
            Placa = placa;
        }
    }
}