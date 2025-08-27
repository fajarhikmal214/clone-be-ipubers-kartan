using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// table master untuk daftar keluhan
/// </summary>
[Table("SuaraPelanggan")]
[Index("Deskripsi", Name = "SuaraPelanggan_Deskripsi_uindex", IsUnique = true)]
[Index("Id", Name = "SuaraPelanggan_Id_uindex", IsUnique = true)]
public partial class SuaraPelanggan
{
    [Key]
    public int Id { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Deskripsi { get; set; } = null!;

    public int JenisMasalah { get; set; }

    public int Status { get; set; }

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

    [InverseProperty("IdSuaraPelangganNavigation")]
    public virtual ICollection<SuaraPelangganRetailer> SuaraPelangganRetailers { get; set; } = new List<SuaraPelangganRetailer>();
}
