using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("user_preferences")]
[Index("UserId", Name = "idx_user_preferences_on_user_id")]
public partial class UserPreference
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("process_list")]
    public int? ProcessList { get; set; }

    [Column("deadlock")]
    public int? Deadlock { get; set; }

    [Column("dashboard_filter_sort_by")]
    [StringLength(255)]
    public string? DashboardFilterSortBy { get; set; }

    [Column("dashboard_custom_order", TypeName = "text")]
    public string DashboardCustomOrder { get; set; } = null!;

    [Column("dashboard_view")]
    [StringLength(255)]
    public string? DashboardView { get; set; }

    [Column("dashboard_filter_shown")]
    [StringLength(255)]
    public string? DashboardFilterShown { get; set; }

    [Column("pg_trace_report_columns", TypeName = "text")]
    public string? PgTraceReportColumns { get; set; }
}
