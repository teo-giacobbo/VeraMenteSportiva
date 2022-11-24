using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using VeraMente_Sportiva.Models;

namespace VeraMente_Sportiva.Controllers
{
    public class CampionatiController : Controller
    {
        public ActionResult Index(string campionato, string sezione = "Squadra")
        {
            ViewBag.Campionato = campionato;
            ViewBag.Sezione = sezione;
            return View();
        }

        public ActionResult Squadra(string campionato)
        {
            List<PersonaViewModel> listaStaff = new List<PersonaViewModel>();
            List<PersonaViewModel> listaGiocatori = new List<PersonaViewModel>();

            List<string> nomi = new List<string>();
            List<string> cognomi = new List<string>();
            List<string> ruoli = new List<string>();
            List<int> numeri = new List<int>();

            nomi.Add("Angelo"); nomi.Add("Teo");
            cognomi.Add("Battaglia"); cognomi.Add("Giacobbo");
            ruoli.Add("Primo allenatore"); ruoli.Add("Secondo allenatore");

            int index = 0;
            foreach (var item in nomi)
            {
                PersonaViewModel myPersona = new PersonaViewModel();
                myPersona.nome = item;
                myPersona.cognome = cognomi[index];
                myPersona.ruolo = ruoli[index];

                listaStaff.Add(myPersona);
                index++;
            }

            nomi = new List<string>();
            cognomi = new List<string>();
            ruoli = new List<string>();

            #region DATI GIOCATORI

            nomi.Add("Alessandro");
            cognomi.Add("Arberi");
            ruoli.Add("Schiacciatore");
            numeri.Add(13);

            nomi.Add("Francesco");
            cognomi.Add("Di Palma");
            ruoli.Add("Libero");
            numeri.Add(1);

            nomi.Add("Marco");
            cognomi.Add("Daverio");
            ruoli.Add("Schiacciatore");
            numeri.Add(3);

            nomi.Add("Josè");
            cognomi.Add("Palomino");
            ruoli.Add("Opposto");
            numeri.Add(4);

            nomi.Add("Giacomo");
            cognomi.Add("Franco");
            ruoli.Add("Schiacciatore");
            numeri.Add(5);

            nomi.Add("Emanuele");
            cognomi.Add("Reggiori");
            ruoli.Add("Schiacciatore");
            numeri.Add(6);

            nomi.Add("Davide");
            cognomi.Add("Melloni");
            ruoli.Add("Centrale");
            numeri.Add(7);

            nomi.Add("Matteo");
            cognomi.Add("Carcano");
            ruoli.Add("Alzatore");
            numeri.Add(8);

            nomi.Add("Emanuele");
            cognomi.Add("Mazzola");
            ruoli.Add("Schiacciatore");
            numeri.Add(9);

            nomi.Add("Simone");
            cognomi.Add("Soldo");
            ruoli.Add("Alzatore");
            numeri.Add(22);

            nomi.Add("Marco");
            cognomi.Add("Dello Iacono");
            ruoli.Add("Libero");
            numeri.Add(23);

            nomi.Add("Matteo");
            cognomi.Add("Ferrante");
            ruoli.Add("Opposto");
            numeri.Add(28);

            nomi.Add("Luca");
            cognomi.Add("Pozzi");
            ruoli.Add("Centrale");
            numeri.Add(31);

            nomi.Add("Cristiano");
            cognomi.Add("Binetti");
            ruoli.Add("Centrale");
            numeri.Add(89);

            #endregion

            index = 0;
            foreach (var item in nomi)
            {
                PersonaViewModel myPersona = new PersonaViewModel();
                myPersona.nome = item;
                myPersona.cognome = cognomi[index];
                myPersona.ruolo = ruoli[index];
                myPersona.numero = numeri[index];
                if (index == 0)
                {
                    myPersona.isCapitano = true;
                }
                else
                {
                    myPersona.isCapitano = false;
                }

                listaGiocatori.Add(myPersona);
                index++;
            }

            ViewBag.ListaStaff = listaStaff;

            return PartialView(listaGiocatori);
        }

        public ActionResult Calendario(string campionato)
        {
            List<CalendarioViewModel> listaPartite = new List<CalendarioViewModel>();

            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://fipavonline.it/main/gare_girone/41131").Result;

                string html = response.Content.ReadAsStringAsync().Result;
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                string nomeSquadra = "Veramente sportiva A.s.d.";

                List<HtmlNode> partite = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'gara-big-wrap')]").ToList();

