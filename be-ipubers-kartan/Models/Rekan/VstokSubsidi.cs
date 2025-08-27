using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class VstokSubsidi
{
    [StringLength(12)]
    public string KodeKios { get; set; } = null!;

    [StringLength(200)]
    public string NamaKios { get; set; } = null!;

    public int? StatusKios { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Propinsi { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdPropinsi { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Kabupaten { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKabupaten { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Kecamatan { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

    public double? Urea { get; set; }

    [Column("NPK")]
    public double? Npk { get; set; }

    [Column("NPKFormula")]
    public double? Npkformula { get; set; }

    public double? Organik { get; set; }

    public double? OrganikCair { get; set; }

    [Column("SP36")]
    public double? Sp36 { get; set; }

    [Column("ZA")]
    public double? Za { get; set; }
}
