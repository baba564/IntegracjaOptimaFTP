using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using IntegracjaOptima.Models;
using IntegracjaOptima.Api;
using IntegracjaOptima.CSV;
using CsvHelper;
using IntegracjaOptima.Log;
using System.Security.Authentication;
using Renci.SshNet;
using Renci.SshNet.Sftp;



namespace IntegracjaOptima.Narzedzia
{
    class ObslugaFTP
    {
        private static string host { get; } = "host";
        private static string username { get; } = "user";
        private static string password { get; } = "haslo";




        public static void WystawDokumentZwrotny(string rodzajDokumentu, string nazwacsv, int gidnumer, int numerDok)
        {
           
            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();

                    var files = sftp.ListDirectory(ConfigurationManager.AppSettings["Processed"]);

                    foreach (var ftpFileInfo in files.Where(x => x.Name.Equals($"{nazwacsv}")))
                    {

                        Model model = ReadFile(ConfigurationManager.AppSettings["Processed"] + "/" + ftpFileInfo.Name,ftpFileInfo.Name);
                        ////  RenameFile(ConfigurationManager.AppSettings["InComing"] + "/" + ftpFileInfo.Name,
                        ////    ConfigurationManager.AppSettings["Processed"] + "/" + ftpFileInfo.Name);
                        if(model!=null)
                        {
                            WyborTworzonegoDokumentu wyborTworzonegoDokumentu = new WyborTworzonegoDokumentu(model, gidnumer);
                            ModelSciezki sciezki = new ModelSciezki();
                            sciezki = wyborTworzonegoDokumentu.WybórDokumentu(rodzajDokumentu);
                            
                            UploadFile(sciezki);
                            Tables Tables = new Tables();
                            Tables.Database.ExecuteSqlCommand($@"update Dokumenty_DO_CSV 
                                                                set CzyWyslanoDokumentZwrotny='TAK', Date=GETDATE() 
                                                                where NumerDok={numerDok}");

                            Logger.WriteLog($"Dokument wysłany {sciezki.Dokument}");
                            Console.WriteLine($"Dokument wysłany {sciezki.Dokument}");
                        }
                        else
                        {
                            Logger.WriteLog($"Model w dokumencie zwrotnym jest nullem błąd odczytu pliku lub brak dokumentu {ftpFileInfo.Name}");
                            Console.WriteLine($"Model w dokumencie zwrotnym jest nullem błąd odczytu pliku lub brak dokumentu {ftpFileInfo.Name}");
                        }
                    }

                    sftp.Disconnect();
                }


                catch (Exception ex)
                {
                    Logger.WriteLog("Error przy wystawianiu dokumentu zwrotnego: " + ex.Message);
                }
            }
        }



