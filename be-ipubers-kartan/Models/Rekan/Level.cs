using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Level")]
[Index("Id", Name = "Level_Id_uindex", IsUnique = true)]
[Index("Nama", Name = "Level_Nama_uindex", IsUnique = true)]
public partial class Level
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    [Column("XP")]
    public int Xp { get; set; }

    public int Point { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Logo { get; set; } = null!;

    public DateOnly ValidStart { get; set; }

    public DateOnly ValidEnd { get; set; }

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [InverseProperty("IdLevelNavigation")]
    public virtual ICollection<LevelBenefit> LevelBenefits { get; set; } = new List<LevelBenefit>();

    [InverseProperty("IdLevelNavigation")]
    public virtual ICollection<LevelRetailer> LevelRetailers { get; set; } = new List<LevelRetailer>();
}
