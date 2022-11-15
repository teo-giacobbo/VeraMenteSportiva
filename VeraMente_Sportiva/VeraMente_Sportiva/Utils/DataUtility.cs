using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeraMente_Sportiva.Utils
{
    public class DataUtility
    {
        /// <summary>
        /// Metodo che restituisce la data e l'ora correnti (fuso orario West Europe).
        /// </summary>
        public static DateTime CurrentDateTime()
        {
            DateTime currentDateTime = DateTime.Now;
            TimeZoneInfo myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);

            return currentDateTime;
        }

        /// <summary>
        /// Metodo che restituisce il primo giorno del mese della data specificata.
        /// </summary>
        /// <param name="myDateTime">Data di partenza da cui vengono presi mese e anno</param>
        public static DateTime PrimoGiornoDelMese(DateTime myDateTime)
        {
            return new DateTime(myDateTime.Year, myDateTime.Month, 1);
        }

        /// <summary>
        /// Metodo che restituisce l'ultimo giorno del mese della data specificata.
        /// </summary>
        /// <param name="myDateTime">Data di partenza da cui vengono presi mese e anno</param>
        public static DateTime UltimoGiornoDelMese(DateTime myDateTime)
        {
            return PrimoGiornoDelMese(myDateTime).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Metodo che restituisce il primo giorno della settimana della data specificata.
        /// </summary>
        /// <param name="myDateTime">Data da cui viene presa la settimana di riferimento</param>
        public static DateTime PrimoGiornoDellaSettimana(DateTime myDateTime)
        {
            int diff = (7 + (myDateTime.DayOfWeek - DayOfWeek.Monday)) % 7;
            return myDateTime.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Metodo che converte in DateTime la stringa passata come argomento.
        /// </summary>
        /// <param name="data">Data in formato stringa (formattazione della stringa dd/MM/yyyy)</param>
        public static DateTime? ConvertiStringaInData(string data)
        {
            DateTime? myDateTime = null;
            if (data != "")
            {
                try
                {
                    string[] tempArray = data.Split(new string[] { "/" }, StringSplitOptions.None);

                    if (tempArray.Length > 2)
                    {
                        myDateTime = new DateTime(Convert.ToInt32(tempArray[0]), Convert.ToInt32(tempArray[1]), Convert.ToInt32(tempArray[2]));
                    }
                }
                catch (Exception e)
                {
                    myDateTime = null;
                }
            }
            return myDateTime;
        }

        /// <summary>
        /// Metodo che restituisce una stringa formattata per essere utilizzata in una SP (Stored Procedure) della stringa passata come argomento
        /// </summary>
        /// <param name="data">Data in formato stringa (formattazione della stringa dd/MM/yyyy)</param>
        public static string FormattaStringaPerDataSP(string data)
        {
            string result = "";
            DateTime? myDateTime = null;

            try
            {
                string[] tempArray = data.Split('/');

                if (tempArray.Length > 2)
                {
                    myDateTime = new DateTime(Convert.ToInt32(tempArray[2]), Convert.ToInt32(tempArray[1]), Convert.ToInt32(tempArray[0]));
                }

                if (myDateTime != null)
                {
                    result = myDateTime.Value.ToString("yyyyMMdd");
                }
            }
            catch (Exception e)
            {
                result = "";
            }

            return result;
        }

        /// <summary>
        /// Metodo che restituisce il primo lunedì dalla data indicata
        /// </summary>
        /// <param name="myDateTime">Data di riferimento</param>
        public static DateTime ProssimoLunedi(DateTime myDateTime)
        {
            int diff = ((int)DayOfWeek.Monday - (int)myDateTime.DayOfWeek + 7) % 7;
            return myDateTime.AddDays(diff);
        }
    }
}