                foreach (var item in partite)
                {
                    HtmlNode info = item.SelectSingleNode(".//div[@class='info-gara']");
                    HtmlNode dati = item.SelectSingleNode(".//div[@class='dati-gara']");

                    List<HtmlNode> temp = dati.SelectNodes(".//span[@class='sq-nLong']").ToList();
                    string squadraCasa = temp[0].InnerText.Trim();
                    string squadraOspite = temp[1].InnerText.Trim();

                    if (nomeSquadra.ToLower() == squadraCasa.ToLower() || nomeSquadra.ToLower() == squadraOspite.ToLower())
                    {
                        CalendarioViewModel myPartita = new CalendarioViewModel();
                        myPartita.numeroGara = info.SelectSingleNode("./div[@class='info-gara-giornata']").InnerText.Trim();
                        myPartita.dataOra = info.SelectSingleNode("./div[@class='info-gara-data']").InnerText.Trim().ToUpper();

                        List<string> dataTemp = myPartita.dataOra.Split(' ')[1].Split('/').ToList();
                        myPartita.dataGara = new DateTime(Convert.ToInt32(dataTemp[2]), Convert.ToInt32(dataTemp[1]), Convert.ToInt32(dataTemp[0]));

                        HtmlNode tempInfo = info.SelectSingleNode(".//div[@class='info-gara-campo']");

                        myPartita.indirizzo = tempInfo.SelectSingleNode("./div[@class='info-gara-campo-desc']").InnerText.Trim().ToUpper();
                        myPartita.luogo = tempInfo.SelectSingleNode("./div[@class='info-gara-campo-loc']").InnerText.Trim().ToUpper();

                        List<HtmlNode> tempImg = dati.Descendants("img").Where(node => node.GetAttributeValue("class", "").Contains("sq-logo")).Take(2).ToList();

                        myPartita.squadraCasa = squadraCasa.ToUpper();
                        myPartita.immagineCasa = "https://fipavonline.it" + tempImg[0].Attributes["src"].Value;

                        myPartita.squadraOspite = squadraOspite.ToUpper();
                        myPartita.immagineOspite = "https://fipavonline.it" + tempImg[1].Attributes["src"].Value;

                        List<HtmlNode> temp2 = dati.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("s-score")).Take(1).ToList();
                        myPartita.risultato = temp2[0].InnerText.Trim();

                        List<HtmlNode> temp3 = dati.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("text-parziali")).Take(1).ToList();
                        myPartita.parziali = temp3[0].InnerText.Trim().Replace(" ", " - ");

                        listaPartite.Add(myPartita);
                    }
                }
            }

            return PartialView(listaPartite);
        }

        public ActionResult Classifica(string campionato)
        {
            List<ClassificaViewModel> listaSquadre = new List<ClassificaViewModel>();

            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://fipavonline.it/main/classifica/41131/0").Result;

                string html = response.Content.ReadAsStringAsync().Result;
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                List<HtmlNode> squadre = htmlDoc.DocumentNode.SelectNodes("//tr[contains(@class, 'cliccable')]").ToList();

                foreach (var item in squadre)
                {
                    List<HtmlNode> info = item.ChildNodes.ToList();

                    ClassificaViewModel mySquadra = new ClassificaViewModel();

                    List<HtmlNode> temp = info[3].Descendants("img").Take(1).ToList();
                    mySquadra.immagineSquadra = "https://fipavonline.it" + temp[0].Attributes["src"].Value;

                    mySquadra.posizione = Convert.ToInt32(info[1].InnerText.Trim());
                    mySquadra.squadra = info[3].InnerText.Trim().ToUpper();
                    mySquadra.punti = Convert.ToInt32(info[5].InnerText.Trim());
                    mySquadra.giornate = Convert.ToInt32(info[7].InnerText.Trim());
                    mySquadra.giornateVinte = Convert.ToInt32(info[9].InnerText.Trim());
                    mySquadra.giornatePerse = Convert.ToInt32(info[11].InnerText.Trim());
                    mySquadra.setVinti = Convert.ToInt32(info[13].InnerText.Trim());
                    mySquadra.setPersi = Convert.ToInt32(info[15].InnerText.Trim());
                    mySquadra.puntiFatti = Convert.ToInt32(info[19].InnerText.Trim());
                    mySquadra.puntiPersi = Convert.ToInt32(info[21].InnerText.Trim());

                    listaSquadre.Add(mySquadra);
                }
            }

            return PartialView(listaSquadre);
        }
    }
}