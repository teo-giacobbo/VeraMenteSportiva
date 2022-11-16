using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeraMente_Sportiva.Models;

namespace VeraMente_Sportiva.Controllers
{
    public class SocietaController : Controller
    {
        public ActionResult ChiSiamo()
        {
            return View();
        }

        public ActionResult ConsiglioDirettivo()
        {
            List<PersonaViewModel> listaPersone = new List<PersonaViewModel>();

            List<string> nomi = new List<string>();
            List<string> cognomi = new List<string>();
            List<string> ruoli = new List<string>();

            nomi.Add("Michele"); nomi.Add("Gaia");
            cognomi.Add("Fignelli"); cognomi.Add("Bernasconi");
            ruoli.Add("Presidente"); ruoli.Add("Vicepresidente");

            int index = 0;
            foreach (var item in nomi)
            {
                PersonaViewModel myPersona = new PersonaViewModel();
                myPersona.nome = item;
                myPersona.cognome = cognomi[index];
                myPersona.ruolo = ruoli[index];

                listaPersone.Add(myPersona);
                index++;
            }

            return View(listaPersone);
        }

        public ActionResult Sponsor()
        {
            return View();
        }
    }
}