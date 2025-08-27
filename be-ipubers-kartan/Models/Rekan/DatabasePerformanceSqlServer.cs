using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("database_performance_sql_servers")]
public partial class DatabasePerformanceSqlServer
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

    [Column("disk_size")]
    public int? DiskSize { get; set; }

    [Column("disk_free")]
    public int? DiskFree { get; set; }

    [Column("free_memory")]
    public long? FreeMemory { get; set; }

    [Column("total_memory")]
    public long? TotalMemory { get; set; }

    [Column("memory_usedby_sqlserver_mb")]
    public int? MemoryUsedbySqlserverMb { get; set; }

    [Column("free_cpu")]
    public int? FreeCpu { get; set; }

    [Column("total_cpu")]
    public int? TotalCpu { get; set; }

    [Column("db_without_backup")]
    public int? DbWithoutBackup { get; set; }

    [Column("database_engine_running")]
    public bool? DatabaseEngineRunning { get; set; }

    [Column("read_latency")]
    public double? ReadLatency { get; set; }

    [Column("write_latency")]
    public double? WriteLatency { get; set; }

    [Column("overall_latency")]
    public double? OverallLatency { get; set; }

    [Column("avg_bytes_per_read")]
    public double? AvgBytesPerRead { get; set; }

    [Column("avg_bytes_per_write")]
    public double? AvgBytesPerWrite { get; set; }

    [Column("avg_bytes_per_transfer")]
    public double? AvgBytesPerTransfer { get; set; }

    [Column("avg_io_stall_ms")]
    public double? AvgIoStallMs { get; set; }

    [Column("has_offline_database")]
    public bool? HasOfflineDatabase { get; set; }

    [Column("pending_disk_io")]
    public int? PendingDiskIo { get; set; }

    [Column("sqlserver_browser_enabled")]
    public bool? SqlserverBrowserEnabled { get; set; }

    [Column("policy_not_checked")]
    public bool? PolicyNotChecked { get; set; }

    [Column("is_sa_disabled")]
    public bool? IsSaDisabled { get; set; }

    [Column("encrypt_option")]
    public bool? EncryptOption { get; set; }

    [Column("table_num")]
    public int? TableNum { get; set; }

    [Column("table_rows_num")]
    public long? TableRowsNum { get; set; }

    [Column("db_data_size")]
    public long? DbDataSize { get; set; }

    [Column("cmd_shell")]
    public bool? CmdShell { get; set; }

    [Column("ad_hoc_distributed_queries")]
    public bool? AdHocDistributedQueries { get; set; }

    [Column("clr_enabled")]
    public bool? ClrEnabled { get; set; }

    [Column("cross_db_ownership_chaining")]
    public bool? CrossDbOwnershipChaining { get; set; }

    [Column("database_mail_xps")]
    public bool? DatabaseMailXps { get; set; }

    [Column("ole_automation_procedures")]
    public bool? OleAutomationProcedures { get; set; }

    [Column("scan_for_startup_procs")]
    public bool? ScanForStartupProcs { get; set; }

    [Column("user_connections")]
    public int? UserConnections { get; set; }

    [Column("batch_request_rate")]
    public double? BatchRequestRate { get; set; }

    [Column("data_files_size_kb")]
    public long? DataFilesSizeKb { get; set; }

    [Column("transactions_rate")]
    public double? TransactionsRate { get; set; }

    [Column("write_transactions_rate")]
    public double? WriteTransactionsRate { get; set; }

    [Column("lock_memory_kb")]
    public long? LockMemoryKb { get; set; }

    [Column("processes_blocked")]
    public int? ProcessesBlocked { get; set; }

    [Column("avg_wait_time_ratio")]
    public double? AvgWaitTimeRatio { get; set; }

    [Column("longest_transaction_running_time")]
    public int? LongestTransactionRunningTime { get; set; }

    [Column("granted_workspace_memory_kb")]
    public int? GrantedWorkspaceMemoryKb { get; set; }

    [Column("maximum_workspace_memory_kb")]
    public long? MaximumWorkspaceMemoryKb { get; set; }

    [Column("memory_grants_pending")]
    public int? MemoryGrantsPending { get; set; }

    [Column("memory_grants_outstanding")]
    public int? MemoryGrantsOutstanding { get; set; }

    [Column("connection_memory_kb")]
    public int? ConnectionMemoryKb { get; set; }

    [Column("worktables_from_cache_base")]
    public int? WorktablesFromCacheBase { get; set; }

    [Column("target_server_memory_kb")]
    public long? TargetServerMemoryKb { get; set; }

    [Column("total_server_memory_kb")]
    public long? TotalServerMemoryKb { get; set; }

    [Column("temp_tables_for_destruction")]
    public int? TempTablesForDestruction { get; set; }

    [Column("active_temp_tables")]
    public int? ActiveTempTables { get; set; }

    [Column("log_remaining_for_undo")]
    public int? LogRemainingForUndo { get; set; }

    [Column("log_send_queue")]
    public int? LogSendQueue { get; set; }

    [Column("recovery_queue")]
    public int? RecoveryQueue { get; set; }

    [Column("redo_bytes_remaining")]
    public int? RedoBytesRemaining { get; set; }

    [Column("total_log_requiring_undo")]
    public int? TotalLogRequiringUndo { get; set; }

    [Column("flow_control_time")]
    public int? FlowControlTime { get; set; }

    [Column("page_life_expectancy")]
    public int? PageLifeExpectancy { get; set; }

    [Column("database_pages")]
    public long? DatabasePages { get; set; }

    [Column("target_pages")]
    public long? TargetPages { get; set; }

    [Column("active_transactions")]
    public int? ActiveTransactions { get; set; }

    [Column("log_files_size_kb")]
    public long? LogFilesSizeKb { get; set; }

    [Column("log_files_used_size_kb")]
    public long? LogFilesUsedSizeKb { get; set; }

    [Column("percent_log_used")]
    public int? PercentLogUsed { get; set; }

    [Column("log_growths")]
    public int? LogGrowths { get; set; }

    [Column("log_shrinks")]
    public int? LogShrinks { get; set; }

    [Column("user_connections_ratio")]
    public double? UserConnectionsRatio { get; set; }

    [Column("total_latch_wait_time_ratio")]
    public double? TotalLatchWaitTimeRatio { get; set; }

    [Column("batch_requests_ratio")]
    public double? BatchRequestsRatio { get; set; }

    [Column("sql_compilations_per_batch_requests_ratio")]
    public double? SqlCompilationsPerBatchRequestsRatio { get; set; }

    [Column("sql_recompilations_per_batch_requests_ratio")]
    public double? SqlRecompilationsPerBatchRequestsRatio { get; set; }

    [Column("buffer_cache_hit_ratio")]
    public double? BufferCacheHitRatio { get; set; }

    [Column("worktables_from_cache_ratio")]
    public double? WorktablesFromCacheRatio { get; set; }

    [Column("logins_rate")]
    public double? LoginsRate { get; set; }

    [Column("logouts_rate")]
    public double? LogoutsRate { get; set; }

    [Column("connection_resets_rate")]
    public double? ConnectionResetsRate { get; set; }

    [Column("latch_waits_rate")]
    public double? LatchWaitsRate { get; set; }

    [Column("table_lock_escalations_rate")]
    public double? TableLockEscalationsRate { get; set; }

    [Column("sql_compilations_rate")]
    public double? SqlCompilationsRate { get; set; }

    [Column("sql_recompilations_rate")]
    public double? SqlRecompilationsRate { get; set; }

    [Column("sql_attention_rate")]
    public double? SqlAttentionRate { get; set; }

    [Column("auto_param_attempts_rate")]
    public double? AutoParamAttemptsRate { get; set; }

    [Column("failed_auto_params_rate")]
    public double? FailedAutoParamsRate { get; set; }

    [Column("safe_auto_params_rate")]
    public double? SafeAutoParamsRate { get; set; }

    [Column("unsafe_auto_params_rate")]
    public double? UnsafeAutoParamsRate { get; set; }

    [Column("forwarded_records_rate")]
    public double? ForwardedRecordsRate { get; set; }

    [Column("full_scans_rate")]
    public double? FullScansRate { get; set; }

    [Column("index_searches_rate")]
    public double? IndexSearchesRate { get; set; }

    [Column("page_splits_rate")]
    public double? PageSplitsRate { get; set; }

    [Column("workfiles_created_rate")]
    public double? WorkfilesCreatedRate { get; set; }

    [Column("worktables_created_rate")]
    public double? WorktablesCreatedRate { get; set; }

    [Column("page_lookups_rate")]
    public double? PageLookupsRate { get; set; }

    [Column("free_list_stalls_rate")]
    public double? FreeListStallsRate { get; set; }

    [Column("lazy_writes_rate")]
    public double? LazyWritesRate { get; set; }

    [Column("checkpoint_pages_rate")]
    public double? CheckpointPagesRate { get; set; }

    [Column("page_reads_rate")]
    public double? PageReadsRate { get; set; }

    [Column("page_writes_rate")]
    public double? PageWritesRate { get; set; }

    [Column("readahead_pages_ratio")]
    public double? ReadaheadPagesRatio { get; set; }

    [Column("pages_allocated_rate")]
    public double? PagesAllocatedRate { get; set; }

    [Column("extents_allocated_rate")]
    public double? ExtentsAllocatedRate { get; set; }

    [Column("temp_tables_creation_rate")]
    public double? TempTablesCreationRate { get; set; }

    [Column("file_bytes_received_rate")]
    public double? FileBytesReceivedRate { get; set; }

    [Column("log_bytes_received_rate")]
    public double? LogBytesReceivedRate { get; set; }

    [Column("redo_blocked_rate")]
    public double? RedoBlockedRate { get; set; }

    [Column("redone_bytes_rate")]
    public double? RedoneBytesRate { get; set; }

    [Column("bytes_received_from_replica_rate")]
    public double? BytesReceivedFromReplicaRate { get; set; }

    [Column("bytes_sent_to_replica_rate")]
    public double? BytesSentToReplicaRate { get; set; }

    [Column("bytes_sent_to_transport_rate")]
    public double? BytesSentToTransportRate { get; set; }

    [Column("flow_control_rate")]
    public double? FlowControlRate { get; set; }

    [Column("resent_messages_rate")]
    public double? ResentMessagesRate { get; set; }

    [Column("sends_to_replica_rate")]
    public double? SendsToReplicaRate { get; set; }

    [Column("sends_to_transport_rate")]
    public double? SendsToTransportRate { get; set; }

    [Column("errors_rate")]
    public double? ErrorsRate { get; set; }

    [Column("lock_waits_rate")]
    public double? LockWaitsRate { get; set; }

    [Column("lock_requests_rate")]
    public double? LockRequestsRate { get; set; }

    [Column("lock_timeouts_rate")]
    public double? LockTimeoutsRate { get; set; }

    [Column("number_of_deadlocks_rate")]
    public double? NumberOfDeadlocksRate { get; set; }

    [Column("log_bytes_flushed_rate")]
    public double? LogBytesFlushedRate { get; set; }

    [Column("log_flush_waits_rate")]
    public double? LogFlushWaitsRate { get; set; }

    [Column("log_flush_rate")]
    public double? LogFlushRate { get; set; }

    [Column("mirrored_write_transactions_rate")]
    public double? MirroredWriteTransactionsRate { get; set; }

    [Column("total_latch_wait_time_rate")]
    public double? TotalLatchWaitTimeRate { get; set; }

    [Column("cluster_current_owner")]
    [StringLength(255)]
    public string? ClusterCurrentOwner { get; set; }

    [Column("cluster_node_down")]
    public int? ClusterNodeDown { get; set; }

    [Column("cluster_group_failed")]
    public bool? ClusterGroupFailed { get; set; }

    [Column("cluster_group_unhealthy")]
    public bool? ClusterGroupUnhealthy { get; set; }

    [Column("cluster_group_not_ready_for_failover")]
    public bool? ClusterGroupNotReadyForFailover { get; set; }

    [Column("cluster_group_not_joined")]
    public bool? ClusterGroupNotJoined { get; set; }

    [Column("cluster_group_not_online")]
    public bool? ClusterGroupNotOnline { get; set; }

    [Column("audit_failed")]
    public bool? AuditFailed { get; set; }
}
