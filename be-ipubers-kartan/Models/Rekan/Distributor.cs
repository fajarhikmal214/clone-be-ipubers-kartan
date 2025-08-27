using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Distributor")]
public partial class Distributor
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string KodeDistributor { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string NamaDistributor { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Owner { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Narahubung { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string NoTelp { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string Alamat { get; set; } = null!;

    [Column("NPWP")]
    [StringLength(25)]
    [Unicode(false)]
    public string Npwp { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string? Catatan { get; set; }

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

    [InverseProperty("KodeDistributorNavigation")]
    public virtual ICollection<PkpCopy> PkpCopies { get; set; } = new List<PkpCopy>();

    [InverseProperty("KodeDistributorNavigation")]
    public virtual ICollection<Pkp> Pkps { get; set; } = new List<Pkp>();
}
