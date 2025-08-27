using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[PrimaryKey("TraceReportId", "Digest")]
[Table("trace_report_content_summary_postgres")]
public partial class TraceReportContentSummaryPostgre
{
    [Key]
    [Column("trace_report_id")]
    public int TraceReportId { get; set; }

    [Key]
    [Column("digest")]
    [StringLength(255)]
    public string Digest { get; set; } = null!;

    [Column("executed")]
    public int? Executed { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("rows_affected")]
    public long? RowsAffected { get; set; }

    [Column("shared_blocks_read")]
    public int? SharedBlocksRead { get; set; }

    [Column("shared_blocks_written")]
    public int? SharedBlocksWritten { get; set; }

    [Column("shared_blocks_hit")]
    public int? SharedBlocksHit { get; set; }

    [Column("local_blocks_read")]
    public int? LocalBlocksRead { get; set; }

    [Column("local_blocks_written")]
    public int? LocalBlocksWritten { get; set; }

    [Column("local_blocks_hit")]
    public int? LocalBlocksHit { get; set; }

    [Column("temporary_blocks_read")]
    public int? TemporaryBlocksRead { get; set; }

    [Column("temporary_blocks_written")]
    public int? TemporaryBlocksWritten { get; set; }
}
