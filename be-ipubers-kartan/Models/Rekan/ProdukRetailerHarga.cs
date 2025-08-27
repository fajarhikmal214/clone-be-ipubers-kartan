using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ProdukRetailerHarga")]
[Index("IdProdukRetailer", "TanggalAwal", "HargaJual", "TanggalAkhir", Name = "IX_ProdukRetailerHarga", IsUnique = true)]
public partial class ProdukRetailerHarga
{
    [Key]
    public int Id { get; set; }

    public int IdProdukRetailer { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal HargaJual { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal HargaBeli { get; set; }

    public double MinimumPesanan { get; set; }

    public DateOnly TanggalAwal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalAkhir { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? HargaJual2 { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? HargaJual3 { get; set; }

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("ProdukRetailerHargas")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
