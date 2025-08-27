using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("Migrasi$")]
public partial class Migrasi
{
    [StringLength(255)]
    public string? NamaPenyuluh { get; set; }

    public double? KodeDesa { get; set; }

    [StringLength(255)]
    public string? KodeKios { get; set; }

    [StringLength(255)]
    public string? NamaKios { get; set; }

    [StringLength(255)]
    public string? Gapoktan { get; set; }

    [StringLength(255)]
    public string? NamaPoktan { get; set; }

    [StringLength(255)]
    public string? NamaPetani { get; set; }

    [Column("KTP")]
    [StringLength(255)]
    public string? Ktp { get; set; }

    [StringLength(255)]
    public string? TempatLahir { get; set; }

    [StringLength(255)]
    public string? TanggalLahir { get; set; }

    [StringLength(255)]
    public string? NamaIbuKandung { get; set; }

    [StringLength(255)]
    public string? Alamat { get; set; }

    [StringLength(255)]
    public string? Subsektor { get; set; }

    [Column("KomoditasMT1")]
    [StringLength(255)]
    public string? KomoditasMt1 { get; set; }

    [Column("LuasMT1")]
    public double? LuasMt1 { get; set; }

    [Column("UreaMT1")]
    public double? UreaMt1 { get; set; }

    [Column("SP36MT1")]
    public double? Sp36mt1 { get; set; }

    [Column("ZAMT1")]
    public double? Zamt1 { get; set; }

    [Column("NPKMT1")]
    public double? Npkmt1 { get; set; }

    [Column("ORGRMT1")]
    public double? Orgrmt1 { get; set; }

    [Column("KomoditasMT2")]
    [StringLength(255)]
    public string? KomoditasMt2 { get; set; }

    [Column("LuasMT2")]
    public double? LuasMt2 { get; set; }

    [Column("UreaMT2")]
    public double? UreaMt2 { get; set; }

    [Column("SP36MT2")]
    public double? Sp36mt2 { get; set; }

    [Column("ZAMT2")]
    public double? Zamt2 { get; set; }

    [Column("NPKMT2")]
    public double? Npkmt2 { get; set; }

    [Column("ORGRMT2")]
    public double? Orgrmt2 { get; set; }

    [Column("KomoditasMT3")]
    [StringLength(255)]
    public string? KomoditasMt3 { get; set; }

    [Column("LuasMT3")]
    public double? LuasMt3 { get; set; }

    [Column("UreaMT3")]
    public double? UreaMt3 { get; set; }

    [Column("SP36MT3")]
    public double? Sp36mt3 { get; set; }

    [Column("ZAMT3")]
    public double? Zamt3 { get; set; }

    [Column("NPKMT3")]
    public double? Npkmt3 { get; set; }

    [Column("ORGRMT3")]
    public double? Orgrmt3 { get; set; }
}
