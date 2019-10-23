using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavoratori
{
    class Controllo
    {
        
        /// <summary>
        /// controllo se l'utente è già prensente nella nostra lista Lavoratore Dipendete
        /// </summary>
        /// <param name="nom">nome del utente che si vuole inserire</param>
        /// <param name="cognome">cognome del utente che si vuole inserire</param>
        /// <param name="stipendio">stipendio del utente che si vuole inserire</param>
        /// <param name="lav">lista di lavoratori</param>
        /// <returns>ritorna un false se l'utente è già presente e true se non è presente </returns>
        public static bool ControlloLavoratore(string nom, string cognome, DateTime data, List<Lavoratore> lav)
        {
            bool ris = true;
            
            foreach (var k in lav)
            {
                if (k != null && k.Nome == nom && k.Cognome == cognome && k.DataDiNasciata == data)
                {
                    ris = false;
                    break;
                }
            }
            return ris;
        }

        
        /// <summary>
        /// controllo se l'utente vuole effetuare altre operazioni
        /// </summary>
        /// <returns>ritorna true se l'utente vuole inserire altre operazioni e false se non ne vuole inserire</returns>
        public static bool AltreOprezioni(string a)
        {
            bool fine = true;
            string tem;
            //si chiede al utente se desidera fare altre operazioni 
            Console.WriteLine("Vuoi {0}", a);
            tem = Console.ReadLine().ToUpper();
            if ((tem != "SI"))
                fine = false;
            return fine;
        }
    }
}