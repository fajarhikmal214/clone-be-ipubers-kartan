using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("database_performance_postgres")]
[Index("ConnectionId", "CreatedAt", Name = "idx_database_performance_postgres_on_connection_id_created_at")]
public partial class DatabasePerformancePostgre
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("connection_id")]
    public int ConnectionId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("db_size_b")]
    public long? DbSizeB { get; set; }

    [Column("backends")]
    public int? Backends { get; set; }

    [Column("activity_count")]
    public int? ActivityCount { get; set; }

    [Column("idle_activity_count")]
    public int? IdleActivityCount { get; set; }

    [Column("max_connection")]
    public int? MaxConnection { get; set; }

    [Column("xact_commit_rate")]
    public double? XactCommitRate { get; set; }

    [Column("xact_rollback_rate")]
    public double? XactRollbackRate { get; set; }

    [Column("tup_returned_rate")]
    public double? TupReturnedRate { get; set; }

    [Column("tup_fetched_rate")]
    public double? TupFetchedRate { get; set; }

    [Column("tup_inserted_rate")]
    public double? TupInsertedRate { get; set; }

    [Column("tup_updated_rate")]
    public double? TupUpdatedRate { get; set; }

    [Column("tup_deleted_rate")]
    public double? TupDeletedRate { get; set; }

    [Column("tup_write_rate")]
    public double? TupWriteRate { get; set; }

    [Column("table_num")]
    public int? TableNum { get; set; }

    [Column("table_rows_num")]
    public long? TableRowsNum { get; set; }

    [Column("full_scan_percent")]
    public double? FullScanPercent { get; set; }

    [Column("dead_tuple_percent")]
    public double? DeadTuplePercent { get; set; }

    [Column("blks_read_rate")]
    public double? BlksReadRate { get; set; }

    [Column("blks_hit_rate")]
    public double? BlksHitRate { get; set; }

    [Column("blk_read_time")]
    public int? BlkReadTime { get; set; }

    [Column("blk_write_time")]
    public int? BlkWriteTime { get; set; }

    [Column("hit_from_disk_rate")]
    public double? HitFromDiskRate { get; set; }

    [Column("hit_from_cache_rate")]
    public double? HitFromCacheRate { get; set; }

    [Column("temp_files_rate")]
    public double? TempFilesRate { get; set; }

    [Column("temp_bytes_rate")]
    public double? TempBytesRate { get; set; }

    [Column("conflicts_rate")]
    public double? ConflictsRate { get; set; }

    [Column("deadlocks_rate")]
    public double? DeadlocksRate { get; set; }

    [Column("avg_wait_time_s")]
    public int? AvgWaitTimeS { get; set; }

    [Column("processes_blocked")]
    public int? ProcessesBlocked { get; set; }

    [Column("lock_memory_b")]
    public int? LockMemoryB { get; set; }

    [Column("frozen_databases")]
    public int? FrozenDatabases { get; set; }

    [Column("bad_checkpoints")]
    public bool? BadCheckpoints { get; set; }

    [Column("connection_percent")]
    public int? ConnectionPercent { get; set; }

    [Column("stats_reset")]
    public bool? StatsReset { get; set; }

    [Column("log_enabled")]
    public bool? LogEnabled { get; set; }
}
