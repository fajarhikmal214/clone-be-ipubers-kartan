using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

public partial class KementanRetailer
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string PihcCode { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string SubDistrictCode { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("isActive")]
    public int? IsActive { get; set; }

    [StringLength(10)]
    public string? PihcCodeParent { get; set; }

    [InverseProperty("Retailer")]
    public virtual ICollection<SubmissionsSimluhtan> SubmissionsSimluhtans { get; set; } = new List<SubmissionsSimluhtan>();
}
