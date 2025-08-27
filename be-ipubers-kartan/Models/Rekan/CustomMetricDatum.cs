using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("custom_metric_data")]
[Index("ConnectionId", "MetricId", Name = "idx_custom_metric_data_on_connection_id_metric_id")]
public partial class CustomMetricDatum
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("connection_id")]
    public int? ConnectionId { get; set; }

    [Column("metric_id")]
    public int? MetricId { get; set; }

    [Column("data")]
    public double? Data { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }
}
