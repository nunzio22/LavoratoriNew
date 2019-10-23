using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavoratori
{
    class List
    {
        public static void InsertList(DataSet ds, List<LavoratoreDipendete> lavD, List<LavoratoreAutonomo> lavA)
        {
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("{0} , {1} , {2} , {3} , {4} , {5} ", row[0], row[1], row[2], row[3], row[4], row[5]);
                if ((int)row[5] == 1)
                {
                    LavoratoreDipendete lA = new LavoratoreDipendete
                    {
                        Nome = (string)row[0],
                        Cognome = (string)row[1],
                        DataDiNasciata = (DateTime)row[2],
                        StipendioAnn = (int)row[3],
                        DataAssunzione = (DateTime)row[4]

                    };
                    lavD.Add(lA);

                }
                else
                {
                    LavoratoreAutonomo lD = new LavoratoreAutonomo
                    {
                        Nome = (string)row[0],
                        Cognome = (string)row[1],
                        DataDiNasciata = (DateTime)row[2],
                        StipendioAnn = (int)row[3]


                    };
                    lavA.Add(lD);
                }
            }
        }

        internal static void UpdateList( List<Lavoratore> listL, Lavoratore up)
        {
            var upfin= listL.Where(l => l.Nome == up.Nome && l.Cognome == up.Cognome && l.DataDiNasciata == up.DataDiNasciata).FirstOrDefault();
            upfin = up;
            
        }
        internal static void UpdateList(List<LavoratoreAutonomo> listLD,  Lavoratore up)
        {
            var upfin = listLD.Where(l => l.Nome == up.Nome && l.Cognome == up.Cognome && l.DataDiNasciata == up.DataDiNasciata).FirstOrDefault();
            LavoratoreAutonomo upA = new LavoratoreAutonomo()
            {
                Nome = up.Nome,
                Cognome = up.Cognome,
                DataDiNasciata = up.DataDiNasciata,
                StipendioAnn = up.StipendioAnn
            };
            upfin = upA;
        }
        internal static void UpdateList(List<LavoratoreDipendete> listLD, Lavoratore up)
        {
            var upfin = listLD.Where(l => l.Nome == up.Nome && l.Cognome == up.Cognome && l.DataDiNasciata == up.DataDiNasciata).FirstOrDefault();
            LavoratoreDipendete upD = new LavoratoreDipendete()
            {
                Nome = up.Nome,
                Cognome = up.Cognome,
                DataDiNasciata = up.DataDiNasciata,
                StipendioAnn = up.StipendioAnn
            };
            upfin = upD;
        }

        internal static void DelateElement(List<Lavoratore> listLD, Lavoratore up)
        {
            
            var upfin = listLD.Where(l => l.Nome == up.Nome && l.Cognome == up.Cognome && l.DataDiNasciata == up.DataDiNasciata).FirstOrDefault();
            if (!(upfin == null))
            {
                listLD.Remove(upfin);
            }
        }
        internal static void DelateElement(List<LavoratoreDipendete> listLD, Lavoratore up)
        {

            var upfin = listLD.Where(l => l.Nome == up.Nome && l.Cognome == up.Cognome && l.DataDiNasciata == up.DataDiNasciata).FirstOrDefault();
            if (!(upfin == null))
            {
                listLD.Remove(upfin);
            }
        }
        internal static void DelateElement(List<LavoratoreAutonomo> listLD, Lavoratore up)
        {

            var upfin = listLD.Where(l => l.Nome == up.Nome && l.Cognome == up.Cognome && l.DataDiNasciata == up.DataDiNasciata).FirstOrDefault();
            if (!(upfin == null))
            {
                listLD.Remove(upfin);
            }
        }
    }
}
  

