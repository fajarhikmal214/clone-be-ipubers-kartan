using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("up_down_states")]
[Index("ConnectionId", "CreatedAt", Name = "idx_up_down_states_on_connection_id_and_created_at")]
public partial class UpDownState
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("state")]
    public bool State { get; set; }

    [Column("connection_id")]
    public int ConnectionId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("start_or_end")]
    [StringLength(255)]
    public string StartOrEnd { get; set; } = null!;
}
