using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("data_performance_analysis_files")]
[Index("ConnectionId", Name = "idx_data_performance_analysis_files_connection_id")]
[Index("SaveTime", Name = "idx_data_performance_analysis_files_save_time")]
[Index("SaveType", Name = "idx_data_performance_analysis_files_save_type")]
public partial class DataPerformanceAnalysisFile
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("connection_id")]
    public int? ConnectionId { get; set; }

    [Column("file_path")]
    [StringLength(255)]
    public string? FilePath { get; set; }

    [Column("spent_time")]
    public double? SpentTime { get; set; }

    [Column("drive")]
    [StringLength(255)]
    public string? Drive { get; set; }

    [Column("save_type")]
    public int? SaveType { get; set; }

    [Column("save_time")]
    public DateTimeOffset? SaveTime { get; set; }
}
