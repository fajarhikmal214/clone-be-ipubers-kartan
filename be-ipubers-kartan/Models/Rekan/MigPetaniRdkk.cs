using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("_migPetaniRDKK")]
[Index("Nik", Name = "IX__migPetaniRDKK", IsUnique = true)]
public partial class MigPetaniRdkk
{
    [Column("id")]
    [StringLength(255)]
    public string Id { get; set; } = null!;

    [Column("full_name")]
    [StringLength(255)]
    public string FullName { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string? Email { get; set; }

    [Column("kelompok_tani")]
    [StringLength(255)]
    public string KelompokTani { get; set; } = null!;

    [Column("NIK")]
    [StringLength(20)]
    public string Nik { get; set; } = null!;

    [Column("fotoKTP1")]
    [StringLength(255)]
    public string? FotoKtp1 { get; set; }

    [Column("fotoKTP2")]
    [StringLength(255)]
    public string? FotoKtp2 { get; set; }

    [Column("isPetaniRDKK")]
    public double? IsPetaniRdkk { get; set; }

    public double? StatusPetani { get; set; }

    [Column("noHp")]
    [StringLength(255)]
    public string? NoHp { get; set; }

    [StringLength(255)]
    public string? RetailerCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;
}
