using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("_migStok")]
public partial class MigStok
{
    public int Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeProdusen { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string KodeDistributor { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string NoF6 { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string NoPkp { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? NamaKios { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Kecamatan { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Kabupaten { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Provinsi { get; set; }

    public DateOnly TanggalStok { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Qty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public short? StatusMigrasi { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }
}
