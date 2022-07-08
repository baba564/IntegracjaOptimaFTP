using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IntegracjaOptima
{
    public partial class Tables : DbContext
    {
        public Tables()
            : base(LoadSettings.ConnString)
        {
        }

        public virtual DbSet<DokAtrybuty> DokAtrybuty { get; set; }
        public virtual DbSet<Towary> Towary { get; set; }
        public virtual DbSet<TraNag> TraNag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DokAtrybuty>()
                .Property(e => e.DAt_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<DokAtrybuty>()
                .Property(e => e.DAt_WartoscDecimal)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_Kod)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_SWW)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_EAN)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_URL)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_Kategoria)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_KategoriaZak)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_JMPrzelicznikL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_JMPrzelicznikM)
                .HasPrecision(7, 0);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_Waluta)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_KursL)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_KursM)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_MinCenaMarza)
                .HasPrecision(15, 3);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_KosztUslugiWal)
                .HasPrecision(17, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_KosztUslugi)
                .HasPrecision(17, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_KosztKGO)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_IloscMin)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_IloscMax)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_IloscZam)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_Stawka)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_Zrodlowa)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_StawkaExport)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_ZrodlowaExport)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_StawkaZak)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_ZrodlowaZak)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_MarzaMin)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_Masa)
                .HasPrecision(15, 3);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_WagaKG)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_JmPomPrzelicznikL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_JmPomPrzelicznikM)
                .HasPrecision(7, 0);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_AkcyzaJMPomPrzelicznikL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_AkcyzaOpal)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_AkcyzaStawka)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_ESklepKalkulacjaDostawWartosc)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.TwR_KosztUslugiOld)
                .HasPrecision(17, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.TwR_WalutaZakOld)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.TwR_KursLZakOld)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Towary>()
                .Property(e => e.TwR_KursMZakOld)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_OpeModKod)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_OpeZalKod)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_AutoKodSeria)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_AutoKodWartosc)
                .IsUnicode(false);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_JMSentPrzelicznikL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_JMSentPrzelicznikM)
                .HasPrecision(7, 0);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_SentMasaBrutto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_OplataCukrowaPrzelicznikML)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_OplataCukrowaOdCukrowZawartoscGram)
                .HasPrecision(15, 3);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_OplataCukrowaOdCukrowStala)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_OplataCukrowaOdCukrowZmienna)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_OplataCukrowaOdKofeinyTaurynyStala)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Towary>()
                .Property(e => e.Twr_OplataCukrowaSuma)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_NumerString)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_NumerObcy)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_NumerPelnyPrw)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_RabatPromocyjny)
                .HasPrecision(11, 4);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_RabatKorekta)
                .HasPrecision(11, 4);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_PodKodPocztowy)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_PodNipKraj)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_PodmiotGLN)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_OdbKodPocztowy)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_OdbNipKraj)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_OdbiorcaGLN)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_OdbTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_Kategoria)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_RazemNetto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_RazemVAT)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_RazemBrutto)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_RazemNettoWal)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_RazemVATWal)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_RazemBruttoWal)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_Waluta)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_KursL)
                .HasPrecision(15, 4);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_KursM)
                .HasPrecision(5, 0);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_Rabat)
                .HasPrecision(5, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_ImportAppId)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_ImportRowId)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_EFakturaGUID)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_RabatWartosc)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_WartoscOO)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_OpeModKod)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_OpeZalKod)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_WartoscZakupu)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_OpeZatwKod)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_OpeWydrKod)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_WartoscSP)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TraNag>()
                .Property(e => e.TrN_OpeEMailKod)
                .IsUnicode(false);

            modelBuilder.Entity<TraNag>()
                .HasMany(e => e.DokAtrybuty)
                .WithOptional(e => e.TraNag)
                .HasForeignKey(e => e.DAt_TrNId)
                .WillCascadeOnDelete();
        }
    }
}
