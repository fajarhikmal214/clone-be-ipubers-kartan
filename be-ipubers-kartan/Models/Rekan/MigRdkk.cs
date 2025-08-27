using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("_migRdkk")]
[Index("KodeKios", Name = "NCI_KodeKios")]
[Index("Id", Name = "_migRdkk_Id_uindex", IsUnique = true)]
[Index("KodeKios", "Ktp", Name = "_migRdkk_KodeKios_KTP_index")]
[Index("NamaPetani", Name = "_migRdkk_NamaPetani_index")]
public partial class MigRdkk
{
    [StringLength(255)]
    public string? NamaPenyuluh { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? KodeDesa { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string KodeKios { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaKios { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Gapoktan { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaPoktan { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaPetani { get; set; }

    [Column("KTP")]
    [StringLength(20)]
    [Unicode(false)]
    public string Ktp { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? TempatLahir { get; set; }

    [StringLength(255)]
    public string? TanggalLahir { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NamaIbuKandung { get; set; }

    [StringLength(255)]
    public string? Alamat { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Subsektor { get; set; }

    [Column("KomoditasMT1")]
    [StringLength(100)]
    [Unicode(false)]
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

    [Column("status")]
    public int? Status { get; set; }

    [Column("fromfile")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Fromfile { get; set; }

    [Column("createdat", TypeName = "datetime")]
    public DateTime? Createdat { get; set; }

    [Column("tahun")]
    public int Tahun { get; set; }

    [Column("NPKFMT1")]
    public double? Npkfmt1 { get; set; }

    [Column("ORCRMT1")]
    public double? Orcrmt1 { get; set; }

    [Column("NPKFMT2")]
    public double? Npkfmt2 { get; set; }

    [Column("ORCRMT2")]
    public double? Orcrmt2 { get; set; }

    [Column("NPKFMT3")]
    public double? Npkfmt3 { get; set; }

    [Column("ORCRMT3")]
    public double? Orcrmt3 { get; set; }

    public int? PoktanId { get; set; }

    [Key]
    public int Id { get; set; }
}
