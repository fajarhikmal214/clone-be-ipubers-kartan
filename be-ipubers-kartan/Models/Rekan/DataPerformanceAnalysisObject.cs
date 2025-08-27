using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("data_performance_analysis_objects")]
[Index("ConnectionId", Name = "idx_data_performance_analysis_objects_connection_id")]
[Index("SaveTime", Name = "idx_data_performance_analysis_objects_save_time")]
[Index("SaveType", Name = "idx_data_performance_analysis_objects_save_type")]
public partial class DataPerformanceAnalysisObject
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("connection_id")]
    public int? ConnectionId { get; set; }

    [Column("object_name")]
    [StringLength(255)]
    public string? ObjectName { get; set; }

    [Column("object_type")]
    [StringLength(255)]
    public string? ObjectType { get; set; }

    [Column("wait_time")]
    public double? WaitTime { get; set; }

    [Column("save_type")]
    public int? SaveType { get; set; }

    [Column("save_time")]
    public DateTimeOffset? SaveTime { get; set; }
}
