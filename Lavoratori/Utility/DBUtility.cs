
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavoratori.Utility
{
    public static class DBUtility
    {
        private static SqlConnection connection;

        private static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }
        public static int Delate(string l)
        {
            int ris;
            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = string.Format("DELETE FROM {0} ", l)
            };
            cmd.Connection.Open();
            ris = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return ris;
        }
        /// <summary>
        /// Eliminazione del Utente selezionato 
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static int DelateLavoratore(Lavoratore l)
        {
            int ris;
            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM  Lavoratore WHERE Nome=@Nome AND Cognome=@Cognome AND DataDiNascita=@DataDiNascita "
            };
            cmd.Parameters.AddWithValue("@Nome", l.Nome);
            cmd.Parameters.AddWithValue("@Cognome", l.Cognome);
            cmd.Parameters.AddWithValue("@DataDiNascita", l.DataDiNasciata);
            cmd.Connection.Open();
            ris = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return ris;
        }
        public static int UpdateLavoratore(Lavoratore l,int tipo)
        {
            int ris;
            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = "UPDATE Lavoratore SET  " +
                "StipendioAnnuale=@StipendioAnnuale, " +
                "DataDiAssunzione=@DataDiAssunzione, " +
                "Tipo=@Tipo " +
                "WHERE Nome=@Nome AND " +
                "Cognome=@Cognome AND " +
                "DataDiNascita=@DataDiNascita"
            };
            cmd.Parameters.Add("@Nome", SqlDbType.VarChar, 255).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.VarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNasciata;
            cmd.Parameters.Add("@StipendioAnnuale", SqlDbType.Float).Value = l.StipendioAnn;
            if (tipo==1)
            {
                LavoratoreDipendete lv = (LavoratoreDipendete)l;
                cmd.Parameters.Add("@DataDiAssunzione", SqlDbType.DateTime).Value = lv.DataAssunzione;
                cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value =1;
            }
            else
            {
                cmd.Parameters.Add("@DataDiAssunzione", SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = 2;
            }
            


            cmd.Connection.Open();
            ris = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return ris;
        }
        public static void InsertLavoratore(Lavoratore l)
        {


            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO lavoratore" +
                " (Nome,Cognome,DataDiNascita,StipendioAnnuale,DataDiAssunzione,Tipo)" +
                " VALUES" +
                " (@Nome,@Cognome,@DataDiNascita,@StipendioAnnuale,@DataDiAssunzione,@Tipo)"
            };

            cmd.Parameters.Add("@Nome", SqlDbType.VarChar, 255).Value = l.Nome;
            cmd.Parameters.Add("@Cognome", SqlDbType.VarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNasciata;
            cmd.Parameters.Add("@StipendioAnnuale", SqlDbType.Float).Value = l.StipendioAnn;

            if (l is LavoratoreDipendete)
            {
                LavoratoreDipendete lv = (LavoratoreDipendete)l;
                cmd.Parameters.Add("@DataDiAssunzione", SqlDbType.DateTime).Value = lv.DataAssunzione;
                cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = 1;
            }
            else
            {
                cmd.Parameters.Add("@DataDiAssunzione", SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = 2;
            }


            cmd.Connection.Open();
            int ris = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static DataSet GetLavoratore()
        {
            DataSet ris = new DataSet();
            string selectQuery = "SELECT Nome,Cognome,DataDiNascita,StipendioAnnuale,DataDiAssunzione,Tipo  " +
                "From Lavoratore";
            SqlCommand cmd = new SqlCommand(selectQuery, GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ris);
            return ris;
        }
    }
}
