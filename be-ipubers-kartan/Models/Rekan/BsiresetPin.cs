using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Log untuk reset PIN
/// </summary>
[Table("BSIResetPIN")]
[Index("Id", Name = "BSIResetPIN_Id_uindex", IsUnique = true)]
[Index("Id", Name = "BSIResetPIN_Id_uindex_2", IsUnique = true)]
public partial class BsiresetPin
{
    [Column("NIK")]
    [StringLength(16)]
    [Unicode(false)]
    public string? Nik { get; set; }

    [Column("PIN")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Pin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalReset { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Key]
    public int Id { get; set; }
}
