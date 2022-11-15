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
    public class TeamsController : Controller
    {
        public ActionResult Index(string championship)
        {
            ViewBag.Championship = championship;
            return View();
        }

        public ActionResult Team(string championship)
        {
            return PartialView();
        }

        public ActionResult Schedule(string championship)
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
                }
            }

            return PartialView(listaPartite);
        }

        public ActionResult Standing(string championship)
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
                    mySquadra.posizione = Convert.ToInt32(info[1].InnerText.Trim());
                    mySquadra.nome = info[3].InnerText.Trim();
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