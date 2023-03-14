using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientes
{
    internal class Cliente
    { 
        //Crea los atributos con sus respectivos getters y setters
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public string Tel {get; set; }
        public bool Estado { get; set; }

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }

    }
}
