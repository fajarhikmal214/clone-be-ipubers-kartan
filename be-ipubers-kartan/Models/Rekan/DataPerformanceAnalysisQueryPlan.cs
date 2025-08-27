using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("data_performance_analysis_query_plans")]
[Index("PlanDigest", Name = "idx_data_performance_analysis_query_plans_plan_digest")]
[Index("SaveTime", Name = "idx_dpa_query_plan_savetime")]
public partial class DataPerformanceAnalysisQueryPlan
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("query_plan", TypeName = "text")]
    public string? QueryPlan { get; set; }

    [Column("plan_digest")]
    [StringLength(255)]
    public string? PlanDigest { get; set; }

    [Column("save_time")]
    public DateTimeOffset? SaveTime { get; set; }
}
