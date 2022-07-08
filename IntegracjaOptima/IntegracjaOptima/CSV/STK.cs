using CsvHelper;
using CsvHelper.Configuration;
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
    public class STK
    {

        public ModelSciezki CreateSTK()
        {
            Tables Tables = new Tables();
            ModelSciezki sciezki = new ModelSciezki();
            List<ModelOUT> lista = new List<ModelOUT>();


            string data = DateTime.Now.ToString("yyyyMMdd");
            string czas = DateTime.Now.TimeOfDay.ToString("hhmm");
            var towary = Tables.Database.SqlQuery<ModelTowarow>($@"select distinct
                                                                    isnull(Twr_Kod,'') as 'Kod' 
                                                                    ,isnull(TwZ_Ilosc,0) as 'Ilosc',
																	isnull(Twr_PCN,'') as 'KodCN',
																	isnull(TsC_Cecha1_Wartosc,'') as Cecha 
                                                                    from CDN.TwrZasoby 
                                                                    inner join CDN.TwrKarty on TwZ_TwrId=Twr_GIDNumer
																	left join cdn.TraSElem on TrS_TrSIdDost=TwZ_TrSIdDost
																	left join cdn.TraSElemCechy on TrS_TrSId=tsc_trsid
                                                                    where TwZ_MagId=1 and TrS_Rodzaj like '307%'").ToList();

            foreach (var towar in towary)
            {
                lista.Add(new ModelOUT()
                {
                    Event = "STK",
                    Date = data,
                    Time = czas,
                    Year = DateTime.Now.ToString("yyyy"),
                    Site = "55",
                    Number = decimal.Parse(DateTime.Now.DayOfYear.ToString()),
                    WhsCode = "PLW4",
                    Item = towar.Kod,
                    QtyUm1 = HelperClass.IloscDoWysylki(towar.Ilosc.ToString().Replace(".", "")),
                    Lot = towar.Cecha.ToUpper().Trim(),
                    //SsccIn = towar.KodCN,
                    Um1 = "PK"
                });
            }


            var csv = lista;

            sciezki.SciezkaWyjscia = Program.Dostep + $"BEDI_STK_{data}.csv";
            sciezki.SciezkaWejscia = ConfigurationManager.AppSettings["OutComing"] + $"BEDI_STK_{data}.csv";


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
