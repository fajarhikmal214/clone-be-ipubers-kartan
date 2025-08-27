using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("maintenance_settings")]
public partial class MaintenanceSetting
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("start_datetime")]
    public DateTimeOffset StartDatetime { get; set; }

    [Column("duration_minute")]
    public int DurationMinute { get; set; }

    [Column("connection_id")]
    public int ConnectionId { get; set; }

    [Column("recurrence")]
    public int Recurrence { get; set; }

    [Column("weeks_frequency")]
    public int WeeksFrequency { get; set; }

    [Column("weeks_day_of_week")]
    [StringLength(100)]
    [Unicode(false)]
    public string WeeksDayOfWeek { get; set; } = null!;

    [Column("months_mode")]
    public int MonthsMode { get; set; }

    [Column("months_days_start")]
    public int MonthsDaysStart { get; set; }

    [Column("months_days_frequency")]
    public int MonthsDaysFrequency { get; set; }

    [Column("months_weeks_start")]
    public int MonthsWeeksStart { get; set; }

    [Column("months_weeks_day_of_week")]
    public int MonthsWeeksDayOfWeek { get; set; }

    [Column("months_weeks_frequency")]
    public int MonthsWeeksFrequency { get; set; }
}
