using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Riwayat pelanggan mendapatkan poin
/// </summary>
[Table("PelangganRetailerPoin")]
public partial class PelangganRetailerPoin
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string KodePelangganRetailer { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string NoHp { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string NoReferensi { get; set; } = null!;

    public int Poin { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Keterangan { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TanggalPoin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalExpired { get; set; }

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    /// <summary>
    /// 1=tambahpoin, 2=kurangpoin
    /// </summary>
    public int TipePoin { get; set; }

    [ForeignKey("KodePelangganRetailer")]
    [InverseProperty("PelangganRetailerPoins")]
    public virtual PelangganRetailer KodePelangganRetailerNavigation { get; set; } = null!;
}
