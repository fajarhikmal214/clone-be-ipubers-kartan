using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("user_sessions")]
[Index("UserSessionId", Name = "idx_user_sessions_on_user_session_id", IsUnique = true)]
public partial class UserSession
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_session_id")]
    [StringLength(255)]
    public string UserSessionId { get; set; } = null!;

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
}
