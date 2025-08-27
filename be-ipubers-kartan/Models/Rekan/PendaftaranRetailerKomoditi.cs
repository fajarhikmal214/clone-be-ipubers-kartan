using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PendaftaranRetailerKomoditi")]
public partial class PendaftaranRetailerKomoditi
{
    [Key]
    public long Id { get; set; }

    public int JenisId { get; set; }

    [StringLength(60)]
    public string PendaftaranId { get; set; } = null!;

    [ForeignKey("JenisId")]
    [InverseProperty("PendaftaranRetailerKomoditis")]
    public virtual JenisKomoditi Jenis { get; set; } = null!;

    [ForeignKey("PendaftaranId")]
    [InverseProperty("PendaftaranRetailerKomoditis")]
    public virtual PendaftaranRetailer Pendaftaran { get; set; } = null!;
}
