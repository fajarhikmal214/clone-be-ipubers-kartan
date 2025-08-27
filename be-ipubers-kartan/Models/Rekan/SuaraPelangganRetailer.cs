using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Suara pelanggan / keluhan yang disubmit oleh Kios/Pelanggan
/// </summary>
[Table("SuaraPelangganRetailer")]
[Index("IdRetailer", "IdSuaraPelanggan", "Tanggal", Name = "SuaraPelangganRetailer_IdRetailer_IdSuaraPelanggan_Tanggal_index")]
[Index("Id", Name = "SuaraPelangganRetailer_Id_uindex", IsUnique = true)]
public partial class SuaraPelangganRetailer
{
    [Key]
    public int Id { get; set; }

    public int IdSuaraPelanggan { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(8)]
    [Unicode(false)]
    public string? NoSuaraKeluhan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Tanggal { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Judul { get; set; } = null!;

    [StringLength(1000)]
    [Unicode(false)]
    public string Deskripsi { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Dokumentasi1 { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Dokumentasi2 { get; set; }

    public int Status { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("SuaraPelangganRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [ForeignKey("IdSuaraPelanggan")]
    [InverseProperty("SuaraPelangganRetailers")]
    public virtual SuaraPelanggan IdSuaraPelangganNavigation { get; set; } = null!;

    [InverseProperty("IdSuaraPelangganRetailerNavigation")]
    public virtual ICollection<TanggapanSuaraPelangganRetailer> TanggapanSuaraPelangganRetailers { get; set; } = new List<TanggapanSuaraPelangganRetailer>();
}
