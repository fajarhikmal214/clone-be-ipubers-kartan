using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("connection_groups")]
[Index("GroupName", Name = "idx_connection_groups_on_group_name", IsUnique = true)]
public partial class ConnectionGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("group_name")]
    [StringLength(255)]
    public string GroupName { get; set; } = null!;

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
}
