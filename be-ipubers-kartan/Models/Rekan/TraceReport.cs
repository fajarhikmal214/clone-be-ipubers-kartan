using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("trace_reports")]
public partial class TraceReport
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("trace_id")]
    public int? TraceId { get; set; }

    [Column("from")]
    public DateTimeOffset? From { get; set; }

    [Column("to")]
    public DateTimeOffset? To { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [Column("err")]
    [StringLength(255)]
    public string? Err { get; set; }
}
