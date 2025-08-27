using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("_migKartuTani")]
public partial class MigKartuTani
{
    [StringLength(30)]
    [Unicode(false)]
    public string? AgentId { get; set; }

    [StringLength(255)]
    public string? NamaKios { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalAwal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalAkhir { get; set; }

    [Column("NPK_Volume")]
    public double? NpkVolume { get; set; }

    [Column("Organik_Volume")]
    public double? OrganikVolume { get; set; }

    [Column("SP36_Volume")]
    public double? Sp36Volume { get; set; }

    [Column("Urea_Volume")]
    public double? UreaVolume { get; set; }

    [Column("ZA_Volume")]
    public double? ZaVolume { get; set; }

    [Column("NPK_Amount")]
    public double? NpkAmount { get; set; }

    [Column("Organik_Amount")]
    public double? OrganikAmount { get; set; }

    [Column("SP36_Amount")]
    public double? Sp36Amount { get; set; }

    [Column("Urea_Amount")]
    public double? UreaAmount { get; set; }

    [Column("ZA_Amount")]
    public double? ZaAmount { get; set; }

    [StringLength(255)]
    public string? Bank { get; set; }
}
