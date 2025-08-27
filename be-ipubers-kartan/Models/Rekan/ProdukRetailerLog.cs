using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Log jika ada perubahan data pada ProdukRetailer
/// </summary>
[Table("ProdukRetailerLog")]
public partial class ProdukRetailerLog
{
    [Key]
    public int Id { get; set; }

    public int IdProdukRetailer { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string NamaProduk { get; set; } = null!;

    public int IdKategori { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? KodeDistributor { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Barcode { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    public int Satuan { get; set; }

    public int StatusProduk { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string JenisProduk { get; set; } = null!;

    public double? Stok { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal NilaiUnit { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Action { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("ProdukRetailerLogs")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
