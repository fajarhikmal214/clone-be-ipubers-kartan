using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("custom_metric_alert_settings")]
[Index("AlertName", Name = "idx_alert_name", IsUnique = true)]
public partial class CustomMetricAlertSetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("db_type")]
    public int? DbType { get; set; }

    [Column("alert_name")]
    [StringLength(255)]
    public string AlertName { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("alert_type")]
    public int AlertType { get; set; }

    [Column("alert_enable")]
    public bool AlertEnable { get; set; }

    [Column("alert_direction")]
    public bool AlertDirection { get; set; }

    [Column("alert_warn_enable")]
    public bool AlertWarnEnable { get; set; }

    [Column("alert_warn_threshold")]
    public int AlertWarnThreshold { get; set; }

    [Column("alert_critical_enable")]
    public bool AlertCriticalEnable { get; set; }

    [Column("alert_critical_threshold")]
    public int AlertCriticalThreshold { get; set; }

    [Column("alert_length_minute")]
    public int AlertLengthMinute { get; set; }

    [Column("alert_sent_when_raise")]
    public bool AlertSentWhenRaise { get; set; }

    [Column("alert_sent_when_end")]
    public bool AlertSentWhenEnd { get; set; }

    [Column("alert_sent_via_email")]
    public bool AlertSentViaEmail { get; set; }

    [Column("alert_sent_via_slack")]
    public bool AlertSentViaSlack { get; set; }

    [Column("alert_sent_via_sms")]
    public bool AlertSentViaSms { get; set; }

    [Column("alert_sent_via_snmp")]
    public bool AlertSentViaSnmp { get; set; }

    [Column("alert_sent_to_user_enable")]
    public bool AlertSentToUserEnable { get; set; }

    [Column("alert_sent_to_all")]
    public bool AlertSentToAll { get; set; }

    [Column("alert_sent_to_roles", TypeName = "text")]
    public string AlertSentToRoles { get; set; } = null!;

    [Column("alert_sent_alternative_email")]
    public bool AlertSentAlternativeEmail { get; set; }

    [Column("alert_sent_to_emails", TypeName = "text")]
    public string? AlertSentToEmails { get; set; }

    [Column("manager_note", TypeName = "text")]
    public string? ManagerNote { get; set; }
}
