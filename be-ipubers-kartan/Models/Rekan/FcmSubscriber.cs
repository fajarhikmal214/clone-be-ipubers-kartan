using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Fcm_Subscriber")]
[Index("Id", Name = "Fcm_Subscriber_Id_uindex", IsUnique = true)]
public partial class FcmSubscriber
{
    [Key]
    [StringLength(36)]
    public string Id { get; set; } = null!;

    [StringLength(450)]
    public string? UserId { get; set; }

    public string? Token { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(250)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(250)]
    public string? UpdatedBy { get; set; }

    [InverseProperty("SubscriberNavigation")]
    public virtual ICollection<FcmTopicSubscription> FcmTopicSubscriptions { get; set; } = new List<FcmTopicSubscription>();

    [ForeignKey("UserId")]
    [InverseProperty("FcmSubscribers")]
    public virtual AspNetUser? User { get; set; }
}
