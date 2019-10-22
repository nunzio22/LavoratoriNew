using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavoratori
{
    [Serializable]
    public class LavoratoreAutonomo : Lavoratore
    {


        public int StipendioLord
        {
            get
            {
                return StipendioAnn / 12;
            }
        }
        public int StipendioNet
        {
            get
            {
                int tass = Tasse();
                int ris = StipendioLord / 100;
                ris *= tass;
                return StipendioLord - ris;
            }
        }
        public int DipendentiAssunti { get; set; }
        /// <summary>
        /// ovveride del metodo dettagli stipendio del oggeto lavoratore autonomo
        /// </summary>
        /// <returns>ritorna una stringa con i dettagli stipendio del oggeto</returns>
        public override string GetDettaglioStipendio()
        {
            return (base.GetDettaglioStipendio() +
                StipendioNet.ToString("C") + Environment.NewLine).Replace('€', '$');
        }
        /// <summary>
        /// ovveride del metodo to string del oggeto lavoratore autonomo
        /// </summary>
        /// <returns>ritorna una stringa con i dettagli lavoratore autonomo</returns>
        public override string ToString()
        {
            string c = base.ToString() +
                "Stipendio Mensile percepito : " + StipendioNet.ToString("C") + Environment.NewLine +
                "Dipendenti assunti : " + DipendentiAssunti + Environment.NewLine;
            c = c.Replace('€', '$');
            return c;
        }
        /// <summary>
        /// calcolo tasse in base allo stipendio
        /// </summary>
        /// <returns>percentuale delle tasse</returns>
        public override int Tasse()
        {
            if (StipendioAnn < 50000)
            {
                return 15;
            }
            return 30;
        }
    }
}
