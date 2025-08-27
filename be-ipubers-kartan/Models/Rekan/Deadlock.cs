using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("deadlocks")]
[Index("ConnectionId", "CreatedAt", Name = "idx_deadlocks_on_connection_id_created_at")]
public partial class Deadlock
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("time")]
    public DateTimeOffset? Time { get; set; }

    [Column("connection_id")]
    public int ConnectionId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("transaction1", TypeName = "text")]
    public string? Transaction1 { get; set; }

    [Column("transaction2", TypeName = "text")]
    public string? Transaction2 { get; set; }
}
