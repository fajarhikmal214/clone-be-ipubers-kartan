using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RetailerLog")]
public partial class RetailerLog
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string Code { get; set; } = null!;

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string? Email { get; set; }

    [StringLength(200)]
    public string Owner { get; set; } = null!;

    [Column("NIK")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [Column("NPWP")]
    [StringLength(20)]
    [Unicode(false)]
    public string Npwp { get; set; } = null!;

    [StringLength(250)]
    public string Address { get; set; } = null!;

    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [Column("NoSIUP")]
    [StringLength(20)]
    [Unicode(false)]
    public string NoSiup { get; set; } = null!;

    [Column("KodeSIN")]
    [StringLength(20)]
    [Unicode(false)]
    public string KodeSin { get; set; } = null!;

    [Column("FotoNPWP")]
    [StringLength(100)]
    [Unicode(false)]
    public string FotoNpwp { get; set; } = null!;

    [Column("FotoKTP")]
    [StringLength(100)]
    [Unicode(false)]
    public string FotoKtp { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string FotoKios { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? FotoGudangKios { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [StringLength(256)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
