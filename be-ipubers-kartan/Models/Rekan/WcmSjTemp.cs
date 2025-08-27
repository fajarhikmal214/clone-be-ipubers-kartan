using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("WcmSjTemp")]
public partial class WcmSjTemp
{
    [Key]
    public int Id { get; set; }

    public Guid Uuid { get; set; }

    [StringLength(13)]
    public string? Number { get; set; }

    [StringLength(1)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(4)]
    public string KodeProdusen { get; set; } = null!;

    [StringLength(10)]
    public string KodeDistributor { get; set; } = null!;

    [StringLength(4)]
    public string KodeKabupaten { get; set; } = null!;

    [StringLength(128)]
    public string? IdJob { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncDate { get; set; }
}
