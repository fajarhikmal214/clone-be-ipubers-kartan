using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("connection_alert_contents")]
[Index("IsOpen", "ConnectionId", "CreatedAt", Name = "idx_alert_contents_on_is_open_connection_id_created_at")]
[Index("IsOpen", "ConnectionId", "Severity", "CreatedAt", Name = "idx_alert_contents_on_is_open_connection_id_severity_created_at")]
[Index("AlertContentId", Name = "idx_connection_alert_contents_on_alert_content_id")]
[Index("ConnectionId", "AlertContentId", Name = "idx_connection_alert_contents_on_connection_id_alert_content_id")]
[Index("CreatedAt", Name = "idx_connection_alert_contents_on_created_at")]
[Index("EndTime", "ConnectionId", Name = "idx_connection_alert_contents_on_end_time_connection_id")]
[Index("IsOpen", "AlertContentId", Name = "idx_connection_alert_contents_on_is_open_alert_content_id")]
[Index("IsOpen", "CreatedAt", Name = "idx_connection_alert_contents_on_is_open_created_at")]
[Index("IsOpen", "Severity", "CreatedAt", Name = "idx_connection_alert_contents_on_is_open_severity_created_at")]
[Index("IsOpen", "UserId", Name = "idx_connection_alert_contents_on_is_open_user_id")]
[Index("IsRead", "IsOpen", Name = "idx_connection_alert_contents_on_is_read_is_open")]
[Index("UserId", Name = "idx_connection_alert_contents_on_user_id")]
public partial class ConnectionAlertContent
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("connection_id")]
    public int ConnectionId { get; set; }

    [Column("alert_content_id")]
    public int AlertContentId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("is_open")]
    public bool? IsOpen { get; set; }

    [Column("is_read")]
    public bool? IsRead { get; set; }

    [Column("end_time")]
    public DateTimeOffset? EndTime { get; set; }

    [Column("user_id")]
    public long? UserId { get; set; }

    [Column("remark", TypeName = "text")]
    public string? Remark { get; set; }

    [Column("current_threshold_value")]
    public int? CurrentThresholdValue { get; set; }

    [Column("severity")]
    public int? Severity { get; set; }

    [Column("manual_close_time")]
    public DateTimeOffset? ManualCloseTime { get; set; }

    [Column("current_return_value")]
    public double? CurrentReturnValue { get; set; }

    [Column("current_alert_direction")]
    public bool? CurrentAlertDirection { get; set; }

    [Column("digest")]
    [StringLength(255)]
    public string? Digest { get; set; }
}
