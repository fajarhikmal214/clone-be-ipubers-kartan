using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("MasterKecamatanbackup")]
public partial class MasterKecamatanbackup
{
    [StringLength(10)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Nama { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKab { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdWcm { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdAlokasi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }
}
