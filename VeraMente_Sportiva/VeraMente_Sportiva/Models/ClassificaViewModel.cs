using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeraMente_Sportiva.Models
{
    public class ClassificaViewModel
    {
        public int posizione { get; set; }
        public string immagineSquadra { get; set; }
        public string squadra { get; set; }
        public int punti { get; set; }
        public int giornate { get; set; }
        public int giornateVinte { get; set; }
        public int giornatePerse { get; set; }
        public int setVinti { get; set; }
        public int setPersi { get; set; }
        public int puntiFatti { get; set; }
        public int puntiPersi { get; set; }
    }
}