using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeraMente_Sportiva.Models
{
    public class CalendarioViewModel
    {
        public string numeroGara { get; set; }
        public string dataOra { get; set; }
        public DateTime dataGara { get; set; }
        public string indirizzo { get; set; }
        public string luogo { get; set; }
        public string squadraCasa { get; set; }
        public string squadraOspite { get; set; }
        public string risultato { get; set; }
        public string parziali { get; set; }
    }
}