using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("Fcm_TopicSubscription")]
public partial class FcmTopicSubscription
{
    [Key]
    [StringLength(36)]
    public string Id { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? Topic { get; set; }

    /// <summary>
    /// FCM Client Token
    /// </summary>
    [StringLength(36)]
    public string? Subscriber { get; set; }

    [ForeignKey("Subscriber")]
    [InverseProperty("FcmTopicSubscriptions")]
    public virtual FcmSubscriber? SubscriberNavigation { get; set; }

    [ForeignKey("Topic")]
    [InverseProperty("FcmTopicSubscriptions")]
    public virtual FcmTopic? TopicNavigation { get; set; }
}
