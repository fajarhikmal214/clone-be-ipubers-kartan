using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class VlaporStokPerBulan
{
    [StringLength(12)]
    public string KodeKios { get; set; } = null!;

    [StringLength(200)]
    public string NamaKios { get; set; } = null!;

    [Column("tahun")]
    public int? Tahun { get; set; }

    [Column("bulan")]
    public int? Bulan { get; set; }

    public int? JmlLaporStok { get; set; }
}
