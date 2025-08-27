using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// table untuk daftar notifikasi kepada pengguna melalui apps
/// </summary>
[Table("NotifikasiPengguna")]
public partial class NotifikasiPengguna
{
    [Key]
    [StringLength(128)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    /// <summary>
    /// Topik/header
    /// </summary>
    [StringLength(200)]
    [Unicode(false)]
    public string Subjek { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? IsiPesan { get; set; }

    /// <summary>
    /// bisa diisi email nohp
    /// </summary>
    [StringLength(100)]
    [Unicode(false)]
    public string Kepada { get; set; } = null!;

    /// <summary>
    /// 1-apps, 2-email, 3-nohp
    /// </summary>
    public int Saluran { get; set; }

    /// <summary>
    /// opsional jika menggunakan email, atau api lainnya
    /// </summary>
    [StringLength(250)]
    [Unicode(false)]
    public string? Response { get; set; }

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

    [StringLength(12)]
    [Unicode(false)]
    public string? IdRetailer { get; set; }

    [Column("isRead")]
    public bool? IsRead { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReadAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RedirectTo { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? Kategori { get; set; }
}
