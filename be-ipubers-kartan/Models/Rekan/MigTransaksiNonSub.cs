using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("_migTransaksiNonSub")]
[Index("Id", Name = "_migTransaksiNonSub_Id_uindex", IsUnique = true)]
public partial class MigTransaksiNonSub
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string KodeKios { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaKios { get; set; }

    public int Qty { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Harga { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TglTransaksi { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Keterangan { get; set; }

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MigratedAt { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? MigratedResult { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? NamaPelanggan { get; set; }

    [Column("NIK")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Nik { get; set; }
}
