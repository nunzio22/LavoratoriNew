using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavoratori
{
    [Serializable]
    public class Lavoratore : IComparable
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNasciata { get; set; }
        public int StipendioAnn { get; set; }
        public int Età
        {
            get
            {
                int anno;
                var annoAttuale = DateTime.Now.Year;
                var annoDiNascita = DataDiNasciata.Year;
                anno = annoAttuale - annoDiNascita;
                return anno;
            }
        }
        //lettura dettagli lavoratore 
        //lettura dettagli stipendio
        /// <summary>
        /// creo una stringa con i dettagli stipendio
        /// </summary>
        /// <returns>ritorno la stringa con i dettagli stipendio</returns>
        public virtual string GetDettaglioStipendio()
        {
            return Nome + Environment.NewLine + " :";
        }
        public Lavoratore()
        {

        }


        public virtual int Tasse() { return 0; }
        /// <summary>
        /// è un ovveride del metodo to string 
        /// </summary>
        /// <returns>ritorna la stringa con tutti i dettagli del lavoratore</returns>
        public override string ToString()
        {
            return "Nome : " + Nome + Environment.NewLine +
            "Cognome : " + Cognome + Environment.NewLine +
            "Età : " + Età + Environment.NewLine +
            "Data di Nascita : " + DataDiNasciata.ToString("") + Environment.NewLine;
        }

        public virtual int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            int ris;
            Lavoratore newLav = obj as Lavoratore;
            if (newLav != null)
            {
                ris = StipendioAnn.CompareTo(newLav.StipendioAnn);
            }
            else
            {
                throw new ArgumentException("L'oggetto da comparare non è una persona");
            }
            return ris;
        }
    }
}

