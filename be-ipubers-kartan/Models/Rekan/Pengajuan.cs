using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Pengajuan", Schema = "FSCM_BNI")]
[Index("IdRetailer", Name = "UK_Pengajuan_IdRetailer", IsUnique = true)]
public partial class Pengajuan
{
    [Key]
    [StringLength(250)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string IdRetailer { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalPengajuan { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NamaLengkap { get; set; } = null!;

    [Column("NIK")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    public DateOnly TanggalLahir { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string JenisKelamin { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("NoHP")]
    [StringLength(50)]
    [Unicode(false)]
    public string NoHp { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string KodeDesa { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string KodePos { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string SektorEkonomi { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string SubSektorEkonomi { get; set; } = null!;

    [Unicode(false)]
    public string Deskripsi { get; set; } = null!;

    [Column("LinkKTP")]
    [Unicode(false)]
    public string LinkKtp { get; set; } = null!;

    [Unicode(false)]
    public string LinkFotoDiri { get; set; } = null!;

    public int StatusPengajuan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Unicode(false)]
    public string? LinkFotoKios { get; set; }

    [Unicode(false)]
    public string? AlamatUsaha { get; set; }

    public int? PendapatanPerbulan { get; set; }

    [InverseProperty("IdPengajuanNavigation")]
    public virtual ICollection<LogPengajuan> LogPengajuans { get; set; } = new List<LogPengajuan>();
}
