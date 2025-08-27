using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("WcmPkp")]
[Index("UpdatedAt", Name = "IdxWcmPkp1")]
public partial class WcmPkp
{
    [Key]
    public int Id { get; set; }

    [StringLength(4)]
    public string? KodeProdusen { get; set; }

    [StringLength(250)]
    public string? NamaProdusen { get; set; }

    [StringLength(12)]
    public string? NoF5 { get; set; }

    [StringLength(10)]
    public string? KodeDistributor { get; set; }

    [StringLength(250)]
    public string? NamaDistributor { get; set; }

    [StringLength(13)]
    public string? NoPkp { get; set; }

    [StringLength(4)]
    public string? KodePropinsi { get; set; }

    [StringLength(250)]
    public string? NamaPropinsi { get; set; }

    [StringLength(6)]
    public string? KodeKabupaten { get; set; }

    [StringLength(250)]
    public string? NamaKabupaten { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DistributionDate { get; set; }

    public int? Year { get; set; }

    public int? Month { get; set; }

    [StringLength(1)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateadAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(128)]
    public string? IdJob { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncDate { get; set; }

    [InverseProperty("IdPkpNavigation")]
    public virtual ICollection<WcmPkpDetail> WcmPkpDetails { get; set; } = new List<WcmPkpDetail>();
}
