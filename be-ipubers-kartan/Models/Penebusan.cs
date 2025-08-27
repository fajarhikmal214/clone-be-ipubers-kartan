using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("Penebusan", Schema = "dbo_tebus")]
[Index("NoOrder", Name = "KEY_Penebusan_NoOrder", IsUnique = true)]
public partial class Penebusan
{
    [Key]
    public long Id { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string NoOrder { get; set; } = null!;

    public int AlamatId { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? AlamatText { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KecamatanId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalOrder { get; set; }

    public short Status { get; set; }

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

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TanggalTolak { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? AlasanTolak { get; set; }

    public int IdPajak { get; set; }

    [ForeignKey("AlamatId")]
    [InverseProperty("Penebusans")]
    public virtual AlamatKio Alamat { get; set; } = null!;

    [ForeignKey("IdPajak")]
    [InverseProperty("Penebusans")]
    public virtual TarifPajak IdPajakNavigation { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("Penebusans")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [ForeignKey("KecamatanId")]
    [InverseProperty("Penebusans")]
    public virtual MasterKecamatan Kecamatan { get; set; } = null!;

    [InverseProperty("Penebusan")]
    public virtual PenebusanPembayaran? PenebusanPembayaran { get; set; }

    [InverseProperty("IdPenebusanNavigation")]
    public virtual ICollection<PenebusanPembayaranDetail> PenebusanPembayaranDetails { get; set; } = new List<PenebusanPembayaranDetail>();

    [InverseProperty("IdPenebusanNavigation")]
    public virtual ICollection<PenebusanPembayaranManual> PenebusanPembayaranManuals { get; set; } = new List<PenebusanPembayaranManual>();

    [InverseProperty("Penebusan")]
    public virtual ICollection<PenebusanProdukRetailer> PenebusanProdukRetailers { get; set; } = new List<PenebusanProdukRetailer>();

    [InverseProperty("IdPenebusanNavigation")]
    public virtual ICollection<Pengiriman> Pengirimen { get; set; } = new List<Pengiriman>();

    [InverseProperty("Penebusan")]
    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
