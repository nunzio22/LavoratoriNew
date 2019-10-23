using Lavoratori.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lavoratori
{
    class Inserimento
    {
        /// <summary>
        /// inserimento di nuovi lavoratori 
        /// </summary>
        /// <param name="lav">lista dove vengono inseriti i lavoratori</param>
        public static void insert(List<LavoratoreAutonomo> lavA,List<LavoratoreDipendete> lavD,List<Lavoratore> lavT)
        {
            string tem;
            bool fine;
            Lavoratore temporaneo=new Lavoratore();

            do
            {
                temporaneo=InsertL();
                if (Controllo.ControlloLavoratore(temporaneo.Nome, temporaneo.Cognome, temporaneo.DataDiNasciata,lavT) )
                {
                    Console.WriteLine("Che tipo di Lavoratore si vuole inserire ?"
                    + Environment.NewLine
                    + "1 Lavoratore dipendente " + Environment.NewLine
                    + "2 Lavoratore autonomo");
                    //si salva il valore in una variabile temporalle
                    tem = Console.ReadLine();
                    //crea l'oggeto del tipo inserito e gli da i parametri inseriti in precedenza
                    tem = tem.ToUpper();

                    if (tem == "1" || tem == "LAVORATORE DIPENDENTE")
                    {
                        Lavoratori.Utility.DBUtility.InsertPersona(temporaneo);
                        lavD.Add((LavoratoreDipendete)temporaneo);
                        lavT.Add(temporaneo);
                        //solo per aggiungere lo spazio alla fine della crazione
                        Console.WriteLine(string.Empty);
                    }
                    else if (tem == "2" || tem == "LAVORATORE AUTONOMO")
                    {
                        Lavoratori.Utility.DBUtility.InsertPersona(temporaneo);
                        lavA.Add((LavoratoreAutonomo)temporaneo);
                        lavT.Add((Lavoratore)temporaneo);
                        Console.WriteLine(string.Empty);
                    }


                }
                else
                {
                    //se l'utete è si manda il messaggio nel quale si specifaca che il lavoratore non può essere inserito
                    Console.WriteLine("Utente già allinterno del 'DB' imposibile rinserirlo");
                }

                fine = Controllo.AltreOprezioni("inserire altri utenti");
                //se si vuole lavorare su file
                //if (!fine)
                //{
                //    FileUtility.InsertList<LavoratoreAutonomo>(lavA, "listaA.xml");
                //    FileUtility.InsertList<LavoratoreDipendete>(lavA, "listaD.xml");
                //}
            } while (fine);
        }

        private static Lavoratore InsertL()
        {
            //creazione utnete si chiede di che tipologia deve essere l'utente per poterlo creare di quel tipo
            Lavoratore temporaneo = new Lavoratore();
            //si inseriscono i dati personali su varibile provissorie
            Console.WriteLine("Nome lavoratore : ");
            string nome = Console.ReadLine();
            Console.WriteLine("Cognome lavoratore : ");
            String cognome = Console.ReadLine();
            int stipendioAnn = insertN("lo stipendio annuale");
            Console.WriteLine("Inserisci la data di nascita : ");
            string datastring = Console.ReadLine();
            DateTime data = DateTime.Parse(datastring);
            //dentro if lacia un metodo che ritorna un buleano di tipo false se allinterno del utente essiste già il lavoratore
            temporaneo.Nome = nome;
            temporaneo.Cognome = cognome;
            temporaneo.StipendioAnn = stipendioAnn;
            temporaneo.DataDiNasciata = data;
            return temporaneo;
        }

        internal static void Mod(List<LavoratoreAutonomo> listLA, List<LavoratoreDipendete> listLD, List<Lavoratore> listL)
        {
            Lavoratore up = InsertL();
            string tem;
            Console.WriteLine("Che tipo di Lavoratore si vuole inserire ?"
                    + Environment.NewLine
                    + "1 Lavoratore dipendente " + Environment.NewLine
                    + "2 Lavoratore autonomo");
            //si salva il valore in una variabile temporalle
            tem = Console.ReadLine();
            //crea l'oggeto del tipo inserito e gli da i parametri inseriti in precedenza
            tem = tem.ToUpper();
            List.UpdateList(listL, up);
            if (tem == "1" || tem == "LAVORATORE DIPENDENTE")
            {
                Lavoratori.Utility.DBUtility.UpdatePersona(up, 1);
                List.UpdateList(listLD,up);
            }
            else if (tem == "2" || tem == "LAVORATORE AUTONOMO")
            {
                Lavoratori.Utility.DBUtility.UpdatePersona(up, 2);
                List.UpdateList(listLA, up);
            }
            else
            {
                Console.WriteLine ("Il varore inserito non va bene");
            }

            
        }



        /// <summary>
        /// l'inserimenento del numero dentro una varibile da stringa gestendo le varie eccezioni
        /// </summary>
        /// <param name="pr">stringa che distingue la richiesta che si vuole fare</param>
        /// <exception cref="NumeroException">se il non dicita un numero lancia l'eccezione</exception>
        /// <returns>ritorna un intero scritto dal utente</returns>
        ///    
        public static int insertN(string pr)
        {
            //creazioni delle variabili necessarie per l'inserimento
            string temp;
            int num1 = 0;
            bool fine = true;
            do
            {
                Console.WriteLine("Inserisci {0} e premi invio", pr);
                temp = Console.ReadLine();
                try
                {
                    num1 = Eccezione(temp);
                    fine = false;
                }
                catch (NumeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (fine);
            return num1;
        }
        /// <summary>
        /// distingue le varie eccezioni del inserimento di una stringa al interno di un inti
        /// </summary>
        /// <param name="temp">la stringa contente il valore scritto dal utente</param>
        /// <returns>intero con il contenuto della stringra o ritorna il tipo di eccezione</returns>

        private static int Eccezione(string temp)
        {
            int n;
            try
            {
                n = Int32.Parse(temp);
                return n;
            }
            catch (ArgumentNullException)
            {
                throw new NumeroException("Il varore è null");
            }
            catch (FormatException)
            {
                throw new NumeroException("Il varore inserito non è un intero");
            }
            catch (OverflowException)
            {
                throw new NumeroException("Il varore inserito è troppo grande");
            }
            catch (Exception)
            {
                throw new NumeroException("Il varore inserito non va bene");
            }

        }

        
    }
}