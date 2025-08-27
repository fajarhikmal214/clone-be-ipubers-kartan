using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("custom_metrics")]
[Index("Name", Name = "idx_metric_name", IsUnique = true)]
public partial class CustomMetric
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("desc", TypeName = "text")]
    public string? Desc { get; set; }

    [Column("db_type")]
    public int? DbType { get; set; }

    [Column("connection_ids", TypeName = "text")]
    public string ConnectionIds { get; set; } = null!;

    [Column("group_ids", TypeName = "text")]
    public string GroupIds { get; set; } = null!;

    [Column("is_all_instances")]
    public bool? IsAllInstances { get; set; }

    [Column("enable")]
    public bool? Enable { get; set; }

    [Column("query", TypeName = "text")]
    public string? Query { get; set; }

    [Column("is_delta")]
    public bool? IsDelta { get; set; }

    [Column("alert_id")]
    public int? AlertId { get; set; }
}
