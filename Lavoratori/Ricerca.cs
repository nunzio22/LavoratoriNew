using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavoratori
{
    class Ricerca
    {
        //semplice lettura del dettaglio lavoratore
        /// <summary>
        /// lettura dei dettagli del lavoratori
        /// </summary>
        /// <param name="lav">lista lavoratori</param>
        public static void Lettura(List<Lavoratore> lav)
        {
            for (int i = 0; i < lav.Count; i++)
            {
                if (!(lav[i] == null))
                {
                    Console.WriteLine(lav[i]);
                }
            }
        }
        /// <summary>
        /// stampa in ordine ed ordina i lavoratori di stipendio i dettagli stipendio
        /// </summary>
        /// <param name="lav">lista lavoratori</param>
        public static void OrdinamentoSti(List<Lavoratore> lav)
        {
            //Array.Sort(lav);
            Ricerca.Lettura(lav);
        }
        /// <summary>
        /// mi stampa i dettagli sipendio ordinati per data di assunzione
        /// </summary>
        /// <param name="lav">lista lavoratori</param>
        public static void OrdinamentoAnn(List<LavoratoreDipendete> lav)
        {
            //lunghezza del arrey di oggetti lavoratore dipendenti
            //creazione arrey di tipo data popolato con la data di assunzione degli oggetti persona del arrey ord
            DateTime[] v = new DateTime[lav.Count];
            for (int y = 0; y < v.Length; y++)
            {
                v[y] = lav[y].DataAssunzione;
            }
            // distint degli elementi arrey
            v = v.Distinct().ToArray();
            //ordinamteo data assunzione
            Array.Sort(v);
            //stampa tramite ord e v i lavoratori in ordine da data di assunzione
            for (int i = 0; i < v.Length; i++)
            {
                for (int y = 0; y < lav.Count; y++)
                {
                    if (!(lav[y] == null))
                    {
                        //stampo in ordiene di ord i vari dettagli stipendio
                        if (v[i] == lav[y].DataAssunzione)
                            Console.WriteLine(lav[y]);
                    }
                }
            }
        }
        //cerca il nome dentro il campo nome dei vari oggetti del arrey e lo stapa a scermo
        /// <summary>
        /// cerca il nome dentro il campo nome dei vari oggetti del arrey e lo stapa a scermo
        /// </summary>
        /// <param name="ric">nome cercato dal utente</param>
        /// <param name="lav">lista lacoratore</param>
        internal static void RicercaNome(string ric,List<Lavoratore> lav)
        {
            foreach (var p in lav)
            {
                if (p.Nome.ToUpper()==ric)
                {
                    Console.WriteLine(p.GetDettaglioStipendio());
                }
            }
        }

        /// <summary>
        /// stampa i dettagli lavoratore in base al numero selezionato dal utente
        /// </summary>
        /// <param name="n">numero selezionato dal utente</param>
        /// <param name="lav">lista lavoratore</param>
        //stampa un numero di dettegli lavoratori in base a quanti ne chiede lutente se sono piu dei lavoratori esistenti gli stampa tutti
        internal static void RicercaNum(int n, List<Lavoratore> lav)
        {
            int i=0;
            foreach (var p in lav)
            {
                
                    Console.WriteLine(p.GetDettaglioStipendio());
                if (i+1==n)
                {
                    break;
                }
            
            }
        }


    }
}
