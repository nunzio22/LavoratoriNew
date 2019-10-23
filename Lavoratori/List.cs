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
    }
}
  

