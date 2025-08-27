using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ProvinsiPiloting")]
public partial class ProvinsiPiloting
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string IdProp { get; set; } = null!;

    public int IsActive { get; set; }

    [ForeignKey("IdProp")]
    [InverseProperty("ProvinsiPilotings")]
    public virtual MasterPropinsi IdPropNavigation { get; set; } = null!;
}
