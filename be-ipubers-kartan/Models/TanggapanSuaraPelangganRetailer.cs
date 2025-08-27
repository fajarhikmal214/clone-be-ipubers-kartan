using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// Tanggapan atas Suara Pelanggan
/// </summary>
[Table("TanggapanSuaraPelangganRetailer")]
[Index("CreatedAt", "Tanggal", Name = "TanggapanSuaraPelangganRetailer_CreatedAt_Tanggal_index")]
[Index("Id", Name = "TanggapanSuaraPelangganRetailer_Id_uindex", IsUnique = true)]
public partial class TanggapanSuaraPelangganRetailer
{
    [Key]
    public int Id { get; set; }

    public int IdSuaraPelangganRetailer { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Tanggal { get; set; }

    [Column(TypeName = "text")]
    public string Tanggapan { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdSuaraPelangganRetailer")]
    [InverseProperty("TanggapanSuaraPelangganRetailers")]
    public virtual SuaraPelangganRetailer IdSuaraPelangganRetailerNavigation { get; set; } = null!;
}
