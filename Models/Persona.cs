using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase3MVC.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return $"({Id}) {Nombre} {Email}";
        }



    }
}
