using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("KartuTaniTransaksi")]
[Index("AgentId", "ProductCode", Name = "KartuTaniTransaksi_AgentId_uindex", IsUnique = true)]
public partial class KartuTaniTransaksi
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string AgentId { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Amount { get; set; }

    public double Volume { get; set; }

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

    [ForeignKey("AgentId")]
    [InverseProperty("KartuTaniTransaksis")]
    public virtual KartuTaniAgent Agent { get; set; } = null!;
}
