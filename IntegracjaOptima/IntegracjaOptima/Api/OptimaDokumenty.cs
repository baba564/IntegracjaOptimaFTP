using CDNBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracjaOptima.Models;
using IntegracjaOptima.Narzedzia;
using IntegracjaOptima.Log;


namespace IntegracjaOptima.Api
{
    class OptimaDokumenty
    {
		protected static Application apka = null;
		protected static ILogin Login = null;


		// Przyklad 1. - Logowanie do O! bez wyświetlania okienka logowania
		public void LogowanieAutomatyczne()
		{
			string Operator = LoadSettings.Operator;
			string Haslo = "test";
			//string Haslo = "";// operator nie ma hasła
			string Firma = LoadSettings.Firma;  // nazwa firmy



			object[] hPar = new object[] {
						 0,  0,   0,  0,  0,   0,  0,    0,   0,   0,   0,   0,   0,   0,  0,   1,  1 };    // do jakich modułów się logujemy
			/* Kolejno: KP, KH, KHP, ST, FA, MAG, PK, PKXL, CRM, ANL, DET, BIU, SRW, ODB, KB, KBP, HAP
			 */

			// katalog, gdzie jest zainstalowana Optima (bez ustawienia tej zmiennej nie zadziała, chyba że program odpalimy z katalogu O!)
			System.Environment.CurrentDirectory = @"C:\Program Files (x86)\Comarch ERP Optima";//@"C:\Program Files\OPTIMA.NET";	

			// tworzymy nowy obiekt apliakcji
			//	Application = new ApplicationClass();

			//ApplicationClass application = new ApplicationClass();
			// Jeśli proces nie ma dostępu do klucza w rejstrze 
			// HKCU\Software\CDN\CDN OPT!MA\CDN OPT!MA\Login\KonfigConnectStr
			// np. gdy pracuje jako aplikacji w IIS 
			// ciąg połączeniowy (ConnectString) podajemy bezpośrednio :
			// Application.KonfigConnectStr = "NET:CDN_KNF_Konfiguracja_DW,SERWERSQL,NT=0";
			apka = new Application();

			// blokujemy
			//Login = Application.LockApp(256, 5000,Operator,Operator,Haslo,Firma);
			Login = apka.LockApp(256, 5000, null, null, null, null);


			// logujemy się do podanej Firmy, na danego operatora, do podanych modułów
			Login = apka.Login(Operator, Haslo, Firma, hPar[0], hPar[1], hPar[2], hPar[3], hPar[4], hPar[5], hPar[6], hPar[7], hPar[8], hPar[9], hPar[10], hPar[11], hPar[12], hPar[13], hPar[14], hPar[15], hPar[16]);


			//  Logowanie z pobraniem ustawienia modułów z karty Operatora
			//	Login = Application.Login(Operator, Haslo, Firma, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
			//

			// tu jesteśmy zalogowani do O!
			Console.WriteLine($"Jesteśmy zalogowani do O! {apka.Configuration.Database}");
			Logger.WriteLog($"Jesteśmy zalogowani do O! {apka.Configuration.Database}");
			//Console.ReadLine();
		}


