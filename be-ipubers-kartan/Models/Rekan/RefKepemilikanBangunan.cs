using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RefKepemilikanBangunan")]
public partial class RefKepemilikanBangunan
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Label { get; set; }

    [InverseProperty("KepemilikanBangunanNavigation")]
    public virtual ICollection<PendaftaranRetailer> PendaftaranRetailers { get; set; } = new List<PendaftaranRetailer>();
}
