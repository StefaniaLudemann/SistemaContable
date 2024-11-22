using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Propietario
    {
        public int Id { get; set; }

        [DisplayName("Nombre Del Propietario")]
        public string Nombre { get; set; }

        [DisplayName("Apellido Del Propietario")]
        public string Apellido { get; set; }


        [DisplayName("Numero De Documento")]
        public string NUmeroDocumento { get; set; }


        [DisplayName("Email")]
        public string Email { get; set; }


        [DisplayName("Telefono")]
        public string Telefono { get; set; }


        [DisplayName("Foto")]
        public string Foto { get; set; }
    }
}
