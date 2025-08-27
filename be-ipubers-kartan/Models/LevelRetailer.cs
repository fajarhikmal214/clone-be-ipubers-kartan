using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LevelRetailer")]
[Index("Id", Name = "RetailerLevel_Id_uindex", IsUnique = true)]
public partial class LevelRetailer
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int IdLevel { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalPencapaian { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdLevel")]
    [InverseProperty("LevelRetailers")]
    public virtual Level IdLevelNavigation { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("LevelRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
