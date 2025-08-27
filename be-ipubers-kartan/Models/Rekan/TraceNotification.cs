using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("trace_notifications")]
public partial class TraceNotification
{
    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("connection_id")]
    public int? ConnectionId { get; set; }

    [Column("notification_count")]
    public int? NotificationCount { get; set; }
}
