using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Unidad
    {
        public int Id { get; set; }


        [DisplayName("Propietario")]
        public Propietario Propietario { get; set; }


        [DisplayName("Numero De la Unidad")]
        public int NumUnidad { get; set; }


        [DisplayName("Numero Del Piso")]
        public int Piso { get; set; }

        [DisplayName("Numero  Del Porcetanje")]
        public decimal Porcentaje { get; set; }



        [DisplayName("Gastos Mensuales")]



        public decimal GastosMensuales { get; set; }

        [DisplayName("Edificio")]
        public Edificio Edificio { get; set; }

    }
}
