using IntegracjaOptima.Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracjaOptima.Narzedzia
{
    class sql
    {
        public static string sql_single(string zapytanie)
        {
            string wynik;

            try
            {
                SqlConnection msConn = new SqlConnection(LoadSettings.ConnString);
                SqlCommand msComm;

                msConn.Open();
                msComm = new SqlCommand();
                msComm.Connection = msConn;
                msComm.CommandText = zapytanie;
                wynik = msComm.ExecuteScalar().ToString();
                msConn.Close();
                return wynik;
            }
            catch (Exception e)
            {
                wynik = "0";
                Logger.WriteLog($"Błąd SQL: {e}");
                return wynik;
            }

        }
        public static SqlDataReader sql_multi(string zapytanie)
        {
            SqlDataReader czytnik;

            SqlConnection polaczenie = new SqlConnection(LoadSettings.ConnString);
            polaczenie.Open();
            SqlCommand komendaSQL = polaczenie.CreateCommand();

            komendaSQL.CommandText = zapytanie;

            czytnik = komendaSQL.ExecuteReader();
            return czytnik;
        }
    }
}
