using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

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

    [StringLength(200)]
    [Unicode(false)]
    public string Subjek { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? IsiPesan { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Kepada { get; set; } = null!;

    public int Saluran { get; set; }

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
}
