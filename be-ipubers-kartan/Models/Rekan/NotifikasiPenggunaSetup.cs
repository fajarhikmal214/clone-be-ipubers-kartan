using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Template atau setup untuk NotifikasiPengguna
/// </summary>
[Table("NotifikasiPenggunaSetup")]
[Index("Id", Name = "NotifikasiPenggunaSetup_Id_uindex", IsUnique = true)]
public partial class NotifikasiPenggunaSetup
{
    [Key]
    [StringLength(128)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Subjek { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? IsiPesan { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Kepada { get; set; } = null!;

    public int Saluran { get; set; }

    public int Status { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Topik { get; set; }
}
