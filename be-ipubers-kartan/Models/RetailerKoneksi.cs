using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("RetailerKoneksi")]
[Index("IdRetailer", Name = "Index_RetailerKoneksi_IdRetailer")]
public partial class RetailerKoneksi
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public double UploadSpeed { get; set; }

    public double DownloadSpeed { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Provider { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalTest { get; set; }

    [Column(TypeName = "decimal(8, 6)")]
    public decimal Lat { get; set; }

    [Column(TypeName = "decimal(9, 6)")]
    public decimal Long { get; set; }

    [Unicode(false)]
    public string? Catatan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string TipeKoneksi { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string? TipeJaringan { get; set; }

    public double DownloadLatency { get; set; }

    public double UploadLatency { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string DeviceModel { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string DeviceName { get; set; } = null!;

    public int Ram { get; set; }

    public int Storage { get; set; }

    [Column("OSVersion")]
    [StringLength(20)]
    [Unicode(false)]
    public string Osversion { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("RetailerKoneksis")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
