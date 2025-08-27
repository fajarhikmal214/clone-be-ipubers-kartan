using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("WcmSjDetail")]
public partial class WcmSjDetail
{
    [Key]
    public int Id { get; set; }

    public int IdSj { get; set; }

    public int IdPkp { get; set; }

    [StringLength(1)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    public Guid Uuid { get; set; }

    [StringLength(128)]
    public string? IdJob { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncDate { get; set; }

    [ForeignKey("IdSj")]
    [InverseProperty("WcmSjDetails")]
    public virtual WcmSj IdSjNavigation { get; set; } = null!;
}
