using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PkpHistory")]
public partial class PkpHistory
{
    [Key]
    [StringLength(128)]
    public string Id { get; set; } = null!;

    [StringLength(128)]
    public string? IdPkp { get; set; }

    [StringLength(4)]
    public string? KodeProdusen { get; set; }

    [StringLength(10)]
    public string? KodeDistributor { get; set; }

    [StringLength(12)]
    public string? KodeRetailer { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [StringLength(12)]
    public string? NoF5 { get; set; }

    [StringLength(20)]
    public string? NoPkp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReceivedDate { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public int? SjId { get; set; }

    public Guid? SjUuid { get; set; }

    public int? SjIdDetail { get; set; }

    [StringLength(13)]
    public string? SjNo { get; set; }

    [StringLength(1)]
    public string? SjStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SjCreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SjUpdatedAt { get; set; }
}
