using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("data_performance_analyses")]
[Index("SaveTime", "ConnectionId", Name = "idx_data_performance_analyses_savetime_conn_id")]
public partial class DataPerformanceAnalysis
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("connection_id")]
    public int? ConnectionId { get; set; }

    [Column("query", TypeName = "text")]
    public string? Query { get; set; }

    [Column("schema_name")]
    [StringLength(255)]
    public string? SchemaName { get; set; }

    [Column("count")]
    public long? Count { get; set; }

    [Column("time_total")]
    public double? TimeTotal { get; set; }

    [Column("time_avg_ms")]
    public double? TimeAvgMs { get; set; }

    [Column("save_time")]
    public DateTimeOffset? SaveTime { get; set; }

    [Column("digest")]
    [StringLength(255)]
    public string? Digest { get; set; }

    [Column("total_rows")]
    public long? TotalRows { get; set; }

    [Column("total_physical_reads")]
    public long? TotalPhysicalReads { get; set; }

    [Column("total_logical_reads")]
    public long? TotalLogicalReads { get; set; }

    [Column("total_logical_writes")]
    public long? TotalLogicalWrites { get; set; }

    [Column("row_affected_or_sent")]
    public long? RowAffectedOrSent { get; set; }

    [Column("row_examined")]
    public long? RowExamined { get; set; }

    [Column("temp_tables_created")]
    public long? TempTablesCreated { get; set; }

    [Column("full_tables_scan_join")]
    public long? FullTablesScanJoin { get; set; }

    [Column("rows_sorted")]
    public long? RowsSorted { get; set; }

    [Column("plan_digest")]
    [StringLength(255)]
    public string? PlanDigest { get; set; }

    [Column("cpu_time")]
    public double? CpuTime { get; set; }

    [Column("shared_blks_hit")]
    public long? SharedBlksHit { get; set; }

    [Column("shared_blks_read")]
    public long? SharedBlksRead { get; set; }

    [Column("shared_blks_dirtied")]
    public long? SharedBlksDirtied { get; set; }

    [Column("shared_blks_written")]
    public long? SharedBlksWritten { get; set; }
}
