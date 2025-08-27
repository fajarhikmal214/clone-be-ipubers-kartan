using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("WcmPkpJob")]
public partial class WcmPkpJob
{
    [Key]
    [StringLength(128)]
    public string Id { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? StartedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndedAt { get; set; }

    public bool? Success { get; set; }

    [Unicode(false)]
    public string? Desc { get; set; }
}
