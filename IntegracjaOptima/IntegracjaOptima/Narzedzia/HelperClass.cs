using IntegracjaOptima.Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracjaOptima.Models;

namespace IntegracjaOptima.Narzedzia
{
    class HelperClass
    {

        public static DateTime Czas(string czas)
        {
            string rok = czas.Substring(0, 4);
            string miesiac = czas.Substring(4, 2);
            string dzien = czas.Substring(6, 2);

            string formatDaty =rok+"."+miesiac+"."+dzien;

            DateTime data = DateTime.Parse(formatDaty);
            return data;
        }
        public static bool CzyIstniejeTowar(string towarNazwa)
        {
            int ilosc = Int32.Parse(sql.sql_single($@"select COUNT(*) from CDN.twrkarty where Twr_kod='{towarNazwa}'"));
            if(ilosc==0)
            {
                return false;
            }
            return true;
        }
        public static bool CzyIstniejeKontrahent(string akronim)
        {
            int ilosc = Int32.Parse(sql.sql_single($@"select COUNT(*) from CDN.kntkarty where Knt_Akronim='{akronim}'"));
            if (ilosc == 0)
            {
                return false;
            }
            return true;
        }

        public static string Jednostka(decimal opak,decimal kg, decimal m,decimal ml)//sprawdzamy ktore pole jest uzupełnione w celu wybrania jednostki
        {
            if (opak != 0)
                return "opak";
            else if (kg != 0)
                return "kg";
            else if (m != 0)
                return "m";
            else if (ml != 0)
                return "litr";
            else
                return "szt";
        }
        public static decimal Ilosc(decimal opak, decimal kg, decimal m, decimal ml)//sprawdzamy które pole jest uzupełnione
        {
            if (opak != 0)
                return opak;
            else if (kg != 0)
                return PrzeksztalcenieIlosci(kg.ToString());
            else if (m != 0)
                return PrzeksztalcenieIlosci(m.ToString());
            else if (ml != 0)
                return PrzeksztalcenieIlosciMl(ml.ToString());
            else
                return 0;
        }


        public static void InsertDanychDoTabeli(int numerdok, int typdok,string nazwa)
        {


            using (var connection = new SqlConnection(LoadSettings.ConnString))
            {
                using (var command = new SqlCommand($@"INSERT INTO [CDN].[Dokumenty_DO_CSV]
                                                                       ([NumerDok]
                                                                       ,[TypDok]
                                                                       ,[Date]
                                                                       ,[App]
                                                                       ,[NazwaDokumentu]
                                                                       ,[CzyWyslanoDokumentZwrotny])
                                                                 VALUES
                                                                       ({numerdok}
                                                                       ,{typdok}
                                                                       ,GETDATE()
                                                                       ,'Automat'
                                                                       ,'{nazwa}'
                                                                       ,'nie')", connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
      
        public static decimal PrzeksztalcenieIlosci(string wartosc) // w zalożeniach te pola nie mają , do wartosci dziesietnych liczba 1 to 1000 miejsca 10 to 3 zera
        {
            decimal wynik = decimal.Parse(wartosc) / 1000;
            return wynik;            
        }
        public static decimal PrzeksztalcenieIlosciMl(string wartosc) //w założeniu te pola nie mają , do wartości dziesietnych liczba 1 to 100 
        {

            if (wartosc.Length > 2)
            {
                int length = wartosc.Length - 2;
                string wynik = wartosc.Remove(length, 2) + "," + wartosc.Substring(length);
                decimal ilosc = decimal.Parse(wynik);
                return ilosc;
            }
            return decimal.Parse(wartosc);
        }
        public static DateTime ZClarion(int dataCl)
        {

            return (new DateTime(1800, 12, 28)).AddDays(dataCl);
        }
        public static string IloscDoWysylki(string sztuki) // w sql mamy liczby 4,0000 a w załozeniach mamy miec 4,000 mają być 3 cyfry po przecinku
        {
            int index = sztuki.Length - 1;
            return sztuki.Remove(index, 1);
        }

        public static void insertAtrybutuNaTowarze(int twrID)
        {

                try
                {
                    using (var connection = new SqlConnection(LoadSettings.ConnString))
                    {
                        using (var command = new SqlCommand($@"INSERT INTO [CDN].[TwrAtrybuty]
                                                                       ([TwA_DeAId]
                                                                       ,[TwA_TwrId]
                                                                       ,[TwA_SrUId]
                                                                       ,[TwA_SrRId]
                                                                       ,[TwA_SrZId]
                                                                       ,[TwA_Zalezny]
                                                                       ,[TwA_ESklep]
                                                                       ,[TwA_WartoscTxt]
                                                                       ,[TwA_CzyKopiowac]
                                                                       ,[TwA_CzyKod]
                                                                       ,[TwA_CzyPrzenosic]
                                                                       ,[TwA_CzyDrukowac]
                                                                       ,[TwA_DABID]
                                                                       ,[TwA_CzyObowiazkowySerwis]
                                                                       ,[TwA_CzyObowiazkowyDostawy]
                                                                       ,[TwA_CzyPrzenosicNaDostawy]
                                                                       ,[TwA_RodzajId]
                                                                       ,[TwA_UrzId]
                                                                       ,[TwA_SourceId]
                                                                       ,[TwA_JezykId]
                                                                       ,[TwA_Lp]
                                                                       ,[TwA_AtrybutGrupujacyFantom])
                                                                 VALUES
                                                                       (46
                                                                       ,{twrID}--id towaru
                                                                       ,null
                                                                       ,null
                                                                       ,null
                                                                       ,0
                                                                       ,0
                                                                       ,''
                                                                       ,1
                                                                       ,0
                                                                       ,1
                                                                       ,1
                                                                       ,null
                                                                       ,0
                                                                       ,1
                                                                       ,1
                                                                       ,null
                                                                       ,null
                                                                       ,null
                                                                       ,1
                                                                       ,1
                                                                       ,0)", connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }

                    }



                }
                catch (Exception e)
                {
                    Logger.WriteLog($"Błąd insertowania atrybutu na towarze: {twrID} treść: {e}");
                }
            
        }
    }
}
