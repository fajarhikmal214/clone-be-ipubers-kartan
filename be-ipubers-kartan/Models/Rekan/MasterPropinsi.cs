using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterPropinsi")]
public partial class MasterPropinsi
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [InverseProperty("IdPropNavigation")]
    public virtual ICollection<MasterKabupaten> MasterKabupatens { get; set; } = new List<MasterKabupaten>();

    [InverseProperty("IdPropNavigation")]
    public virtual ICollection<ProvinsiPiloting> ProvinsiPilotings { get; set; } = new List<ProvinsiPiloting>();
}