		// wylogowanie z O!
		public void Wylogowanie()
		{
			// niszczymy Login
			Login = null;
			// odblokowanie (wylogowanie) O!
			apka.UnlockApp();
			// niszczymy obiekt Aplikacji
			apka = null;
		}
		public static void wystawDokumentZD(Model zDostawcy,string nazwaCSV)
		{
			if (HelperClass.CzyIstniejeKontrahent(zDostawcy.InCode) == false)
			{
				DodajKontrahenta(zDostawcy.InCode, zDostawcy.InAddress, zDostawcy.InCountryISO2, zDostawcy.InZipCode, zDostawcy.InCity, zDostawcy.InName);
			}
			CDNBase.AdoSession Sesja = Login.CreateSession();

            CDNHlmn.DokumentyHaMag zd = (CDNHlmn.DokumentyHaMag)Sesja.CreateObject("CDN.DokumentyHaMag", null);
            CDNHlmn.IDokumentHaMag zamowienie = (CDNHlmn.IDokumentHaMag)zd.AddNew(null);
		

			CDNBase.ICollection Kontrahenci = (CDNBase.ICollection)(Sesja.CreateObject("CDN.Kontrahenci", null));
            CDNHeal.IKontrahent Kontrahent = (CDNHeal.IKontrahent)Kontrahenci[$"Knt_Kod='{zDostawcy.InCode}'"];

            CDNBase.ICollection FormyPlatnosci = (CDNBase.ICollection)(Sesja.CreateObject("CDN.FormyPlatnosci", null));
            OP_KASBOLib.FormaPlatnosci FPl = (OP_KASBOLib.FormaPlatnosci)FormyPlatnosci[1];

            CDNHeal.DefinicjeDokumentow DefinicjeDokumentow = (CDNHeal.DefinicjeDokumentow)Sesja.CreateObject("CDN.DefinicjeDokumentow", null);
            CDNHeal.IDefinicjaDokumentu DefinicjaDokumentu = (CDNHeal.DefinicjaDokumentu)DefinicjeDokumentow["Ddf_Symbol='ZD'"];




            zamowienie.Rodzaj = 309000;
            zamowienie.TypDokumentu = 309;


            //Ustawiamy bufor
            zamowienie.Bufor = 1;



            //Ustawiamy formę póatności
            zamowienie.FormaPlatnosci = FPl;

            //Ustawiamy podmiot
            zamowienie.Podmiot = (CDNHeal.IPodmiot)Kontrahent;

            //Ustawiamy magazyn
            zamowienie.MagazynZrodlowyID = 1;
			zamowienie.MagazynDocelowyID = 1;
			

            //Ustawiamy numerator
            OP_KASBOLib.INumerator Numerator = (OP_KASBOLib.INumerator)zamowienie.Numerator;



            foreach (PozDok poz in zDostawcy.Pozycje)
            {
                string jednostka = HelperClass.Jednostka((decimal)poz.Boxs, (decimal)poz.Kgs, (decimal)poz.M3, (decimal)poz.Ml);
				decimal masa = 0.0m;
				if(poz.Kgs!=0)
                {
					masa = HelperClass.Ilosc((decimal)poz.Boxs, (decimal)poz.Kgs, (decimal)poz.M3, (decimal)poz.Ml);
				}
                

                if (HelperClass.CzyIstniejeTowar(poz.Item) == false)
                {
                    DodanieTowaru(poz.Item,poz.Description, jednostka,masa);
                }
                //Dodajemy pozycje
                CDNBase.ICollection Pozycje = zamowienie.Elementy;
                CDNHlmn.IElementHaMag Pozycja = (CDNHlmn.IElementHaMag)Pozycje.AddNew(null);
                Pozycja.TowarKod = poz.Item;
                Pozycja.Ilosc = double.Parse(poz.QtyUm1.ToString());
                Pozycja.TowarOpis = "Towar: " + poz.Description+ " "+"Cecha dostawy: "+poz.Lot;

				CDNHlmn.IElementAtrybut rAtrybutDokumentu = (CDNHlmn.IElementAtrybut)Pozycja.Atrybuty.AddNew(null);
				rAtrybutDokumentu.DeAId = 45;
				rAtrybutDokumentu.Wartosc = poz.Pallet.ToString();


			}

            //zapisujemy
            Sesja.Save();
			HelperClass.InsertDanychDoTabeli(zamowienie.ID, zamowienie.TypDokumentu, nazwaCSV);
			Logger.WriteLog($"Dodano zamówienie: {zamowienie.NumerPelny}");

		}

		//  Dodanie sprawdzenie towaru
		public static void DodanieTowaru(string kod,string nazwa,string jednostka,decimal masa)
		{
            CDNBase.AdoSession Sesja = Login.CreateSession();

            CDNTwrb1.Towary Towary = (CDNTwrb1.Towary)Sesja.CreateObject("CDN.Towary", null);
            CDNTwrb1.ITowar Towar = (CDNTwrb1.ITowar)Towary.AddNew(null);


			Towar.Kod = kod;
			Towar.Nazwa = nazwa;

			Towar.Stawka = 23.00m;
            Towar.Flaga = 2; // 2- oznacza stawkę opodatkowaną, pozostałe wartości 
							 // pola są podane w strukturze bazy tabela: [CDN.Towary].[Twr_Flaga]
			Towar.Masa = double.Parse(masa.ToString());
			Towar.JM = "szt";
			
			//Zapis
            Sesja.Save();
			HelperClass.insertAtrybutuNaTowarze(Towar.ID);
			Logger.WriteLog($"Towar dodany: {Towar.Akronim}");

        }




