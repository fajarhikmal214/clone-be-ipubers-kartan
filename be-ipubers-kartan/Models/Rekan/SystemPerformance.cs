using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("system_performances")]
[Index("ConnectionId", "CreatedAt", Name = "idx_system_performances_on_connection_id_and_created_at")]
public partial class SystemPerformance
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("total_cpu")]
    public long TotalCpu { get; set; }

    [Column("free_cpu")]
    public double FreeCpu { get; set; }

    [Column("connection_id")]
    public int ConnectionId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("total_mem")]
    public long TotalMem { get; set; }

    [Column("free_mem")]
    public long FreeMem { get; set; }

    [Column("total_swap")]
    public long TotalSwap { get; set; }

    [Column("free_swap")]
    public long FreeSwap { get; set; }
}
