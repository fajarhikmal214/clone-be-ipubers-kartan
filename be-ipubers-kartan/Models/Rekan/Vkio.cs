using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class Vkio
{
    [StringLength(12)]
    public string Kode { get; set; } = null!;

    [StringLength(200)]
    public string Nama { get; set; } = null!;

    [StringLength(250)]
    public string Alamat { get; set; } = null!;

    [StringLength(50)]
    public string? NoTelp { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? KecamatanId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? KabupatenId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProvinsiId { get; set; }
}
