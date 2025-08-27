using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Log untuk kirim settlment ke BSI
/// </summary>
[Table("BsiSettlement")]
[Index("Id", Name = "BsiSettlement_Id_uindex", IsUnique = true)]
public partial class BsiSettlement
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// tanggal cutoff
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime Tanggal { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? NamaPetani { get; set; }

    [Column("NIK")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaProduk { get; set; }

    public int Qty { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? HargaJual { get; set; }

    public int? SisaKuota { get; set; }

    /// <summary>
    /// CreatedAt di table Penjualan
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NoReferensi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UploadedAt { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? UploadedFilename { get; set; }
}
