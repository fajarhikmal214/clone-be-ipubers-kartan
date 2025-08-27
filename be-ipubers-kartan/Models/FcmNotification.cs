using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("Fcm_Notification")]
public partial class FcmNotification
{
    [Key]
    public long Id { get; set; }

    [StringLength(250)]
    public string? Title { get; set; }

    public string? Body { get; set; }

    /// <summary>
    /// News Id
    /// </summary>
    [StringLength(128)]
    public string? News { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Topic { get; set; } = null!;

    public int? Priority { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(250)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(250)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("News")]
    [InverseProperty("FcmNotifications")]
    public virtual News? NewsNavigation { get; set; }

    [ForeignKey("Topic")]
    [InverseProperty("FcmNotifications")]
    public virtual FcmTopic TopicNavigation { get; set; } = null!;
}
