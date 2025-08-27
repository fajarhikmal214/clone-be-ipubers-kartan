using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("Spjb", Schema = "dbo_master")]
[Index("NoSpjb", Name = "KEY_Spjb_NoSpjb", IsUnique = true)]
public partial class Spjb
{
    [Key]
    public int Id { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? NoSpjb { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int Tahun { get; set; }

    [StringLength(4)]
    public string Produsen { get; set; } = null!;

    public short Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("Spjbs")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [ForeignKey("Produsen")]
    [InverseProperty("Spjbs")]
    public virtual Produsen ProdusenNavigation { get; set; } = null!;

    [InverseProperty("IdSpjbNavigation")]
    public virtual ICollection<SpjbDetail> SpjbDetails { get; set; } = new List<SpjbDetail>();
}
