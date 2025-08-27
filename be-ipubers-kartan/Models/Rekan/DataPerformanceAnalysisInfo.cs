using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("data_performance_analysis_infos")]
[Index("ConnectionId", Name = "idx_data_performance_analysis_infos_connection_id")]
[Index("Digest", Name = "idx_data_performance_analysis_infos_digest")]
[Index("SaveTime", Name = "idx_data_performance_analysis_infos_save_time")]
public partial class DataPerformanceAnalysisInfo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("connection_id")]
    public int? ConnectionId { get; set; }

    [Column("session_id")]
    public int? SessionId { get; set; }

    [Column("schema_id")]
    public int? SchemaId { get; set; }

    [Column("program_id")]
    public int? ProgramId { get; set; }

    [Column("machine_id")]
    public int? MachineId { get; set; }

    [Column("login_user_id")]
    public int? LoginUserId { get; set; }

    [Column("save_time")]
    public DateTimeOffset? SaveTime { get; set; }

    [Column("digest")]
    [StringLength(255)]
    public string? Digest { get; set; }

    [Column("count")]
    public int? Count { get; set; }
}
