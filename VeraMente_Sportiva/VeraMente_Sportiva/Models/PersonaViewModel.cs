using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeraMente_Sportiva.Models
{
    public class PersonaViewModel
    {
        public string nome { get; set; }
        public string cognome { get; set; }
        public string ruolo { get; set; }
        public int numero { get; set; }
        public bool isCapitano { get; set; }
        public string immagine { get; set; }
    }
}