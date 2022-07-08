namespace IntegracjaOptima
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CDN.TraNag")]
    public partial class TraNag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TraNag()
        {
            DokAtrybuty = new HashSet<DokAtrybuty>();
        }

        [Key]
        public int TrN_TrNID { get; set; }

        public int? TrN_RelTrNId { get; set; }

        public byte? TrN_FVMarza { get; set; }

        public int? TrN_DDfId { get; set; }

        public int TrN_TypDokumentu { get; set; }

        public int? TrN_ZwrId { get; set; }

        public int? TrN_FaId { get; set; }

        public int TrN_NumerNr { get; set; }

        [Required]
        [StringLength(31)]
        public string TrN_NumerString { get; set; }

        public short TrN_Bufor { get; set; }

        public int TrN_Anulowany { get; set; }

        public int? TrN_VaNId { get; set; }

        public DateTime TrN_DataDok { get; set; }

        public DateTime TrN_DataWys { get; set; }

        public DateTime TrN_DataOpe { get; set; }

        [Required]
        [StringLength(256)]
        public string TrN_NumerObcy { get; set; }

        public DateTime TrN_DataKur { get; set; }

        [Required]
        [StringLength(256)]
        public string TrN_NumerPelnyPrw { get; set; }

        public byte TrN_TaxFreePotwierdzony { get; set; }

        public byte TrN_Korekta { get; set; }

        public byte TrN_Fiskalna { get; set; }

        public int? TrN_FiskalnaErr { get; set; }

        public int TrN_StatusInt { get; set; }

        public decimal? TrN_RabatPromocyjny { get; set; }

        public decimal? TrN_RabatKorekta { get; set; }

        public byte TrN_Detal { get; set; }

        public int TrN_Rodzaj { get; set; }

        public short? TrN_PodmiotTyp { get; set; }

        public int? TrN_PodID { get; set; }

        [Required]
        [StringLength(10)]
        public string TrN_PodKodPocztowy { get; set; }

        [Required]
        [StringLength(2)]
        public string TrN_PodNipKraj { get; set; }

        [Required]
        [StringLength(20)]
        public string TrN_PodNipE { get; set; }

        [Required]
        [StringLength(13)]
        public string TrN_PodmiotGLN { get; set; }

        public byte TrN_Finalny { get; set; }

        public byte TrN_Export { get; set; }

        public short? TrN_OdbiorcaTyp { get; set; }

        public int? TrN_OdbID { get; set; }

        [Required]
        [StringLength(10)]
        public string TrN_OdbKodPocztowy { get; set; }

        [Required]
        [StringLength(2)]
        public string TrN_OdbNipKraj { get; set; }

        [Required]
        [StringLength(20)]
        public string TrN_OdbNipE { get; set; }

        [Required]
        [StringLength(13)]
        public string TrN_OdbiorcaGLN { get; set; }

        public short? TrN_OdbiorcaDocTyp { get; set; }

        public int? TrN_OdbDocID { get; set; }

        [StringLength(20)]
        public string TrN_OdbTelefon { get; set; }

        public int? TrN_KatID { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_Kategoria { get; set; }

        public int? TrN_FPlId { get; set; }

        public DateTime TrN_Termin { get; set; }

        public DateTime? TrN_TerminZwrotuKaucji { get; set; }

        public decimal TrN_RazemNetto { get; set; }

        public decimal TrN_RazemVAT { get; set; }

        public decimal TrN_RazemBrutto { get; set; }

        public decimal TrN_RazemNettoWal { get; set; }

        public decimal TrN_RazemVATWal { get; set; }

        public decimal TrN_RazemBruttoWal { get; set; }

        [Required]
        [StringLength(3)]
        public string TrN_Waluta { get; set; }

        public int TrN_KursNumer { get; set; }

        public decimal TrN_KursL { get; set; }

        public decimal TrN_KursM { get; set; }

        public byte TrN_PlatElemWalSys { get; set; }

        public byte TrN_VatDlaDokWal { get; set; }

        public byte TrN_PlatKaucje { get; set; }

        public short? TrN_PodmiotZalTyp { get; set; }

        public int? TrN_PodZalId { get; set; }

        public short TrN_BlokadaPlatnosci { get; set; }

        public int? TrN_MagZrdId { get; set; }

        public int? TrN_MagDocId { get; set; }

        public byte TrN_TypNB { get; set; }

        public decimal TrN_Rabat { get; set; }

        public byte? TrN_ZwroconoCalaIlosc { get; set; }

        public byte TrN_TrSTyp { get; set; }

        public int? TrN_DekId { get; set; }

        public DateTime? TrN_TS_Export { get; set; }

        [StringLength(5)]
        public string TrN_ImportAppId { get; set; }

        [StringLength(36)]
        public string TrN_ImportRowId { get; set; }

        public int? TrN_OpeZalID { get; set; }

        public int? TrN_StaZalId { get; set; }

        public DateTime TrN_TS_Zal { get; set; }

        public int? TrN_OpeModID { get; set; }

        public int? TrN_StaModId { get; set; }

        public DateTime TrN_TS_Mod { get; set; }

        public short? TrN_GIDTyp { get; set; }

        public int? TrN_GIDFirma { get; set; }

        public int? TrN_GIDNumer { get; set; }

        public short? TrN_GIDLp { get; set; }

        public byte? TrN_OFFPrawoDoFAPA { get; set; }

        public byte? TrN_OFFPrawoDoAnulowania { get; set; }

        public byte? TrN_OFFExportMag { get; set; }

        public byte TrN_Centrala { get; set; }

        public int? TrN_IsNId { get; set; }

        public DateTime? TrN_DataTransportu { get; set; }

        public int? TrN_DabId { get; set; }

        public DateTime? TrN_DataEFaktura { get; set; }

        [StringLength(36)]
        public string TrN_EFakturaGUID { get; set; }

        public DateTime? TrN_DataPtwTaxFree { get; set; }

        [Required]
        [StringLength(2)]
        public string TrN_KodKraju { get; set; }

        [Required]
        [StringLength(2)]
        public string TrN_KodTransakcji { get; set; }

        [Required]
        [StringLength(254)]
        public string TrN_NotaKorPo { get; set; }

        [Required]
        [StringLength(254)]
        public string TrN_NotaKorPrzed { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_OdbAdres2 { get; set; }

        [StringLength(127)]
        public string TrN_OdbEmail { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_OdbGmina { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_OdbKraj { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_OdbMiasto { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_OdbNazwa1 { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_OdbNazwa2 { get; set; }

        [Required]
        [StringLength(250)]
        public string TrN_OdbNazwa3 { get; set; }

        [Required]
        [StringLength(10)]
        public string TrN_OdbNrDomu { get; set; }

        [Required]
        [StringLength(10)]
        public string TrN_OdbNrLokalu { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_OdbPoczta { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_OdbPowiat { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_OdbUlica { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_OdbWojewodztwo { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_Odebral { get; set; }

        [StringLength(60)]
        public string TrN_OpeWysylajacy { get; set; }

        [Required]
        [StringLength(1024)]
        public string TrN_Opis { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_PodAdres2 { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_PodGmina { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_PodKraj { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_PodMiasto { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_PodNazwa1 { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_PodNazwa2 { get; set; }

        [Required]
        [StringLength(250)]
        public string TrN_PodNazwa3 { get; set; }

        [Required]
        [StringLength(10)]
        public string TrN_PodNrDomu { get; set; }

        [Required]
        [StringLength(10)]
        public string TrN_PodNrLokalu { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_PodPoczta { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_PodPowiat { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_PodUlica { get; set; }

        [Required]
        [StringLength(40)]
        public string TrN_PodWojewodztwo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(30)]
        public string TrN_NumerPelny { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(10)]
        public string TrN_StatusString { get; set; }

        public int? TrN_PreDekID { get; set; }

        public int? TrN_ZwrIdWZKK { get; set; }

        public int TrN_TrybNettoVAT { get; set; }

        public int? TrN_eSklepID { get; set; }

        public int? TrN_NieOkreslonaWartoscKor { get; set; }

        public byte TrN_ZwolnionyZAkcyzy { get; set; }

        [StringLength(200)]
        public string TrN_AkcyzaMiejsceOdbioru { get; set; }

        [StringLength(200)]
        public string TrN_AkcyzaMiejsceWydania { get; set; }

        public DateTime? TrN_AkcyzaDataRozpoczeciaPrzem { get; set; }

        public DateTime? TrN_AkcyzaDataOdbioruOd { get; set; }

        public DateTime? TrN_AkcyzaDataOdbioruDo { get; set; }

        public byte TrN_FADokumentDostawy { get; set; }

        [Required]
        [StringLength(150)]
        public string TrN_NrListuPrzewozowego { get; set; }

        public short? TrN_Srw { get; set; }

        public byte TrN_PodatekVat { get; set; }

        [Required]
        [StringLength(11)]
        public string TrN_Pesel { get; set; }

        public byte? TrN_FVMarzaRodzaj { get; set; }

        public decimal TrN_RabatWartosc { get; set; }

        public int TrN_PARodzajKor { get; set; }

        public byte TrN_MetodaKasowa { get; set; }

        public byte TrN_FinalnyWegiel { get; set; }

        [Required]
        [StringLength(1024)]
        public string TrN_KorektaZTytulu { get; set; }

        public byte TrN_EdycjaTabelkiVAT { get; set; }

        public short? TrN_PlatnikTyp { get; set; }

        public int? TrN_PlatnikID { get; set; }

        public byte TrN_PlatnoscNaWZ { get; set; }

        public int TrN_BzpId { get; set; }

        public byte TrN_RezerwacjaWew { get; set; }

        public byte TrN_PAFACzesciowe { get; set; }

        public byte TrN_AktualizacjaCenyZakKor { get; set; }

        public byte TrN_StawkaNPOO { get; set; }

        public decimal TrN_WartoscOO { get; set; }

        public int TrN_AwizoId { get; set; }

        public int TrN_DokMOSMMId { get; set; }

        public int? TrN_ZakID { get; set; }

        [Required]
        [StringLength(20)]
        public string TrN_OpeModKod { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_OpeModNazwisko { get; set; }

        [Required]
        [StringLength(20)]
        public string TrN_OpeZalKod { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_OpeZalNazwisko { get; set; }

        public int TrN_PunktyZam { get; set; }

        public int TrN_PunktyZap { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? TrN_WartoscZakupu { get; set; }

        public DateTime? TrN_WeryfikacjaVATCzynnyData { get; set; }

        public int? TrN_WeryfikacjaVATCzynnyWartosc { get; set; }

        public int Trn_Sent { get; set; }

        public int? TrN_eSklepZrodlo { get; set; }

        public byte? TrN_eSklepRodzajDokumentu { get; set; }

        [StringLength(50)]
        public string TrN_eSklepFormaPlatnosci { get; set; }

        public byte? TrN_eSklepStatusPlatnosci { get; set; }

        [StringLength(2048)]
        public string TrN_eSklepUwagiKlienta { get; set; }

        public short? TrN_eSklepSposobDostawyTyp { get; set; }

        [StringLength(100)]
        public string TrN_eSklepSposobDostawyNazwa { get; set; }

        public short? TrN_eSklepStatusDostawy { get; set; }

        public int? TrN_eSklepPunktOdbioruOsobistegoID { get; set; }

        public int? TrN_eSklepPunktOdbioruOsobistegoIDeSklep { get; set; }

        [StringLength(250)]
        public string TrN_eSklepPunktOdbioruOsobistegoNazwa1 { get; set; }

        [StringLength(250)]
        public string TrN_eSklepPunktOdbioruOsobistegoNazwa2 { get; set; }

        [StringLength(2)]
        public string TrN_eSklepPunktOdbioruOsobistegoKrajISO { get; set; }

        [StringLength(50)]
        public string TrN_eSklepPunktOdbioruOsobistegoWojewodztwo { get; set; }

        [StringLength(50)]
        public string TrN_eSklepPunktOdbioruOsobistegoUlica { get; set; }

        [StringLength(10)]
        public string TrN_eSklepPunktOdbioruOsobistegoNrBudynku { get; set; }

        [StringLength(10)]
        public string TrN_eSklepPunktOdbioruOsobistegoNrLokalu { get; set; }

        [StringLength(50)]
        public string TrN_eSklepPunktOdbioruOsobistegoMiasto { get; set; }

        [StringLength(10)]
        public string TrN_eSklepPunktOdbioruOsobistegoKodPocztowy { get; set; }

        [StringLength(20)]
        public string TrN_eSklepPunktOdbioruOsobistegoTelefon { get; set; }

        [StringLength(20)]
        public string TrN_eSklepPunktOdbioruOsobistegoGSM { get; set; }

        [StringLength(50)]
        public string TrN_eSklepKodPaczkomatuPodst { get; set; }

        [StringLength(30)]
        public string TrN_eSklepPaczkomatKodPaczki { get; set; }

        [StringLength(50)]
        public string TrN_eSklepPaczkomatPodstMiasto { get; set; }

        [StringLength(10)]
        public string TrN_eSklepPaczkomatPodstKodPocztowy { get; set; }

        [StringLength(50)]
        public string TrN_eSklepPaczkomatPodstUlica { get; set; }

        [StringLength(50)]
        public string TrN_eSklepPaczkomatPodstUlicaNR { get; set; }

        [StringLength(50)]
        public string TrN_eSklepKodPaczkomatuRezerw { get; set; }

        [StringLength(50)]
        public string TrN_eSklepPaczkomatRezerwMiasto { get; set; }

        [StringLength(10)]
        public string TrN_eSklepPaczkomatRezerwKodPocztowy { get; set; }

        [StringLength(50)]
        public string TrN_eSklepPaczkomatRezerwUlica { get; set; }

        [StringLength(50)]
        public string TrN_eSklepPaczkomatRezerwUlicaNR { get; set; }

        public int? TrN_OpeZatwID { get; set; }

        public DateTime? TrN_TS_Zatw { get; set; }

        public int? TrN_OpeWydrID { get; set; }

        public DateTime? TrN_TS_Wydr { get; set; }

        [Required]
        [StringLength(20)]
        public string TrN_OpeZatwKod { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_OpeZatwNazwisko { get; set; }

        [Required]
        [StringLength(20)]
        public string TrN_OpeWydrKod { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_OpeWydrNazwisko { get; set; }

        public int? TrN_PCID { get; set; }

        public int? TrN_PCJSID { get; set; }

        [StringLength(200)]
        public string TrN_eSklepPunktOdbioruOsobistegoEmail { get; set; }

        public string TrN_eSklepPunktOdbioruOsobistegoAPI { get; set; }

        [StringLength(12)]
        public string TrN_eSklepPunktOdbioruOsobistegoSzerokosc { get; set; }

        [StringLength(12)]
        public string TrN_eSklepPunktOdbioruOsobistegoDlugosc { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_DokumentTozsamosci { get; set; }

        public byte TrN_UmowaWegiel { get; set; }

        public int TrN_NrListuPrzewozowegoTypKuriera { get; set; }

        public byte TrN_SplitPay { get; set; }

        public decimal TrN_WartoscSP { get; set; }

        public DateTime? TrN_eSklepDataDost { get; set; }

        public int TrN_PlatnikRachunekLp { get; set; }

        [Required]
        [StringLength(51)]
        public string TrN_PlatnikRachunekNr { get; set; }

        public int? TrN_OpeEMailID { get; set; }

        public DateTime? TrN_TS_EMail { get; set; }

        [Required]
        [StringLength(20)]
        public string TrN_OpeEMailKod { get; set; }

        [Required]
        [StringLength(50)]
        public string TrN_OpeEMailNazwisko { get; set; }

        public DateTime? TrN_AwfWyslano { get; set; }

        public byte TrN_NieNaliczajOplataCukrowa { get; set; }

        public byte TrN_RozliczamPodatekWOSS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DokAtrybuty> DokAtrybuty { get; set; }
    }
}
