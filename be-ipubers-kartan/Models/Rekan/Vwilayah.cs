using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class Vwilayah
{
    [StringLength(10)]
    [Unicode(false)]
    public string KodeKecamatan { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string IdKab { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string IdPropinsi { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Kecamatan { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Kabkota { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Propinsi { get; set; } = null!;
}
