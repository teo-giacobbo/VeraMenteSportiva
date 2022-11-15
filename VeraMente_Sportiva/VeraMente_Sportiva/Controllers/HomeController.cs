using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using VeraMente_Sportiva.Models;
using VeraMente_Sportiva.Utils;

namespace VeraMente_Sportiva.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
                        myPartita.squadraCasa = squadraCasa.ToUpper();
                        myPartita.squadraOspite = squadraOspite.ToUpper();

                        List<HtmlNode> temp2 = dati.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("s-score")).Take(1).ToList();
                        myPartita.risultato = temp2[0].InnerText.Trim();

                        List<HtmlNode> temp3 = dati.Descendants("span").Where(node => node.GetAttributeValue("class", "").Contains("text-parziali")).Take(1).ToList();
                        myPartita.parziali = temp3[0].InnerText.Trim().Replace(" ", " - ");

                        listaPartite.Add(myPartita);
                    }
                }
            }

            DateTime oggi = DataUtility.CurrentDateTime();
            CalendarioViewModel ultimaPartita = listaPartite.Where(x => x.dataGara < oggi).OrderByDescending(x => x.dataGara).FirstOrDefault();
            CalendarioViewModel prossimaPartita = listaPartite.Where(x => x.dataGara >= oggi).OrderBy(x => x.dataGara).FirstOrDefault();

            ViewBag.UltimaPartita = ultimaPartita;
            ViewBag.ProssimaPartita = prossimaPartita;

            return View();
        }

        public ActionResult Contatti()
        {
            return View();
        }
    }
}