using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("ProdukRetailer")]
[Index("KodeProduk", "IdRetailer", "JenisProduk", Name = "IX_ProdukRetailer", IsUnique = true)]
[Index("IdRetailer", "NamaProduk", Name = "IX_ProdukRetailer_1", IsUnique = true)]
public partial class ProdukRetailer
{
    [Key]
    public int Id { get; set; }

    public int? IdKatalog { get; set; }

    public int IdKategori { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? KodeDistributorRetailer { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string NamaProduk { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    public int Satuan { get; set; }

    public int StatusProduk { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string JenisProduk { get; set; } = null!;

    public double? Stok { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? NilaiUnit { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Barcode { get; set; }

    public double? MinimalJmlStok { get; set; }

    [Column("isNotifStok")]
    public bool? IsNotifStok { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public int? QtyKemasan { get; set; }

    [ForeignKey("IdKatalog")]
    [InverseProperty("ProdukRetailers")]
    public virtual KatalogProduk? IdKatalogNavigation { get; set; }

    [ForeignKey("IdKategori")]
    [InverseProperty("ProdukRetailers")]
    public virtual KategoriProdukRetailer IdKategoriNavigation { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("ProdukRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<PembelianPoktanProduk> PembelianPoktanProduks { get; set; } = new List<PembelianPoktanProduk>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<PenebusanKiosDistributorProduk> PenebusanKiosDistributorProduks { get; set; } = new List<PenebusanKiosDistributorProduk>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<PenebusanProdukRetailerAlokasi> PenebusanProdukRetailerAlokasis { get; set; } = new List<PenebusanProdukRetailerAlokasi>();

    [InverseProperty("ProdukRetailer")]
    public virtual ICollection<PenebusanProdukRetailer> PenebusanProdukRetailers { get; set; } = new List<PenebusanProdukRetailer>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<PengirimanProduk> PengirimanProduks { get; set; } = new List<PengirimanProduk>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<PenjualanProdukRetailerAlokasi> PenjualanProdukRetailerAlokasis { get; set; } = new List<PenjualanProdukRetailerAlokasi>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<PenjualanProdukRetailerDump> PenjualanProdukRetailerDumps { get; set; } = new List<PenjualanProdukRetailerDump>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<PenjualanProdukRetailer> PenjualanProdukRetailers { get; set; } = new List<PenjualanProdukRetailer>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<ProdukRetailerGambar> ProdukRetailerGambars { get; set; } = new List<ProdukRetailerGambar>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<ProdukRetailerHarga> ProdukRetailerHargas { get; set; } = new List<ProdukRetailerHarga>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<ProdukRetailerLog> ProdukRetailerLogs { get; set; } = new List<ProdukRetailerLog>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<ProdukRetailerStok> ProdukRetailerStoks { get; set; } = new List<ProdukRetailerStok>();

    [InverseProperty("ProdukRetailer")]
    public virtual ICollection<ProdukRetailerTarget> ProdukRetailerTargets { get; set; } = new List<ProdukRetailerTarget>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<RetailerStok> RetailerStoks { get; set; } = new List<RetailerStok>();

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();

    [ForeignKey("Satuan")]
    [InverseProperty("ProdukRetailers")]
    public virtual SatuanProdukRetailer SatuanNavigation { get; set; } = null!;

    [InverseProperty("IdProdukRetailerNavigation")]
    public virtual ICollection<SpjbDetail> SpjbDetails { get; set; } = new List<SpjbDetail>();
}
