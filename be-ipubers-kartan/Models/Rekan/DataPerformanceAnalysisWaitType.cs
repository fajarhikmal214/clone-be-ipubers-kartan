using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("data_performance_analysis_wait_types")]
[Index("SaveType", "SaveTime", "ConnectionId", Name = "idx_dpa_wait_types_savetime_conn_id_savetype")]
public partial class DataPerformanceAnalysisWaitType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("connection_id")]
    public int? ConnectionId { get; set; }

    [Column("schema_name")]
    [StringLength(255)]
    public string? SchemaName { get; set; }

    [Column("time_total")]
    public double? TimeTotal { get; set; }

    [Column("wait_type")]
    [StringLength(255)]
    public string? WaitType { get; set; }

    [Column("wait_time")]
    public double? WaitTime { get; set; }

    [Column("wait_time_percent")]
    public double? WaitTimePercent { get; set; }

    [Column("save_time")]
    public DateTimeOffset? SaveTime { get; set; }

    [Column("digest")]
    [StringLength(255)]
    public string? Digest { get; set; }

    [Column("save_type")]
    public int? SaveType { get; set; }

    [Column("backend_type")]
    [StringLength(255)]
    public string? BackendType { get; set; }
}
