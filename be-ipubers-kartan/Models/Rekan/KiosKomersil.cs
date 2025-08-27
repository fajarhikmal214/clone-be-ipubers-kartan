using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class KiosKomersil
{
    [StringLength(12)]
    public string KodeKios { get; set; } = null!;

    [StringLength(200)]
    public string NamaKios { get; set; } = null!;

    public double? LokasiLat { get; set; }

    public double? LokasiLong { get; set; }

    [StringLength(250)]
    public string Address { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? FotoTokoDalam { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FotoTokoDepan { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? LuasKios { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? KodeKabupaten { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? KodePropinsi { get; set; }

    [StringLength(8000)]
    [Unicode(false)]
    public string? KomoditasUtama { get; set; }
}
