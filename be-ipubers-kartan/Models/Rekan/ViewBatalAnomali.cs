using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class ViewBatalAnomali
{
    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalNota { get; set; }

    [Column("totalbatal")]
    public double? Totalbatal { get; set; }

    [Column("totalsukses")]
    public double? Totalsukses { get; set; }

    [StringLength(12)]
    public string? RetailerSukses { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NotaSukses { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalSukses { get; set; }
}
