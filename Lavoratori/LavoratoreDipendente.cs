using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavoratori

{
    [Serializable]
    public class LavoratoreDipendete : Lavoratore
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
        public DateTime DataAssunzione { get; set; }

        /// <summary>
        /// ovveride del metodo to string del oggeto lavoratore dipendete
        /// </summary>
        /// <returns>ritorna una stringa con i dettagli lavoratore dipendente</returns>
        public override string ToString()
        {
            return (base.ToString() +
                "Stipendio Mensile percepito : " + StipendioNet.ToString("C") + Environment.NewLine +
                "Data di assunzione : " + DataAssunzione.ToString("D") + Environment.NewLine).Replace('€', '$');
        }
        /// <summary>
        /// ovveride del metodo dettagli stipendio del oggeto lavoratore dipendente
        /// </summary>
        /// <returns>ritorna una stringa con i dettagli stipendio del oggeto</returns>
        public override string GetDettaglioStipendio()
        {
            return (base.GetDettaglioStipendio() +
                StipendioNet.ToString("C") + Environment.NewLine).Replace('€', '$');
        }
        /// <summary>
        /// calcolo tasse in base allo stipendio
        /// </summary>
        /// <returns>percentuale delle tasse</returns>
        public override int Tasse()
        {
            if (StipendioAnn < 6000)
                return 0;
            else if (StipendioAnn < 15000)
                return 15;
            else if (StipendioAnn < 25000)
                return 30;
            else if (StipendioAnn < 35000)
                return 40;
            else return 50;
        }
    }
}