        private static Model ReadFile(string sciezka, string nazwa)      
        {
            string dostep = Program.Pobrane+nazwa;
      
            Model model = new Model();

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {

                    MemoryStream s = new MemoryStream();
                    sftp.Connect();
                    using (Stream fileStream = File.OpenWrite(dostep))
                    {
                        sftp.DownloadFile(sciezka, fileStream);
                    }

                    sftp.Disconnect();

                    using (var sww = new StreamReader(dostep))
                    {
                        while (!sww.EndOfStream)
                        {                        
                            string[] w = sww.ReadLine().ToString().Split(';');
                            model.Event = w[0];
                            model.Cause = w[1];
                            model.Date = HelperClass.Czas(w[2]);
                            model.Time = w[3];
                            model.ReferenceExt = w[4];
                            model.ReasonCode = w[5];
                            model.Year = w[6];
                            model.Site = w[7];
                            model.Number = decimal.Parse(w[8]);
                            model.Reference = w[9];
                            model.RefLines = decimal.Parse(w[10]);
                            model.OutCode = w[11];
                            model.OutName = w[12];
                            model.OutAddress = w[13];
                            model.OutCity = w[14];
                            model.OutCountryISO2 = w[15];
                            model.OutZipCode = w[16];
                            model.OutContact = w[17];
                            model.InCode = w[18];
                            model.InName = w[19];
                            model.InAddress = w[20];
                            model.InCity = w[21];
                            model.InCountryISO2 = w[22];
                            model.InZipCode = w[23];
                            model.InContact = w[24];
                            model.Pozycje.Add(
                                 new PozDok
                                 {

                                     Boxs = Decimal.Parse(w[25]),
                                     Kgs = Decimal.Parse(w[26]),
                                     M3 = Decimal.Parse(w[27]),
                                     Ml = Decimal.Parse(w[28]),
                                     Pallet = Decimal.Parse(w[29]),
                                     PalletType = w[30],
                                     Notes = w[31],
                                     Service1 = w[32],
                                     Service2 = w[33],
                                     Service3 = w[34],
                                     Service4 = w[35],
                                     Service5 = w[36],
                                     Service6 = w[37],
                                     Service7 = w[38],
                                     Service8 = w[39],
                                     Service9 = w[40],
                                     PodScan = w[41],
                                     Ammount = Decimal.Parse(w[42]),
                                     Cur = w[43],
                                     Type = w[44],
                                     WhsCode = w[45],
                                     OrderLine = w[46],
                                     Item = w[47],
                                     QtyUm1 = HelperClass.PrzeksztalcenieIlosci(w[48]),
                                     QtyUm2 = Decimal.Parse(w[49]),
                                     QtyUm3 = Decimal.Parse(w[50]),
                                     Lot = w[51],
                                     LabetType = w[52],
                                     SsccIn = w[53],
                                     Ssccout = w[54],
                                     Description = w[55],
                                     TariffCode = w[56],
                                     CustomCode = w[57],
                                     ItemType = w[58],
                                     Um1 = w[59],
                                     Um2 = w[60],
                                     Um3 = w[61],
                                     UnitsUm1 = Decimal.Parse(w[62]),
                                     KgnetUm1 = Decimal.Parse(w[63]),
                                     KggrossUm1 = Decimal.Parse(w[64]),
                                     Um1Pack = Decimal.Parse(w[65]),
                                     Um1Layer = Decimal.Parse(w[66]),
                                     Um1Pallet = w[67],
                                     Ean = w[68],
                                     ItemFree1 = w[69],
                                     ItemFree2 = w[70],
                                     ItemFree3 = w[71],
                                     ItemFree4 = w[72],
                                     ItemFree5 = w[73],
                                     ItemFree6 = w[74],
                                     ItemFree7 = w[75]
                                 }
                                );
                        }
                    }
                }
                catch (Exception er)
                {
                    Logger.WriteLog("Błąd czytania pliku: "+ er.Message);
                    return null;
                }
            }
            return model;

        }

        public static void ProcessNewOrder(string nazwa)
        {


            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();

                    var files = sftp.ListDirectory(ConfigurationManager.AppSettings["InComing"]);

                    foreach (var file in files.Where(x => x.Name.ToLower().EndsWith(".csv")).Where(x => x.Name.ToLower().StartsWith($"bedi_{nazwa}")))
                    {
                        if (nazwa == "inb")
                        {
                            Model modelINB = ReadFile(ConfigurationManager.AppSettings["InComing"] + "/" + file.Name, file.Name);
                            if(modelINB!=null)
                            {
                                OptimaDokumenty.wystawDokumentZD(modelINB, file.Name);
                                Movefile(ConfigurationManager.AppSettings["InComing"] + "/" + file.Name,
                                ConfigurationManager.AppSettings["Processed"] + "/" + file.Name);
                            }
                            else
                            {
                                Logger.WriteLog($"ModelINB jest nullem błąd odczytu pliku lub brak dokumentu {file.Name}");
                                Console.WriteLine($"ModelINB jest nullem błąd odczytu pliku lub brak dokumentu {file.Name}");
                            }
                          
                        }
                        else if (nazwa == "out")
                        {
                            Model modelOUT = ReadFile(ConfigurationManager.AppSettings["InComing"] + "/" + file.Name, file.Name);
                            if(modelOUT!=null)
                            {
                               bool CzyWystawionoDokument= OptimaDokumenty.wystawDokumentRO(modelOUT, file.Name);
                                if(CzyWystawionoDokument==true)
                                {
                                    Movefile(ConfigurationManager.AppSettings["InComing"] + "/" + file.Name,
                                    ConfigurationManager.AppSettings["Processed"] + "/" + file.Name);
                                }
                                else
                                {
                                    Logger.WriteLog($"Błąd przy wystawianiu dokumentu {file.Name}");
                                    Console.WriteLine($"Błąd przy wystawianiu dokumentu  {file.Name}");
                                }

                            }
                            else
                            {
                                Logger.WriteLog($"ModelOUT jest nullem błąd odczytu pliku lub brak dokumentu {file.Name}");
                                Console.WriteLine($"ModelOUT jest nullem błąd odczytu pliku lub brak dokumentu {file.Name}");
                            }
                        }

                    }

                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Logger.WriteLog("Blad przy wystawianiu dokumentow zwrotnych " + e.ToString());
                    Console.WriteLine("Blad przy wystawianiu dokumentow zwrotnych " + e.ToString());
                }
            }
        }

        public static void UploadFile(ModelSciezki sciezki)
        {

            var client = new SftpClient(host, username, password);
            client.Connect();
            if (client.IsConnected)
            {
                var fileStream = new FileStream(sciezki.SciezkaWyjscia, FileMode.Open);
                if (fileStream != null)
                {                 
                    client.UploadFile(fileStream,sciezki.SciezkaWejscia);
                    client.Disconnect();
                    client.Dispose();
                }
            }
        }

        public static void Movefile(string sciezkaWejscia, string sciezkaWyjscia)
        {
            SftpClient sftp = new SftpClient(host, username, password);
            sftp.Connect();
            var inFile = sftp.Get(sciezkaWejscia);
            inFile.MoveTo(sciezkaWyjscia);
            sftp.Disconnect();
        }


    }
}
