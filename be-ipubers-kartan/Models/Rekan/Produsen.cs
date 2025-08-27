using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Produsen")]
public partial class Produsen
{
    [Key]
    [StringLength(4)]
    public string Code { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ShortName { get; set; }

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

    [InverseProperty("KodeProdusenNavigation")]
    public virtual ICollection<PkpCopy> PkpCopies { get; set; } = new List<PkpCopy>();

    [InverseProperty("KodeProdusenNavigation")]
    public virtual ICollection<Pkp> Pkps { get; set; } = new List<Pkp>();

    [InverseProperty("ProdusenNavigation")]
    public virtual ICollection<ProdusenRegion> ProdusenRegions { get; set; } = new List<ProdusenRegion>();
}
