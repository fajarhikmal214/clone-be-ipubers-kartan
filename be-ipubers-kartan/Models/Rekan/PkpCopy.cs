using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PkpCopy")]
[Index("KodeRetailer", "NoPkp", "IdKecamatan", Name = "UK_PkpCopy", IsUnique = true)]
public partial class PkpCopy
{
    [Key]
    [StringLength(128)]
    public string Id { get; set; } = null!;

    [StringLength(4)]
    public string? KodeProdusen { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? KodeDistributor { get; set; }

    [StringLength(12)]
    public string KodeRetailer { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [StringLength(12)]
    public string? NoF5 { get; set; }

    [StringLength(13)]
    public string NoPkp { get; set; } = null!;

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

    [ForeignKey("IdKecamatan")]
    [InverseProperty("PkpCopies")]
    public virtual MasterKecamatan? IdKecamatanNavigation { get; set; }

    [ForeignKey("KodeDistributor")]
    [InverseProperty("PkpCopies")]
    public virtual Distributor? KodeDistributorNavigation { get; set; }

    [ForeignKey("KodeProdusen")]
    [InverseProperty("PkpCopies")]
    public virtual Produsen? KodeProdusenNavigation { get; set; }

    [ForeignKey("KodeRetailer")]
    [InverseProperty("PkpCopies")]
    public virtual Retailer KodeRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdPkpNavigation")]
    public virtual ICollection<PkpDetailCopy> PkpDetailCopies { get; set; } = new List<PkpDetailCopy>();
}
