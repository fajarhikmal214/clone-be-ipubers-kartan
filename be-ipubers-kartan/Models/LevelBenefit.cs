using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LevelBenefit")]
[Index("Id", Name = "LevelBenefit_Id_uindex", IsUnique = true)]
public partial class LevelBenefit
{
    [Key]
    public int Id { get; set; }

    public int IdLevel { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Benefit { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    public int Urutan { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("IdLevel")]
    [InverseProperty("LevelBenefits")]
    public virtual Level IdLevelNavigation { get; set; } = null!;
}