		public static bool wystawDokumentRO(Model dokumentRO, string nazwaCSV)
		{
			Tables tables = new Tables();
			List<CzyPrawda> CzyTowarIstnieje = new List<CzyPrawda>();
			List<CzyPrawda> CzyTowarMaDobraIlosc = new List<CzyPrawda>();
			foreach (PozDok poz in dokumentRO.Pozycje)
			{
				CzyTowarIstnieje.Add(new CzyPrawda()
				{
					Towar=poz.Item,
                    czyPrawda = HelperClass.CzyIstniejeTowar(poz.Item)
                });
            }
            if (CzyTowarIstnieje.Where(n => n.czyPrawda == false).Count() != 0)
            {
                foreach (var i in CzyTowarIstnieje)
                {
                    if (i.czyPrawda == false)
                    {
                        Logger.WriteLog($"Towar {i.Towar} nie istnieje dokument RO nie może zostać wystawiony.");
                        Console.WriteLine($"Towar {i.Towar} nie istnieje dokument RO nie może zostać wystawiony.");
                    }
                }
                return false;
            }
            else
            {
                foreach (PozDok poz in dokumentRO.Pozycje)
				{
									decimal ilosc = (decimal)poz.QtyUm1;
				

				decimal iloscDostepna = tables.Database.SqlQuery<decimal>($@"select SUM(isnull(TwZ_Ilosc,0)) from CDN.TwrZasoby
																														inner join CDN.twrkarty on Twr_GIDNumer=TwZ_TwrId 
																														where Twr_Kod='{poz.Item}'
																														group by Twr_Kod").FirstOrDefault();
				if (tables.Database.SqlQuery<decimal>($@"select SUM(isnull(TwZ_Ilosc,0)) from CDN.TwrZasoby
																														inner join CDN.twrkarty on Twr_GIDNumer=TwZ_TwrId 
																														where Twr_Kod='{poz.Item}'
																														group by Twr_Kod").Count() > 0)
									{

										

										if (iloscDostepna >= ilosc)
										{
											CzyTowarMaDobraIlosc.Add(new CzyPrawda()
											{
												Towar = poz.Item,
												czyPrawda = true
											}); ;
										}
										else
										{
											CzyTowarMaDobraIlosc.Add(new CzyPrawda()
											{
												Towar = poz.Item,
												czyPrawda = false
											}); ;
										}
									} 
									else
									{
										Console.WriteLine($"Błąd przy pobieraniu ilosc dla towar: {poz.Item} ilosc z CSV to: {ilosc} ,a ilość dostępna to {iloscDostepna}");
										Logger.WriteLog($"Błąd przy pobieraniu ilosc dla towar: {poz.Item} ilosc z CSV to: {ilosc} ,a ilość dostępna to {iloscDostepna}");
										return false;
									}
								} 

							if (CzyTowarMaDobraIlosc.Where(n => n.czyPrawda == false).Count() == 0)
							{

								if (HelperClass.CzyIstniejeKontrahent(dokumentRO.InCode) == false)
								{
									DodajKontrahenta(dokumentRO.InCode, dokumentRO.InAddress, dokumentRO.InCountryISO2, dokumentRO.InZipCode, dokumentRO.InCity, dokumentRO.InName);
								}
								CDNBase.AdoSession Sesja = Login.CreateSession();

								CDNHlmn.DokumentyHaMag ro = (CDNHlmn.DokumentyHaMag)Sesja.CreateObject("CDN.DokumentyHaMag", null);
								CDNHlmn.IDokumentHaMag rezerwacje = (CDNHlmn.IDokumentHaMag)ro.AddNew(null);

								CDNBase.ICollection Kontrahenci = (CDNBase.ICollection)(Sesja.CreateObject("CDN.Kontrahenci", null));
								CDNHeal.IKontrahent Kontrahent = (CDNHeal.IKontrahent)Kontrahenci[$"Knt_Kod='{dokumentRO.InCode}'"];

								CDNBase.ICollection FormyPlatnosci = (CDNBase.ICollection)(Sesja.CreateObject("CDN.FormyPlatnosci", null));
								OP_KASBOLib.FormaPlatnosci FPl = (OP_KASBOLib.FormaPlatnosci)FormyPlatnosci[1];

								CDNHeal.DefinicjeDokumentow DefinicjeDokumentow = (CDNHeal.DefinicjeDokumentow)Sesja.CreateObject("CDN.DefinicjeDokumentow", null);
								CDNHeal.IDefinicjaDokumentu DefinicjaDokumentu = (CDNHeal.DefinicjaDokumentu)DefinicjeDokumentow["Ddf_Symbol='RO'"];




								rezerwacje.Rodzaj = 308000;

								rezerwacje.TypDokumentu = 308;

								//Ustawiamy bufor
								rezerwacje.Bufor = 1;


								//Ustawiamy formę póatności
								rezerwacje.FormaPlatnosci = FPl;

								//Ustawiamy podmiot
								rezerwacje.Podmiot = (CDNHeal.IPodmiot)Kontrahent;

								//Ustawiamy magazyn
								rezerwacje.MagazynZrodlowyID = 1;
								rezerwacje.MagazynDocelowyID = 1;

								foreach (PozDok poz in dokumentRO.Pozycje)
								{
										decimal ilosc = (decimal)poz.QtyUm1;

												//Dodajemy pozycje
												CDNBase.ICollection Pozycje = rezerwacje.Elementy;
												CDNHlmn.IElementHaMag Pozycja = (CDNHlmn.IElementHaMag)Pozycje.AddNew(null);
												Pozycja.TowarKod = poz.Item;
												Pozycja.Ilosc = double.Parse(ilosc.ToString());
												Pozycja.TowarOpis = "Towar: " + poz.Description + " " + "Cecha dostawy: " + poz.Lot;
											

									
								}

								//zapisujemy
								Sesja.Save();

								HelperClass.InsertDanychDoTabeli(rezerwacje.ID, rezerwacje.TypDokumentu, nazwaCSV);
								Logger.WriteLog($"Dodano rezerwacje: {rezerwacje.NumerPelny}");
								return true;
							}
							else
							{
								Logger.WriteLog($"Brak wymaganej ilości towaru dla {nazwaCSV}");
								Console.WriteLine($"Brak wymaganej ilości towaru dla {nazwaCSV}");
								return false;
							}

			}	
			
		}
		protected static void DodajKontrahenta(string akronim,string adress,string prefiksNIP,string postCode,string city,string nazwa)
		{
			CDNBase.AdoSession Sesja = Login.CreateSession();

			OP_KASBOLib.Banki Banki = (OP_KASBOLib.Banki)Sesja.CreateObject("CDN.Banki", null);
			CDNHeal.Kategorie Kategorie = (CDNHeal.Kategorie)Sesja.CreateObject("CDN.Kategorie", null);

			CDNHeal.Kontrahenci Kontrahenci = (CDNHeal.Kontrahenci)Sesja.CreateObject("CDN.Kontrahenci", null);
			CDNHeal.IKontrahent Kontrahent = (CDNHeal.IKontrahent)Kontrahenci.AddNew(null);

			CDNHeal.IAdres Adres = Kontrahent.Adres;
			CDNHeal.INumerNIP NumerNIP = Kontrahent.NumerNIP;


			Adres.KodPocztowy = postCode;

			Adres.Miasto = city;

			Adres.Ulica = adress;
	

			NumerNIP.UstawNIP($"{prefiksNIP}", "", 1);

			Kontrahent.Akronim = akronim;

			Kontrahent.Medialny = 0;
			Kontrahent.Nazwa1 = nazwa;
			Kontrahent.Nazwa2 = "Nowy kontrahent dodany z aplikacji";
			string Nazwa = Kontrahent.NazwaPelna;

			Kontrahent.Bank = (OP_KASBOLib.Bank)Banki["BNa_BNaID=2"];

			Sesja.Save();

			Console.WriteLine("Nazwa dodanego kotrahenta: " + Nazwa);
		}

	}
}
