using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ProdusenRegion")]
public partial class ProdusenRegion
{
    /// <summary>
    /// Kode Region
    /// </summary>
    [Key]
    [StringLength(6)]
    public string Kode { get; set; } = null!;

    /// <summary>
    /// Kode Produsen
    /// </summary>
    [StringLength(4)]
    public string? Produsen { get; set; }

    public int Tahun { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal TargetGmv { get; set; }

    [ForeignKey("Produsen")]
    [InverseProperty("ProdusenRegions")]
    public virtual Produsen? ProdusenNavigation { get; set; }
}
