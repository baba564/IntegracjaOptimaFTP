using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using IntegracjaOptima.Narzedzia;
using IntegracjaOptima.CSV;
using IntegracjaOptima.Api;
using System.IO;
using IntegracjaOptima.Log;
using System.Data.SqlClient;
using System.Data;
using IntegracjaOptima.Models;


namespace IntegracjaOptima
{
    class Program
    {
        public static string Dostep { get; set; }
        public static string Pobrane { get; set; }
        public static bool CzyIstniejaWZ { get; set; } = false;
        public static bool CzyIstniejaPZ { get; set; } = false;
        static void Main(string[] args)
        {
          
            Dostep = $@"{Directory.GetCurrentDirectory()}\wyslane\";
            Pobrane = $@"{Directory.GetCurrentDirectory()}\tx\";
            Logger.CreateLogFile();
          

            LoadSettings.Load();


            OptimaDokumenty optima = new OptimaDokumenty();

            try
            {
                optima.LogowanieAutomatyczne();

               
               ObslugaFTP.ProcessNewOrder("inb");

                var dokumentyPZ = CzyDokumentPZZatwierdzony();
                if (CzyIstniejaPZ == true)
                {

                    foreach (var d in dokumentyPZ)
                    {
                        ObslugaFTP.WystawDokumentZwrotny("RCP", d.DokumentCSV, d.Gidnumer, d.NumerDokumentu);
                    }
                }

                ObslugaFTP.ProcessNewOrder("out");

                //szukanie dokumentu wz
                var dokumentyWZ = CzyDokumentWzZatwierdzony();
                if (CzyIstniejaWZ == true)
                {
                    foreach (var d in dokumentyWZ)
                    {
                        ObslugaFTP.WystawDokumentZwrotny("SHP", d.DokumentCSV, d.Gidnumer, d.NumerDokumentu);
                    }

                }
                //wystawienie stk
                if ((DateTime.Now.Hour >= 22) && (DateTime.Now.Hour <= 23))
                {
                    ModelSciezki sciezki = new ModelSciezki();
                    WyborTworzonegoDokumentu wyborTworzonegoDokumentu = new WyborTworzonegoDokumentu();
                    sciezki = wyborTworzonegoDokumentu.WybórDokumentu("STK");
                    ObslugaFTP.UploadFile(sciezki);
                }

              
            }
            catch (Exception e)
            {
                Logger.WriteLog($"Błąd {e}");
                Console.WriteLine($"Błąd {e}");
            }
            finally
            {
                optima.Wylogowanie();
                Logger.WriteLog("Koniec");
                Console.WriteLine("Koniec");
            }

           Console.ReadLine();
        }



        static List<Dokumenty> CzyDokumentWzZatwierdzony()
        {

          SqlDataReader wz=  sql.sql_multi($@"select wz.TrN_TrNID,NazwaDokumentu,NumerDok from CDN.TraNag wz
                                                inner join CDN.TraNag ro on ro.TrN_trnid=wz.TrN_FaId
                                                inner join CDN.Dokumenty_DO_CSV on NumerDok=ro.trn_trnid
                                                where ro.TrN_TypDokumentu=308 and wz.TrN_TypDokumentu=306 and wz.TrN_Bufor=0 and ro.TrN_Bufor=0 and CzyWyslanoDokumentZwrotny='nie'");

            DataTable tabelaElementow = new DataTable();
            tabelaElementow.Load(wz);
           
            if (tabelaElementow.Rows.Count > 0)
            {
                CzyIstniejaWZ = true;
                List<Dokumenty> dokumenty = new List<Dokumenty>();
                foreach (DataRow row in tabelaElementow.Rows)
                {
                    dokumenty.Add
                        (new Dokumenty 
                            { Gidnumer = Int32.Parse(row["trn_trnid"].ToString()),
                              DokumentCSV=row["NazwaDokumentu"].ToString(),
                              NumerDokumentu= Int32.Parse(row["NumerDok"].ToString())
                        });
                }
                return dokumenty;
            }
            else
            {
                Logger.WriteLog("Brak dokumentów WZ");
            }
            return null;
        }

        static List<Dokumenty> CzyDokumentPZZatwierdzony()
        {

            SqlDataReader wz = sql.sql_multi($@"select PZ.TrN_TrNID,NazwaDokumentu,NumerDok from CDN.TraNag zd
                                                inner join CDN.TraNag pz on pz.TrN_TrNID=zd.TrN_FaId
                                                inner join CDN.Dokumenty_DO_CSV on NumerDok=zd.trn_trnid
                                                where zd.TrN_TypDokumentu=309 and pz.TrN_TypDokumentu=307 AND zd.TrN_Bufor=0 AND pz.TrN_Bufor=0 and CzyWyslanoDokumentZwrotny='nie'");

            DataTable tabelaElementow = new DataTable();
            tabelaElementow.Load(wz);

            if (tabelaElementow.Rows.Count > 0)
            {
                CzyIstniejaPZ = true;
                List<Dokumenty> dokumenty = new List<Dokumenty>();
                foreach (DataRow row in tabelaElementow.Rows)
                {
                    dokumenty.Add
                        (new Dokumenty
                        {
                            Gidnumer = Int32.Parse(row["trn_trnid"].ToString()),
                            DokumentCSV = row["NazwaDokumentu"].ToString(),
                            NumerDokumentu = Int32.Parse(row["NumerDok"].ToString())
                        });
                }
                return dokumenty;
            }
            else
            {
                Logger.WriteLog("Brak dokumentów PZ");
            }
            return null;
        }
    }
}
