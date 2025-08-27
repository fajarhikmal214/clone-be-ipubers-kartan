using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("wait_instruments")]
[Index("ConnectionId", Name = "idx_wait_instruments_connection_id")]
[Index("SaveTime", Name = "idx_wait_instruments_save_time")]
[Index("SaveType", Name = "idx_wait_instruments_save_type")]
public partial class WaitInstrument
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("connection_id")]
    public int? ConnectionId { get; set; }

    [Column("event_name")]
    [StringLength(255)]
    public string? EventName { get; set; }

    [Column("event_total_time")]
    public double? EventTotalTime { get; set; }

    [Column("operation")]
    [StringLength(255)]
    public string? Operation { get; set; }

    [Column("operation_total_time")]
    public double? OperationTotalTime { get; set; }

    [Column("save_type")]
    public int? SaveType { get; set; }

    [Column("save_time")]
    public DateTimeOffset? SaveTime { get; set; }
}
