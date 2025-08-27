using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("Pengiriman", Schema = "dbo_tebus")]
[Index("NoPengiriman", "UniqCode", "IdPenebusanKiosDistributor", "IdPenebusan", Name = "KEY_Pengiriman", IsUnique = true)]
public partial class Pengiriman
{
    [Key]
    public int Id { get; set; }

    public int? IdPenebusanKiosDistributor { get; set; }

    public long? IdPenebusan { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? NoPengiriman { get; set; }

    public short Status { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaEkspeditur { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaSopir { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TelpSopir { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Nopol { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? JenisKendaraan { get; set; }

    [Unicode(false)]
    public string? BuktiPengiriman { get; set; }

    [Column("TanggalPKP")]
    public DateOnly? TanggalPkp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalSuratJalan { get; set; }

    [StringLength(4)]
    public string? Produsen { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IdDistributor { get; set; }

    public int? IdGudang { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Asal { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

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

    [Column(TypeName = "datetime")]
    public DateTime? ReceivedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalTerima { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalFoto { get; set; }

    public double? LatitudeTerima { get; set; }

    public double? LongitudeTerima { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string UniqCode { get; set; } = null!;

    [ForeignKey("IdDistributor")]
    [InverseProperty("Pengirimen")]
    public virtual Distributor? IdDistributorNavigation { get; set; }

    [ForeignKey("IdGudang")]
    [InverseProperty("Pengirimen")]
    public virtual GudangWilayah? IdGudangNavigation { get; set; }

    [ForeignKey("IdKecamatan")]
    [InverseProperty("Pengirimen")]
    public virtual MasterKecamatan? IdKecamatanNavigation { get; set; }

    [ForeignKey("IdPenebusanKiosDistributor")]
    [InverseProperty("Pengirimen")]
    public virtual PenebusanKiosDistributor? IdPenebusanKiosDistributorNavigation { get; set; }

    [ForeignKey("IdPenebusan")]
    [InverseProperty("Pengirimen")]
    public virtual Penebusan? IdPenebusanNavigation { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("Pengirimen")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdPengirimanNavigation")]
    public virtual ICollection<PengirimanHistory> PengirimanHistories { get; set; } = new List<PengirimanHistory>();

    [InverseProperty("IdPengirimanNavigation")]
    public virtual ICollection<PengirimanProduk> PengirimanProduks { get; set; } = new List<PengirimanProduk>();

    [InverseProperty("IdPengirimanNavigation")]
    public virtual ICollection<PengirimanTerimaBarang> PengirimanTerimaBarangs { get; set; } = new List<PengirimanTerimaBarang>();

    [ForeignKey("Produsen")]
    [InverseProperty("Pengirimen")]
    public virtual Produsen? ProdusenNavigation { get; set; }
}
