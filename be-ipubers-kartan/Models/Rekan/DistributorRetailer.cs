using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("DistributorRetailer")]
public partial class DistributorRetailer
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? KodeDistributor { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NamaDistributor { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Narahubung { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? NoTelp { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Alamat { get; set; }

    [Column("NPWP")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Npwp { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    [StringLength(15)]
    public string? IdDistributor { get; set; }

    public int Status { get; set; }

    public int? Jenis { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("DistributorRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
