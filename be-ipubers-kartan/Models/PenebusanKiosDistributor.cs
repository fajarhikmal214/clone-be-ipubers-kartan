using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenebusanKiosDistributor", Schema = "dbo_tebus")]
[Index("Nomor", Name = "KEY_PenebusanKiosDistributor_Nomor", IsUnique = true)]
public partial class PenebusanKiosDistributor
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string IdKecamatan { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string DistributorId { get; set; } = null!;

    public int AlamatId { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? AlamatText { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public short Status { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string Nomor { get; set; } = null!;

    /// <summary>
    /// Tanggal ketika kios mulai melakukan order
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime TanggalTebus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalExpired { get; set; }

    public int? IdPajak { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? AlasanDitolak { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalPembatalan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalInput { get; set; }

    [ForeignKey("AlamatId")]
    [InverseProperty("PenebusanKiosDistributors")]
    public virtual AlamatKio Alamat { get; set; } = null!;

    [ForeignKey("DistributorId")]
    [InverseProperty("PenebusanKiosDistributors")]
    public virtual Distributor Distributor { get; set; } = null!;

    [ForeignKey("IdKecamatan")]
    [InverseProperty("PenebusanKiosDistributors")]
    public virtual MasterKecamatan IdKecamatanNavigation { get; set; } = null!;

    [ForeignKey("IdPajak")]
    [InverseProperty("PenebusanKiosDistributors")]
    public virtual TarifPajak? IdPajakNavigation { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("PenebusanKiosDistributors")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdPenebusanNavigation")]
    public virtual PenebusanKiosDistributorPembayaran? PenebusanKiosDistributorPembayaran { get; set; }

    [InverseProperty("IdPenebusanNavigation")]
    public virtual ICollection<PenebusanKiosDistributorPembayaranDetail> PenebusanKiosDistributorPembayaranDetails { get; set; } = new List<PenebusanKiosDistributorPembayaranDetail>();

    [InverseProperty("IdPenebusanNavigation")]
    public virtual ICollection<PenebusanKiosDistributorProduk> PenebusanKiosDistributorProduks { get; set; } = new List<PenebusanKiosDistributorProduk>();

    [InverseProperty("IdPenebusanKiosDistributorNavigation")]
    public virtual ICollection<PenebusanProdukRetailerAlokasi> PenebusanProdukRetailerAlokasis { get; set; } = new List<PenebusanProdukRetailerAlokasi>();

    [InverseProperty("IdPenebusanKiosDistributorNavigation")]
    public virtual ICollection<Pengiriman> Pengirimen { get; set; } = new List<Pengiriman>();
}
