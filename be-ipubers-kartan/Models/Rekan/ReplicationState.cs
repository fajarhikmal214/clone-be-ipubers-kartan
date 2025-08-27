using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("replication_states")]
[Index("CreatedAt", Name = "idx_replication_states_on_created_at")]
[Index("ReplicationId", Name = "idx_replication_states_on_replication_id")]
public partial class ReplicationState
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("state")]
    public bool State { get; set; }

    [Column("replication_id")]
    public int ReplicationId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("start_or_end")]
    [StringLength(255)]
    public string StartOrEnd { get; set; } = null!;
}
