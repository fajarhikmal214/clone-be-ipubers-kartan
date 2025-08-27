using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("Fcm_Topic")]
public partial class FcmTopic
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Kode { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    [InverseProperty("TopicNavigation")]
    public virtual ICollection<FcmNotification> FcmNotifications { get; set; } = new List<FcmNotification>();

    [InverseProperty("TopicNavigation")]
    public virtual ICollection<FcmTopicSubscription> FcmTopicSubscriptions { get; set; } = new List<FcmTopicSubscription>();
}
