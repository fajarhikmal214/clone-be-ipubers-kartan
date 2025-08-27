using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class DistributorDbdist
{
    [StringLength(15)]
    [Unicode(false)]
    public string Kode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Owner { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Narahubung { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? NoTelp { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Alamat { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Npwp { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Kecamatan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ShortCode { get; set; }
}
