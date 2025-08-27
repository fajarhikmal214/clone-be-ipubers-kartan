using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class VDataLaporStok
{
    [StringLength(12)]
    public string Code { get; set; } = null!;

    [StringLength(200)]
    public string NamaKios { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Kec { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? KabKota { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Propinsi { get; set; } = null!;

    [Column("tglAktivasi", TypeName = "datetime")]
    public DateTime? TglAktivasi { get; set; }

    [Column("StatusPSO")]
    public int? StatusPso { get; set; }

    [Column("cntLapor")]
    public int? CntLapor { get; set; }

    [Column("terakhirLapor", TypeName = "datetime")]
    public DateTime? TerakhirLapor { get; set; }
}
