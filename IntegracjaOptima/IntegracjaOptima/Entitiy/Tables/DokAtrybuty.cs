namespace IntegracjaOptima
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CDN.DokAtrybuty")]
    public partial class DokAtrybuty
    {
        [Key]
        public int DAt_DAtId { get; set; }

        [StringLength(20)]
        public string DAt_Kod { get; set; }

        public int DAt_DeAId { get; set; }

        public int? DAt_TrNId { get; set; }

        public int? DAt_CRKId { get; set; }

        public int? DAt_SrZId { get; set; }

        public int? DAt_VaNID { get; set; }

        public int? DAt_DoNID { get; set; }

        [Required]
        [StringLength(1024)]
        public string DAt_WartoscTxt { get; set; }

        public int? DAt_OfdID { get; set; }

        public int? DAt_DokumentTyp { get; set; }

        public int? DAt_DokumentId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? DAt_WartoscDecimal { get; set; }

        public byte? DAt_TypJPK { get; set; }

        public virtual TraNag TraNag { get; set; }
    }
}
