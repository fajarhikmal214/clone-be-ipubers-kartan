using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

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

    [InverseProperty("Distributor")]
    public virtual ICollection<PenebusanKiosDistributor> PenebusanKiosDistributors { get; set; } = new List<PenebusanKiosDistributor>();

    [InverseProperty("IdDistributorNavigation")]
    public virtual ICollection<Pengiriman> Pengirimen { get; set; } = new List<Pengiriman>();

    [InverseProperty("Distriutor")]
    public virtual ICollection<Spjb1> Spjb1s { get; set; } = new List<Spjb1>();

    [InverseProperty("IdDistributorNavigation")]
    public virtual ICollection<SpjbKiosDistributor> SpjbKiosDistributors { get; set; } = new List<SpjbKiosDistributor>();
}
