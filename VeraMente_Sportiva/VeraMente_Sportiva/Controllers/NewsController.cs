using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeraMente_Sportiva.Models;

namespace VeraMente_Sportiva.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
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

            #region LISTA NEWS

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

            myCard = new CardNews();
            myCard.titolo = "Pronti per la nuova stagione!";
            myCard.contenuto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec molestie, purus quis ultrices scelerisque, tellus dolor ultricies dui, " +
                "non rhoncus nisl nibh vel massa.Nam ac convallis lacus, nec elementum justo. Curabitur eu fringilla massa. Sed in lacinia arcu. Nullam " +
                "eu purus ut leo pellentesque maximus at vel lectus. Sed in magna purus. Vestibulum nec consequat dolor, non sagittis justo. Integer quam " +
                "massa, aliquam egestas felis non, congue convallis eros. Cras efficitur, magna et varius ultricies, orci sapien consectetur neque, ut " +
                "convallis dui ligula ut ligula.Suspendisse consequat in velit fringilla consequat.Pellentesque habitant morbi tristique senectus et " +
                "netus et malesuada fames ac turpis egestas.Aliquam sit amet nisl turpis.Morbi est justo, dapibus et purus ac, semper placerat sem. " +
                "In at erat in leo finibus condimentum vel vitae turpis";
            myCard.immagine = "news2.jpg";

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
            myCard.immagine = "news3.jpg";

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
            myCard.immagine = "news1.jpg";

            tags = new List<string>();
            tags.Add("1DM");
            tags.Add("Squadra");
            tags.Add("Staff");
            myCard.tags = tags;
            myCard.dataPubblicazione = new DateTime(2022, 09, 01);

            listaNews.Add(myCard);

            myCard = new CardNews();
            myCard.titolo = "Pronti per la nuova stagione!";
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
            myCard.immagine = "news2.jpg";

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
            myCard.immagine = "news3.jpg";

            tags = new List<string>();
            tags.Add("1DM");
            tags.Add("Squadra");
            tags.Add("Staff");
            myCard.tags = tags;
            myCard.dataPubblicazione = new DateTime(2022, 09, 01);

            listaNews.Add(myCard);

            #endregion

            return View(listaNews);
        }

        public ActionResult Notizia(int newsID = 0)
        {
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

            return View(myMainCard);
        }
    }
}