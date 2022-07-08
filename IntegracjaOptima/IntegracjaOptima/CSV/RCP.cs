using CsvHelper;
using CsvHelper.Configuration;
using IntegracjaOptima.Log;
using IntegracjaOptima.Models;
using IntegracjaOptima.Narzedzia;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracjaOptima.CSV
{
    public class RCP
    {
        private static Model _model { get; set; }
        private static int _gidnumer { get; set; }

        public RCP(Model wchodzi,int gidnumer)
        {
            _model = wchodzi;
            _gidnumer = gidnumer;   
        }

        public ModelSciezki CreateRCP()
        {
            ModelSciezki sciezki = new ModelSciezki();
            List<ModelOUT> lista = new List<ModelOUT>();
            Tables Tables = new Tables();
            string data = DateTime.Now.ToString("yyyyMMdd");
            string czas = DateTime.Now.TimeOfDay.ToString("hhmm");


                //testowe pobranie magazyny docelowego z opisu cel testowy
                string magazynDocelowyTestowy = Tables.Database.SqlQuery<string>($@"select TrN_Opis from cdn.TraNag where trn_trnid={_gidnumer} and TrN_TypDokumentu=307").FirstOrDefault();


                var TreElem = Tables.Database.SqlQuery<TowarIlosc>($@"select distinct isnull(TrE_TwrKod,'') as TwrKod,isnull(TrE_Ilosc,0) as Ilosc, isnull(TrE_Lp,0) as Lp,isnull(TsC_Cecha1_Wartosc,'') as NumerPartii from CDN.TraElem 
                                                                            left join cdn.TraSElem on TrS_TrEId=TrE_TrEID
																	        left join cdn.TraSElemCechy on TrS_TrSId=tsc_trsid
                                                                            where TrE_TrnID={_gidnumer} and TrE_TypDokumentu=307").ToList();


                int ilosc = TreElem.Count();
                if (ilosc > 0)
                {
                    foreach (var i in TreElem)
                    {

                        string kodPcn = Tables.Database.SqlQuery<string>($@"select Twr_PCN from CDN.twrkarty where Twr_Kod='{i.TwrKod}'").FirstOrDefault();
                        string towarNazwa = Tables.Database.SqlQuery<string>($@"select Twr_Nazwa from CDN.twrkarty where Twr_Kod='{i.TwrKod}'").FirstOrDefault();




                        var modelPozycji = new PozDok();
                        string jednostka = "";
                        string orderLine = "";
                        string whsCode = "";
                        if (_model.Pozycje.Where(n => n.Item.Trim() == i.TwrKod.Trim()).Any() == true)
                        {
                            modelPozycji = _model.Pozycje.SingleOrDefault(n => n.Item.Trim() == i.TwrKod.Trim());
                            jednostka = modelPozycji.Um1;
                            orderLine = modelPozycji.OrderLine;
                            whsCode = modelPozycji.WhsCode;
                        }


                        lista.Add(new ModelOUT()
                        {
                            Event = "RCP",
                            Date = data,
                            Time = czas,
                            Year = DateTime.Now.ToString("yyyy"),
                            Site = _model.Site,
                            Number = _model.Number,
                            Reference = _model.Reference,
                            RefLines = ilosc,
                            WhsCode = whsCode,
                            OrderLine = orderLine,
                            Item = i.TwrKod.Replace("'", "").Trim(),
                            QtyUm1 = HelperClass.IloscDoWysylki(i.Ilosc.ToString().Replace(".", "")),
                            Um1 = jednostka,
                            ItemFree2 = magazynDocelowyTestowy.Trim()

                        });

                    }
                }
                else
                {
                    string trnNumerDokumentuPZin = Tables.Database.SqlQuery<string>($@"select TrN_NumerPelny from cdn.tranag where TrN_TrNID={_gidnumer} and TrN_TypDokumentu=307").FirstOrDefault();
                    Logger.WriteLog($"Błąd pobierania ilości z traelem dla dokumentu: {trnNumerDokumentuPZin} , gidnumer dokumentu to: {_gidnumer}. ");
                    Console.WriteLine($"Błąd pobierania ilości z traelem dla dokumentu: {trnNumerDokumentuPZin} , gidnumer dokumentu to: {_gidnumer}.");
                }
            var csv = lista;

            sciezki.SciezkaWyjscia = Program.Dostep + $"BEDI_RCP_{_model.Number}.csv";
            sciezki.SciezkaWejscia = ConfigurationManager.AppSettings["OutComing"] + $"BEDI_RCP_{_model.Number}.csv";
            sciezki.Dokument = $"BEDI_RCP{_model.Number}.csv";

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ";"
            };

            using (var streamWriter = File.CreateText(sciezki.SciezkaWyjscia))
            {
                var writer = new CsvWriter(streamWriter, config);

                writer.WriteRecords(csv);
            }
            return sciezki;


        }
    }
}
