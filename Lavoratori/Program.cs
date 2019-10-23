using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lavoratori.Utility;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data;

namespace Lavoratori
{
    class Program
    {
        static void Main(string[] args)
        {
            //scomentare per funzionare con i file
            //List<LavoratoreAutonomo> listLA = FileUtility.Lav<LavoratoreAutonomo>("listaA.xml");
            //List<LavoratoreDipendete> listLD = FileUtility.Lav<LavoratoreDipendete>("listaD.xml");
            //List<Lavoratore> listL = new List<Lavoratore>();
            //listL.AddRange(listLA);
            //listL.AddRange(listLD);
            //Console.ReadLine();
            List<LavoratoreDipendete> listLD = new List<LavoratoreDipendete>();
            List<LavoratoreAutonomo> listLA = new List<LavoratoreAutonomo>();
            DataSet ds = DBUtility.GetLavoratore();
            List.InsertList(ds,listLD,listLA);      
            Console.ReadLine();
            List<Lavoratore> listL = new List<Lavoratore>();
            listL.AddRange(listLA);
            listL.AddRange(listLD);

            int n;
            bool fine;
            // creazione stringa richiesta
            string ric;
            do
            {
                // selezione ciò che si vuole fare
                Console.WriteLine(
                    "1 Stipendio mensile del lavoratore : " + Environment.NewLine
                    + "2 Lista dei lavoratori inseriti" + Environment.NewLine
                    + "3 Ordinamento dei Lavoratori per stipendio percepito" + Environment.NewLine
                    + "4 Ordinamento dei lavoratori per anzianita" + Environment.NewLine
                    + "5 Inserimernto nuovo lavoratore : " + Environment.NewLine
                    +"6 Modifica elemento Lavoratore "+ Environment.NewLine
                    + "7 Elimina elemento Lavoratore " + Environment.NewLine);
                ric = Console.ReadLine();
                // serie di if di controllo su ciò che si è scelto
                if (ric == "1")
                {
                    //altra richiesta di 
                    Console.WriteLine("1 Stipendio tramite nome(Nome)" + Environment.NewLine
                                       + "2 Un numero di persone del quale si vuole vedere lo stipendio(Numero)" + Environment.NewLine
                                       + "3 Stipendio di tutti i lavoratori (Tutti) ");
                    //altro contorllo di richiesta
                    ric = Console.ReadLine().ToUpper();
                    if (ric == "1" || ric == "NOME")
                    {
                        Console.WriteLine("Inserire il nome del quale si vuole vedere lo stipendio : ");
                        ric = Console.ReadLine().ToUpper();
                        //metodo che stampa il nome e stipendio della persona cercata dal utente
                        Ricerca.RicercaNome(ric, listL);
                    }
                    else if (ric == "2" || ric == "NUMERO")
                    {
                        Console.WriteLine("Inserire il numero delle persone sulle quali si vuole controllare lo stipendio ");
                        n = Inserimento.insertN("Il numero");
                        Ricerca.RicercaNum(n, listL);

                    }
                    else if (ric == "3" || ric == "TUTTI")
                    {
                        Ricerca.RicercaNum(listL.Count, listL);
                    }
                }
                else if (ric == "2")
                {
                    Ricerca.Lettura(listL);
                }
                else if (ric == "3")
                {
                    Ricerca.OrdinamentoSti(listL);
                }
                else if (ric == "4")
                {
                    Ricerca.OrdinamentoAnn(listLD);
                }
                else if (ric == "5")
                {
                    Inserimento.insert(listLA, listLD, listL);
                }
                else if (ric=="6")
                {
                    Inserimento.Mod(listLA, listLD, listL);
                    
                }
                else if (ric=="7")
                {
                    Inserimento.Elimina(listLA, listLD, listL);
                }
                fine = Controllo.AltreOprezioni(" effetuare altre operzioni");
            } while (fine);

        }
    }
       
        

 }


