using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterKabupaten")]
public partial class MasterKabupaten
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Nama { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdProp { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [Column("isSyncKementan")]
    public bool IsSyncKementan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDateSync { get; set; }

    [ForeignKey("IdProp")]
    [InverseProperty("MasterKabupatens")]
    public virtual MasterPropinsi? IdPropNavigation { get; set; }

    [InverseProperty("IdKabupatenNavigation")]
    public virtual ICollection<KabupatenAe> KabupatenAes { get; set; } = new List<KabupatenAe>();

    [InverseProperty("IdKabNavigation")]
    public virtual ICollection<MasterKecamatan> MasterKecamatans { get; set; } = new List<MasterKecamatan>();

    [InverseProperty("IdKabNavigation")]
    public virtual ICollection<MasterTarget> MasterTargets { get; set; } = new List<MasterTarget>();
}
