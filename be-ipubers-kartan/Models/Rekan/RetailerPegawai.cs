using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RetailerPegawai")]
[Index("IdRetailer", "KodePegawai", Name = "IX_RetailerPegawai", IsUnique = true)]
public partial class RetailerPegawai
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string KodePegawai { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string NamaPegawai { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? NoHp { get; set; }

    [StringLength(200)]
    public string? Email { get; set; }

    public int? TipePegawai { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string NoPrefix { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Username { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("RetailerPegawais")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
