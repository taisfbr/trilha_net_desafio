using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trilha_net_fundamentos_desafio.DesafioFundamentos.Models
{
    public class Carro
    {
        public string Placa { get; set; }
        public DateTime Entrada { get; set; } = DateTime.Now;
        public DateTime Saida { get; set; }

        public Carro(string placa)
        {
            Placa = placa;
        }


    }
}
