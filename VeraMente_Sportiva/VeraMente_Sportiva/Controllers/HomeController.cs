using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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
                #region ULTIMA E PROSSIMA PARTITA

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

                DateTime oggi = DataUtility.CurrentDateTime();
                CalendarioViewModel ultimaPartita = listaPartite.Where(x => x.dataGara < oggi).OrderByDescending(x => x.dataGara).FirstOrDefault();
                CalendarioViewModel prossimaPartita = listaPartite.Where(x => x.dataGara >= oggi).OrderBy(x => x.dataGara).FirstOrDefault();

                ViewBag.UltimaPartita = ultimaPartita;
                ViewBag.ProssimaPartita = prossimaPartita;

                #endregion

                #region CLASSIFICA

                List<ClassificaViewModel> listaSquadreClassifica = new List<ClassificaViewModel>();

                response = client.GetAsync("https://fipavonline.it/main/classifica/41131/0").Result;

                html = response.Content.ReadAsStringAsync().Result;
                htmlDoc = new HtmlDocument();
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

                    listaSquadreClassifica.Add(mySquadra);
                }

                ViewBag.ListaSquadreClassifica = listaSquadreClassifica;

                #endregion

                #region NEWS

                CardNews myMainCard = new CardNews();
                myMainCard.titolo = "Benvenuto sul nuovo sito di VeraMente Sportiva!";
                myMainCard.contenuto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec molestie, purus quis ultrices scelerisque, tellus dolor ultricies dui, " +
                    "non rhoncus nisl nibh vel massa.Nam ac convallis lacus, nec elementum justo. Curabitur eu fringilla massa. Sed in lacinia arcu. Nullam " +
                    "eu purus ut leo pellentesque maximus at vel lectus. Sed in magna purus. Vestibulum nec consequat dolor, non sagittis justo. Integer quam " +
                    "massa, aliquam egestas felis non, congue convallis eros. Cras efficitur, magna et varius ultricies, orci sapien consectetur neque, ut " +
                    "convallis dui ligula ut ligula.Suspendisse consequat in velit fringilla consequat.Pellentesque habitant morbi tristique senectus et " +
                    "netus et malesuada fames ac turpis egestas.Aliquam sit amet nisl turpis.Morbi est justo, dapibus et purus ac, semper placerat sem. " +
                    "In at erat in leo finibus condimentum vel vitae turpis";
                myMainCard.immagine = "test.jpg";

                List<string> tags = new List<string>();
                tags.Add("Stagione 22/23");
                tags.Add("Novità");
                tags.Add("Sito");
                myMainCard.tags = tags;
                myMainCard.dataPubblicazione = new DateTime(2022, 11, 15);

                ViewBag.MainNews = myMainCard;

                List<CardNews> listaNews = new List<CardNews>();

                CardNews myCard = new CardNews();
                myCard.titolo = "Pronti per la nuova stagione!";
                myCard.contenuto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec molestie, purus quis ultrices scelerisque, tellus dolor ultricies dui, " +
                    "non rhoncus nisl nibh vel massa.Nam ac convallis lacus, nec elementum justo. Curabitur eu fringilla massa. Sed in lacinia arcu. Nullam " +
                    "eu purus ut leo pellentesque maximus at vel lectus. Sed in magna purus. Vestibulum nec consequat dolor, non sagittis justo. Integer quam " +
                    "massa, aliquam egestas felis non, congue convallis eros. Cras efficitur, magna et varius ultricies, orci sapien consectetur neque, ut " +
                    "convallis dui ligula ut ligula.Suspendisse consequat in velit fringilla consequat.Pellentesque habitant morbi tristique senectus et " +
                    "netus et malesuada fames ac turpis egestas.Aliquam sit amet nisl turpis.Morbi est justo, dapibus et purus ac, semper placerat sem. " +
                    "In at erat in leo finibus condimentum vel vitae turpis";
                myCard.immagine = "news3.jpg";

                tags = new List<string>();
                tags.Add("Stagione 22/23");
                tags.Add("1DM");
                tags.Add("Novità");
                myCard.tags = tags;
                myCard.dataPubblicazione = new DateTime(2022, 11, 10);

                listaNews.Add(myCard);

                myCard = new CardNews();
                myCard.titolo = "VeraMente Sportiva ai nastri di partenza della PGS Libera Femminile";
                myCard.contenuto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec molestie, purus quis ultrices scelerisque, tellus dolor ultricies dui, " +
                    "non rhoncus nisl nibh vel massa.Nam ac convallis lacus, nec elementum justo. Curabitur eu fringilla massa. Sed in lacinia arcu. Nullam " +
                    "eu purus ut leo pellentesque maximus at vel lectus. Sed in magna purus. Vestibulum nec consequat dolor, non sagittis justo. Integer quam " +
                    "massa, aliquam egestas felis non, congue convallis eros. Cras efficitur, magna et varius ultricies, orci sapien consectetur neque, ut " +
                    "convallis dui ligula ut ligula.Suspendisse consequat in velit fringilla consequat.Pellentesque habitant morbi tristique senectus et " +
                    "netus et malesuada fames ac turpis egestas.Aliquam sit amet nisl turpis.Morbi est justo, dapibus et purus ac, semper placerat sem. " +
                    "In at erat in leo finibus condimentum vel vitae turpis";
                myCard.immagine = "news1.jpg";

                tags = new List<string>();
                tags.Add("Stagione 22/23");
                tags.Add("PGS");
                tags.Add("Femminile");
                
                myCard.tags = tags;
                myCard.dataPubblicazione = new DateTime(2022, 09, 15);

                listaNews.Add(myCard);

                myCard = new CardNews();
                myCard.titolo = "Angelo Battaglia nuovo allenatore della 1DM";
                myCard.contenuto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec molestie, purus quis ultrices scelerisque, tellus dolor ultricies dui, " +
                    "non rhoncus nisl nibh vel massa.Nam ac convallis lacus, nec elementum justo. Curabitur eu fringilla massa. Sed in lacinia arcu. Nullam " +
                    "eu purus ut leo pellentesque maximus at vel lectus. Sed in magna purus. Vestibulum nec consequat dolor, non sagittis justo. Integer quam " +
                    "massa, aliquam egestas felis non, congue convallis eros. Cras efficitur, magna et varius ultricies, orci sapien consectetur neque, ut " +
                    "convallis dui ligula ut ligula.Suspendisse consequat in velit fringilla consequat.Pellentesque habitant morbi tristique senectus et " +
                    "netus et malesuada fames ac turpis egestas.Aliquam sit amet nisl turpis.Morbi est justo, dapibus et purus ac, semper placerat sem. " +
                    "In at erat in leo finibus condimentum vel vitae turpis";
                myCard.immagine = "news2.jpg";

                tags = new List<string>();
                tags.Add("1DM");
                tags.Add("Squadra");
                tags.Add("Staff");
                myCard.tags = tags;
                myCard.dataPubblicazione = new DateTime(2022, 09, 01);

                listaNews.Add(myCard);

                ViewBag.ListaNews = listaNews;

                #endregion
            }

            return View();
        }

        public ActionResult Contatti()
        {
            return View();
        }
    }
}