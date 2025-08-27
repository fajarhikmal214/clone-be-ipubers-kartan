using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[PrimaryKey("Id", "TraceReportId")]
[Table("trace_report_content_postgres")]
[Index("TraceReportId", Name = "idx_trace_report_content_postgres_on_trace_report_id")]
public partial class TraceReportContentPostgre
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Key]
    [Column("trace_report_id")]
    public int TraceReportId { get; set; }

    [Column("log_time")]
    public DateTimeOffset? LogTime { get; set; }

    [Column("user_name")]
    [StringLength(255)]
    public string? UserName { get; set; }

    [Column("database_name")]
    [StringLength(255)]
    public string? DatabaseName { get; set; }

    [Column("process_id")]
    public int? ProcessId { get; set; }

    [Column("connection_from")]
    [StringLength(255)]
    public string? ConnectionFrom { get; set; }

    [Column("session_id")]
    [StringLength(255)]
    public string? SessionId { get; set; }

    [Column("session_line_num")]
    public int? SessionLineNum { get; set; }

    [Column("command_tag")]
    [StringLength(255)]
    public string? CommandTag { get; set; }

    [Column("session_start_time")]
    public DateTimeOffset? SessionStartTime { get; set; }

    [Column("virtual_transaction_id")]
    [StringLength(255)]
    public string? VirtualTransactionId { get; set; }

    [Column("transaction_id")]
    [StringLength(255)]
    public string? TransactionId { get; set; }

    [Column("error_severity")]
    [StringLength(255)]
    public string? ErrorSeverity { get; set; }

    [Column("sql_state_code")]
    [StringLength(255)]
    public string? SqlStateCode { get; set; }

    [Column("message", TypeName = "text")]
    public string Message { get; set; } = null!;

    [Column("detail")]
    [StringLength(255)]
    public string? Detail { get; set; }

    [Column("hint", TypeName = "text")]
    public string? Hint { get; set; }

    [Column("internal_query")]
    [StringLength(255)]
    public string? InternalQuery { get; set; }

    [Column("internal_query_pos")]
    public int? InternalQueryPos { get; set; }

    [Column("context")]
    [StringLength(255)]
    public string? Context { get; set; }

    [Column("query", TypeName = "text")]
    public string? Query { get; set; }

    [Column("query_pos")]
    public int? QueryPos { get; set; }

    [Column("location")]
    [StringLength(255)]
    public string? Location { get; set; }

    [Column("application_name")]
    [StringLength(255)]
    public string ApplicationName { get; set; } = null!;

    [Column("backend_type")]
    [StringLength(255)]
    public string BackendType { get; set; } = null!;

    [Column("leader_pid")]
    public int? LeaderPid { get; set; }

    [Column("query_id")]
    public long QueryId { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }
}
