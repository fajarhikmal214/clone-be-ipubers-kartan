using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PantauStokStatusLog")]
public partial class PantauStokStatusLog
{
    [Key]
    public int Id { get; set; }

    public int? PantauStokId { get; set; }

    public bool Status { get; set; }

    [StringLength(100)]
    public string? Note { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(256)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("PantauStokId")]
    [InverseProperty("PantauStokStatusLogs")]
    public virtual PantauStok? PantauStok { get; set; }
}
