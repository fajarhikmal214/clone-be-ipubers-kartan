using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// MappingKodeRetailer
/// </summary>
[Table("RetailerMapping")]
[Index("IdRetailer", Name = "RetailerMapping_IdRetailer_uindex", IsUnique = true)]
[Index("MidBri", Name = "RetailerMapping_MID_BRI_uindex", IsUnique = true)]
public partial class RetailerMapping
{
    [Key]
    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [Column("MID_BRI")]
    [StringLength(20)]
    [Unicode(false)]
    public string? MidBri { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("RetailerMapping")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
