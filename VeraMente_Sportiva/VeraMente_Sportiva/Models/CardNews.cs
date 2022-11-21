using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeraMente_Sportiva.Models
{
    public class CardNews
    {
        public string immagine { get; set; }
        public string titolo { get; set; } 
        public string contenuto { get; set; }
        public List<string> tags { get; set; }
        public DateTime dataPubblicazione { get; set; }
    }
}