using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// untuk Receipt &amp; PO
/// </summary>
[Table("Pembelian")]
[Index("NoNota", Name = "Pembelian_NoNota_uindex", IsUnique = true)]
public partial class Pembelian
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalNota { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalTerimaBarang { get; set; }

    public int IdDistributorRetailer { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NoInvoice { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? AlamatPengiriman { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? AlamatLong { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? AlamatLat { get; set; }

    public int Status { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    public int Source { get; set; }

    [StringLength(21)]
    [Unicode(false)]
    public string? NoReferensi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NomorPemesanan { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("Pembelians")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdPembelianNavigation")]
    public virtual ICollection<PembelianProdukRetailer> PembelianProdukRetailers { get; set; } = new List<PembelianProdukRetailer>();
}
