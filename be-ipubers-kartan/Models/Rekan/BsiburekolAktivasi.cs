using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// table untuk data aktivasi burekol
/// </summary>
[Table("BSIBurekolAktivasi")]
[Index("Id", Name = "BSIBurekolAktivasi_Id_uindex", IsUnique = true)]
[Index("Id", Name = "BSIBurekolAktivasi_pk", IsUnique = true)]
public partial class BsiburekolAktivasi
{
    [Key]
    public int Id { get; set; }

    [Column("NIK")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TglLahir { get; set; }

    public bool StatusAktivasi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TglAktivasi { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Keterangan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string KodeKios { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? KodeAgen { get; set; }

    [Column("PIN")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Pin { get; set; }
}
