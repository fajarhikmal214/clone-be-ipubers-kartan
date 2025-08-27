using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("database_performances")]
[Index("ConnectionId", "CreatedAt", Name = "idx_database_performances_on_connection_id_created_at")]
public partial class DatabasePerformance
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

    [Column("conn_num")]
    public int ConnNum { get; set; }

    [Column("max_conn_num")]
    public int MaxConnNum { get; set; }

    [Column("query_rate")]
    public double QueryRate { get; set; }

    [Column("bytes_received_rate")]
    public double BytesReceivedRate { get; set; }

    [Column("bytes_sent_rate")]
    public double BytesSentRate { get; set; }

    [Column("qcache_hits_rate")]
    public double QcacheHitsRate { get; set; }

    [Column("com_select_rate")]
    public double ComSelectRate { get; set; }

    [Column("com_insert_rate")]
    public double ComInsertRate { get; set; }

    [Column("com_update_rate")]
    public double ComUpdateRate { get; set; }

    [Column("com_delete_rate")]
    public double ComDeleteRate { get; set; }

    [Column("read_query_rate")]
    public double ReadQueryRate { get; set; }

    [Column("write_query_rate")]
    public double WriteQueryRate { get; set; }

    [Column("table_num")]
    public int TableNum { get; set; }

    [Column("table_rows_num")]
    public int TableRowsNum { get; set; }

    [Column("db_data_size")]
    public long DbDataSize { get; set; }

    [Column("db_idx_size")]
    public int DbIdxSize { get; set; }

    [Column("total_db_size")]
    public long TotalDbSize { get; set; }

    [Column("db_idxfrac_size")]
    public int DbIdxfracSize { get; set; }

    [Column("select_scan_rate")]
    public double SelectScanRate { get; set; }

    [Column("select_full_join_rate")]
    public double SelectFullJoinRate { get; set; }

    [Column("innodb_buf_pool_size")]
    public int InnodbBufPoolSize { get; set; }

    [Column("innodb_buf_pool_free")]
    public int InnodbBufPoolFree { get; set; }

    [Column("innodb_buf_cache_hit")]
    public double InnodbBufCacheHit { get; set; }

    [Column("query_cache_hit")]
    public double QueryCacheHit { get; set; }

    [Column("myisam_key_cache_hit")]
    public double MyisamKeyCacheHit { get; set; }

    [Column("thread_cache_hit")]
    public double ThreadCacheHit { get; set; }

    [Column("conn_running")]
    public int ConnRunning { get; set; }

    [Column("conn_cached")]
    public int ConnCached { get; set; }

    [Column("percent_open_table_against_table_cache")]
    public int PercentOpenTableAgainstTableCache { get; set; }

    [Column("opened_table_rate")]
    public double OpenedTableRate { get; set; }

    [Column("table_locks_immediate_rate")]
    public double TableLocksImmediateRate { get; set; }

    [Column("table_locks_waited_rate")]
    public double TableLocksWaitedRate { get; set; }

    [Column("table_lock_wait_ratio")]
    public double TableLockWaitRatio { get; set; }

    [Column("conn_attempt_rate")]
    public double ConnAttemptRate { get; set; }

    [Column("conn_aborted_rate")]
    public double ConnAbortedRate { get; set; }

    [Column("client_aborted_rate")]
    public double ClientAbortedRate { get; set; }

    [Column("highest_concurrent_conn")]
    public int HighestConcurrentConn { get; set; }

    [Column("percent_of_max_reached_conn")]
    public double PercentOfMaxReachedConn { get; set; }

    [Column("percent_of_refused_conn")]
    public double PercentOfRefusedConn { get; set; }

    [Column("num_of_slow_launch_threads")]
    public int NumOfSlowLaunchThreads { get; set; }

    [Column("percent_of_innodb_cache_write_wait")]
    public double PercentOfInnodbCacheWriteWait { get; set; }

    [Column("innodb_log_buffer_size")]
    public int InnodbLogBufferSize { get; set; }

    [Column("percent_of_innodb_log_wait_required")]
    public double PercentOfInnodbLogWaitRequired { get; set; }

    [Column("percent_of_full_table_scan")]
    public double PercentOfFullTableScan { get; set; }

    [Column("created_tmp_tables_rate")]
    public double CreatedTmpTablesRate { get; set; }

    [Column("created_tmp_disk_tables_rate")]
    public double CreatedTmpDiskTablesRate { get; set; }

    [Column("created_tmp_disk_ratio")]
    public double CreatedTmpDiskRatio { get; set; }

    [Column("innodb_rows_deleted_rate")]
    public double InnodbRowsDeletedRate { get; set; }

    [Column("innodb_rows_inserted_rate")]
    public double InnodbRowsInsertedRate { get; set; }

    [Column("innodb_rows_read_rate")]
    public double InnodbRowsReadRate { get; set; }

    [Column("innodb_rows_updated_rate")]
    public double InnodbRowsUpdatedRate { get; set; }

    [Column("innodb_row_lock_current_waits")]
    public int InnodbRowLockCurrentWaits { get; set; }

    [Column("innodb_row_lock_time")]
    public int InnodbRowLockTime { get; set; }

    [Column("innodb_row_lock_time_avg")]
    public int InnodbRowLockTimeAvg { get; set; }

    [Column("innodb_row_lock_time_max")]
    public int InnodbRowLockTimeMax { get; set; }

    [Column("innodb_data_reads_rate")]
    public double InnodbDataReadsRate { get; set; }

    [Column("innodb_data_writes_rate")]
    public double InnodbDataWritesRate { get; set; }

    [Column("com_begin_rate")]
    public double ComBeginRate { get; set; }

    [Column("com_commit_rate")]
    public double ComCommitRate { get; set; }

    [Column("com_rollback_rate")]
    public double ComRollbackRate { get; set; }

    [Column("sort_merge_passes_rate")]
    public double SortMergePassesRate { get; set; }

    [Column("sort_range_rate")]
    public double SortRangeRate { get; set; }

    [Column("sort_scan_rate")]
    public double SortScanRate { get; set; }

    [Column("sort_rows_rate")]
    public double SortRowsRate { get; set; }

    [Column("binlog_cache_use_rate")]
    public double BinlogCacheUseRate { get; set; }

    [Column("binlog_cache_disk_use_rate")]
    public double BinlogCacheDiskUseRate { get; set; }

    [Column("total_rows_returned")]
    public double TotalRowsReturned { get; set; }

    [Column("total_rows_returned_use_index")]
    public double TotalRowsReturnedUseIndex { get; set; }

    [Column("percent_rows_use_index")]
    public double PercentRowsUseIndex { get; set; }

    [Column("percent_pruned_query")]
    public double PercentPrunedQuery { get; set; }

    [Column("percent_conn_usage")]
    public double PercentConnUsage { get; set; }

    [Column("percent_myisam_cache_usage")]
    public double PercentMyisamCacheUsage { get; set; }

    [Column("percent_innodb_cache_usage")]
    public double PercentInnodbCacheUsage { get; set; }

    [Column("slow_query_rate")]
    public double SlowQueryRate { get; set; }

    [Column("innodb_data_fsyncs_rate")]
    public double InnodbDataFsyncsRate { get; set; }

    [Column("innodb_log_writes_rate")]
    public double InnodbLogWritesRate { get; set; }

    [Column("free_myisam_buffer_size")]
    public double FreeMyisamBufferSize { get; set; }

    [Column("key_buffer_size")]
    public double KeyBufferSize { get; set; }

    [Column("percent_of_slow_query")]
    public double PercentOfSlowQuery { get; set; }
}
