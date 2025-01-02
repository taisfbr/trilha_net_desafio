using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class VehicleModel
    {
        public string Plate { get; set; }
        public DateTime RegistedAt { get; set; }

        public VehicleModel(string plate)
        {
            this.Plate = plate;
            this.RegistedAt = DateTime.Now;
        }

    }
}
