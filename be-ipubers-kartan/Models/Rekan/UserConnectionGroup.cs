using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("user_connection_groups")]
[Index("ConnectionGroupId", Name = "idx_user_connection_groups_on_connection_group_id")]
[Index("UserId", Name = "idx_user_connection_groups_on_user_id")]
public partial class UserConnectionGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("connection_group_id")]
    public int ConnectionGroupId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
}
