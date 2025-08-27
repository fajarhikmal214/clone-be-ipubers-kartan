using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("KartuTaniAgent")]
public partial class KartuTaniAgent
{
    [Key]
    [StringLength(30)]
    [Unicode(false)]
    public string AgentId { get; set; } = null!;

    [StringLength(12)]
    public string? RetailerCode { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? NamaKios { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Bank { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(10)]
    public string? UpdatedBy { get; set; }

    [InverseProperty("Agent")]
    public virtual ICollection<KartuTaniTransaksi> KartuTaniTransaksis { get; set; } = new List<KartuTaniTransaksi>();
}
