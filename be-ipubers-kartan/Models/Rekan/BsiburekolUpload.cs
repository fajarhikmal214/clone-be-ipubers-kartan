using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// table untuk menampung sementara data Burekol yang dikirimkan oleh BSI
/// </summary>
[Table("_BSIBurekolUpload")]
[Index("Id", Name = "_BSIBurekolUpload_Id_uindex", IsUnique = true)]
public partial class BsiburekolUpload
{
    [Key]
    public int Id { get; set; }

    [Column("NIK")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string KodeKios { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string NamaPetani { get; set; } = null!;

    public int Urea { get; set; }

    [Column("NPK")]
    public int Npk { get; set; }

    [Column("ZA")]
    public int Za { get; set; }

    [Column("SP36")]
    public int Sp36 { get; set; }

    public int Organik { get; set; }

    public int NpkFormula { get; set; }

    public int OrganikCair { get; set; }

    public int Tahun { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Komoditas { get; set; }

    public double? LuasTanam { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TglLahir { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? KodeDesa { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? KelompokTani { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NoRekening { get; set; } = null!;

    public int Tipe { get; set; }

    public int Status { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Keterangan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    public int StatusRdkk { get; set; }

    public int? PoktanId { get; set; }

    /// <summary>
    /// Kode unik yang akan tampil pada virtual card
    /// </summary>
    [StringLength(50)]
    [Unicode(false)]
    public string? IdPetani { get; set; }
}
