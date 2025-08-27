using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("schedule_reports")]
public partial class ScheduleReport
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("instance_ids", TypeName = "text")]
    public string? InstanceIds { get; set; }

    [Column("group_ids", TypeName = "text")]
    public string? GroupIds { get; set; }

    [Column("mysql_chart_names", TypeName = "text")]
    public string? MysqlChartNames { get; set; }

    [Column("sqlserver_chart_names", TypeName = "text")]
    public string? SqlserverChartNames { get; set; }

    [Column("dpa_mysql_chart_names", TypeName = "text")]
    public string? DpaMysqlChartNames { get; set; }

    [Column("dpa_sqlserver_chart_names", TypeName = "text")]
    public string? DpaSqlserverChartNames { get; set; }

    [Column("dpa_digest")]
    [StringLength(255)]
    public string? DpaDigest { get; set; }

    [Column("lang")]
    [StringLength(255)]
    public string? Lang { get; set; }

    [Column("is_all_instances")]
    public bool? IsAllInstances { get; set; }

    [Column("is_area_chart")]
    public bool? IsAreaChart { get; set; }

    [Column("is_replication_shown")]
    public bool? IsReplicationShown { get; set; }

    [Column("is_up_down_chart_shown")]
    public bool? IsUpDownChartShown { get; set; }

    [Column("is_replication_list_shown")]
    public bool? IsReplicationListShown { get; set; }

    [Column("from")]
    public DateTimeOffset? From { get; set; }

    [Column("to")]
    public DateTimeOffset? To { get; set; }

    [Column("period")]
    public int? Period { get; set; }

    [Column("mail_to", TypeName = "text")]
    public string? MailTo { get; set; }

    [Column("message", TypeName = "text")]
    public string? Message { get; set; }

    [Column("postgres_chart_names", TypeName = "text")]
    public string? PostgresChartNames { get; set; }

    [Column("dpa_postgres_chart_names", TypeName = "text")]
    public string? DpaPostgresChartNames { get; set; }
}
