using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("_migRdkkSkip")]
[Index("Ktp", "NamaPetani", "TanggalLahir", Name = "_migRdkkSkip_KTP_NamaPetani_TanggalLahir_index")]
[Index("Ktp", Name = "_migRdkkSkip_KTP_index")]
public partial class MigRdkkSkip
{
    [Column("KTP")]
    [StringLength(255)]
    public string? Ktp { get; set; }

    [StringLength(255)]
    public string? NamaPetani { get; set; }

    [StringLength(255)]
    public string? TanggalLahir { get; set; }

    [StringLength(255)]
    public string? NamaPoktan { get; set; }

    [StringLength(255)]
    public string? Gapoktan { get; set; }

    [Column("keterangan")]
    [StringLength(255)]
    [Unicode(false)]
    public string Keterangan { get; set; } = null!;

    [Column("isFixed")]
    public int IsFixed { get; set; }

    public int Tahun { get; set; }
}
