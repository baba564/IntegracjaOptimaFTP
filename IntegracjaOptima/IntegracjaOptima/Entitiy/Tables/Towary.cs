namespace IntegracjaOptima
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CDN.Towary")]
    public partial class Towary
    {
        [Key]
        public int Twr_TwrId { get; set; }

        public byte Twr_Typ { get; set; }

        public short Twr_Produkt { get; set; }

        [Required]
        [StringLength(50)]
        public string Twr_Kod { get; set; }

        [Required]
        [StringLength(20)]
        public string Twr_SWW { get; set; }

        [Required]
        [StringLength(40)]
        public string Twr_EAN { get; set; }

        public int Twr_TwGGIDNumer { get; set; }

        [Required]
        [StringLength(254)]
        public string Twr_URL { get; set; }

        public int? Twr_KatId { get; set; }

        [Required]
        [StringLength(50)]
        public string Twr_Kategoria { get; set; }

        public int? Twr_KatZakId { get; set; }

        [Required]
        [StringLength(50)]
        public string Twr_KategoriaZak { get; set; }

        public byte Twr_EdycjaNazwy { get; set; }

        public byte Twr_KopiujOpis { get; set; }

        public byte Twr_EdycjaOpisu { get; set; }

        public decimal Twr_JMPrzelicznikL { get; set; }

        public decimal Twr_JMPrzelicznikM { get; set; }

        public byte Twr_JMCalkowite { get; set; }

        public byte Twr_Kaucja { get; set; }

        public int Twr_TwCNumer { get; set; }

        public byte Twr_UdostepniajWCenniku { get; set; }

        [Required]
        [StringLength(3)]
        public string Twr_Waluta { get; set; }

        public int Twr_KursNumer { get; set; }

        public decimal Twr_KursL { get; set; }

        public decimal Twr_KursM { get; set; }

        public decimal Twr_MinCenaMarza { get; set; }

        public byte Twr_TypMinimum { get; set; }

        public decimal Twr_KosztUslugiWal { get; set; }

        public decimal Twr_KosztUslugi { get; set; }

        public byte Twr_KosztUslugiTyp { get; set; }

        public decimal Twr_KosztKGO { get; set; }

        public int? Twr_SONId { get; set; }

        public int? Twr_KntId { get; set; }

        public decimal Twr_IloscMin { get; set; }

        public decimal Twr_IloscMax { get; set; }

        public decimal Twr_IloscZam { get; set; }

        public decimal Twr_Stawka { get; set; }

        public short Twr_Flaga { get; set; }

        public decimal Twr_Zrodlowa { get; set; }

        public decimal Twr_StawkaExport { get; set; }

        public short Twr_FlagaExport { get; set; }

        public decimal Twr_ZrodlowaExport { get; set; }

        public decimal Twr_StawkaZak { get; set; }

        public short Twr_FlagaZak { get; set; }

        public decimal Twr_ZrodlowaZak { get; set; }

        public byte Twr_Prog { get; set; }

        public byte Twr_Upust { get; set; }

        public byte Twr_UpustData { get; set; }

        public int? Twr_UpustDataOd { get; set; }

        public int? Twr_UpustDataDo { get; set; }

        public byte Twr_UpustGodz { get; set; }

        public int? Twr_UpustGodzOd { get; set; }

        public int? Twr_UpustGodzDo { get; set; }

        public byte Twr_BezRabatu { get; set; }

        public decimal Twr_MarzaMin { get; set; }

        public byte Twr_NieAktywny { get; set; }

        public byte? Twr_ESklep { get; set; }

        public int? Twr_KCNId { get; set; }

        public decimal Twr_Masa { get; set; }

        public int? Twr_PrdID { get; set; }

        public int? Twr_MrkID { get; set; }

        public short Twr_ESklepBezRabatu { get; set; }

        public short Twr_ESklepStatus { get; set; }

        public short Twr_ESklepDostepnosc { get; set; }

        public decimal? Twr_WagaKG { get; set; }

        public decimal Twr_JmPomPrzelicznikL { get; set; }

        public decimal Twr_JmPomPrzelicznikM { get; set; }

        public int? Twr_OpeZalID { get; set; }

        public int? Twr_StaZalId { get; set; }

        public DateTime Twr_TS_Zal { get; set; }

        public int? Twr_OpeModID { get; set; }

        public int? Twr_StaModId { get; set; }

        public DateTime? Twr_TS_XL { get; set; }

        public DateTime Twr_TS_Mod { get; set; }

        public short? Twr_GIDTyp { get; set; }

        public int? Twr_GIDFirma { get; set; }

        public int? Twr_GIDNumer { get; set; }

        public short? Twr_GIDLp { get; set; }

        public int? Twr_IGaleriaKatId { get; set; }

        [Required]
        [StringLength(20)]
        public string Twr_IloscMaxJM { get; set; }

        [Required]
        [StringLength(20)]
        public string Twr_IloscMinJM { get; set; }

        [Required]
        [StringLength(20)]
        public string Twr_IloscZamJM { get; set; }

        [Required]
        [StringLength(20)]
        public string Twr_JM { get; set; }

        [Required]
        [StringLength(20)]
        public string Twr_JMZ { get; set; }

        [Required]
        [StringLength(50)]
        public string Twr_KodDostawcy { get; set; }

        [Required]
        [StringLength(2)]
        public string Twr_KrajPochodzenia { get; set; }

        [Required]
        [StringLength(255)]
        public string Twr_Nazwa { get; set; }

        [Required]
        [StringLength(40)]
        public string Twr_NazwaFiskalna { get; set; }

        [Required]
        [StringLength(40)]
        public string Twr_NumerKat { get; set; }

        [Required]
        public string Twr_Opis { get; set; }

        [Required]
        [StringLength(18)]
        public string Twr_PLU { get; set; }

        public byte Twr_Akcyza { get; set; }

        public decimal Twr_AkcyzaJMPomPrzelicznikL { get; set; }

        public int Twr_AkcyzaJMPomPrzelicznikM { get; set; }

        public decimal Twr_AkcyzaOpal { get; set; }

        public decimal Twr_AkcyzaStawka { get; set; }

        public byte Twr_ESklepKalkulacjaDostaw { get; set; }

        public decimal Twr_ESklepKalkulacjaDostawWartosc { get; set; }

        public byte Twr_ESklepFlaga_Nowosc { get; set; }

        public byte Twr_ESklepFlaga_Promocja { get; set; }

        public byte Twr_ESklepFlaga_ProduktzGazetki { get; set; }

        public byte Twr_ESklepFlaga_ProduktPolecany { get; set; }

        public byte Twr_ESklepFlaga_Wyprzedaz { get; set; }

        public byte Twr_ESklepFlaga_SuperJakosc { get; set; }

        public byte Twr_ESklepFlaga_SuperCena { get; set; }

        public byte Twr_ESklepFlaga_NajlepiejOceniany { get; set; }

        public byte Twr_ESklepFlaga_RekomendacjaSprzedawcy { get; set; }

        [Required]
        [StringLength(50)]
        public string Twr_ProducentKod { get; set; }

        public int? Twr_ESklepFantomID { get; set; }

        public byte Twr_OdwrotneObciazenie { get; set; }

        public byte Twr_Mobile { get; set; }

        public byte Twr_PobieranieSkladnikowFSUslugaZlozona { get; set; }

        public decimal TwR_KosztUslugiOld { get; set; }

        [Required]
        [StringLength(3)]
        public string TwR_WalutaZakOld { get; set; }

        public decimal TwR_KursLZakOld { get; set; }

        public decimal TwR_KursMZakOld { get; set; }

        [Required]
        [StringLength(20)]
        public string Twr_OpeModKod { get; set; }

        [Required]
        [StringLength(50)]
        public string Twr_OpeModNazwisko { get; set; }

        [Required]
        [StringLength(20)]
        public string Twr_OpeZalKod { get; set; }

        [Required]
        [StringLength(50)]
        public string Twr_OpeZalNazwisko { get; set; }

        public byte Twr_CenaZCzteremaMiejscami { get; set; }

        public byte Twr_AutoKodGrupaTowarowa { get; set; }

        [Required]
        [StringLength(40)]
        public string Twr_AutoKodSeria { get; set; }

        [Required]
        [StringLength(50)]
        public string Twr_AutoKodWartosc { get; set; }

        public int Twr_AutoKodNumer { get; set; }

        public byte Twr_Sent { get; set; }

        public decimal Twr_JMSentPrzelicznikL { get; set; }

        public decimal Twr_JMSentPrzelicznikM { get; set; }

        public decimal Twr_SentMasaBrutto { get; set; }

        [Required]
        [StringLength(6)]
        public string Twr_SentKodOdpadu { get; set; }

        [Required]
        [StringLength(500)]
        public string Twr_SJRodzajPaliwa { get; set; }

        [Required]
        [StringLength(500)]
        public string Twr_SJSystemCertyfikacji { get; set; }

        [Required]
        [StringLength(15)]
        public string Twr_SJPopiol { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJPopiolMin { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJPopiolMax { get; set; }

        [Required]
        [StringLength(15)]
        public string Twr_SJCzesciLotne { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJCzesciLotneMin { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJCzesciLotneMax { get; set; }

        [Required]
        [StringLength(15)]
        public string Twr_SJWartoscOpalowa { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJWartoscOpalowaMin { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJWartoscOpalowaMax { get; set; }

        [Required]
        [StringLength(15)]
        public string Twr_SJZdolnoscSpiekania { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJZdolnoscSpiekaniaMin { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJZdolnoscSpiekaniaMax { get; set; }

        [Required]
        [StringLength(15)]
        public string Twr_SJWymiarZiarna { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJWymiarZiarnaMin { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJWymiarZiarnaMax { get; set; }

        [Required]
        [StringLength(15)]
        public string Twr_SJZawartoscPodziarna { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJZawartoscPodziarnaMin { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJZawartoscPodziarnaMax { get; set; }

        [Required]
        [StringLength(15)]
        public string Twr_SJZawartoscNadziarna { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJZawartoscNadziarnaMin { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJZawartoscNadziarnaMax { get; set; }

        [Required]
        [StringLength(15)]
        public string Twr_SJZawartoscWilgoci { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJZawartoscWilgociMin { get; set; }

        [Required]
        [StringLength(10)]
        public string Twr_SJZawartoscWilgociMax { get; set; }

        public byte Twr_SplitPay { get; set; }

        public int Twr_KV7ID { get; set; }

        public int? Twr_OpiekunID { get; set; }

        public short? Twr_OpiekunTyp { get; set; }

        public short? Twr_JMWysCm { get; set; }

        public short? Twr_JMSzerCm { get; set; }

        public short? Twr_JMDlugCm { get; set; }

        public byte Twr_OplataCukrowa { get; set; }

        public decimal Twr_OplataCukrowaPrzelicznikML { get; set; }

        public decimal Twr_OplataCukrowaOdCukrowZawartoscGram { get; set; }

        public byte Twr_OplataCukrowaOdCukrowZawartoscSokow20 { get; set; }

        public byte Twr_OplataCukrowaOdCukrowZawartoscRoztwor { get; set; }

        public byte Twr_OplataCukrowaOdKofeinyTauryny { get; set; }

        public byte Twr_OplataCukrowaOdSubstancjiSlodzacych { get; set; }

        public decimal Twr_OplataCukrowaOdCukrowStala { get; set; }

        public decimal Twr_OplataCukrowaOdCukrowZmienna { get; set; }

        public decimal Twr_OplataCukrowaOdKofeinyTaurynyStala { get; set; }

        public decimal Twr_OplataCukrowaSuma { get; set; }
    }
}
