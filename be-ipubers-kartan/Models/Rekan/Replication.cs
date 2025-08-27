using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("replications")]
[Index("ConnectionId", "CreatedAt", Name = "idx_replications_on_connection_id_and_created_at")]
public partial class Replication
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

    [Column("master_host")]
    [StringLength(255)]
    public string MasterHost { get; set; } = null!;

    [Column("master_port")]
    public int MasterPort { get; set; }

    [Column("json", TypeName = "text")]
    public string? Json { get; set; }

    [Column("type")]
    [StringLength(255)]
    public string Type { get; set; } = null!;

    [Column("identifier")]
    [StringLength(255)]
    public string Identifier { get; set; } = null!;

    [Column("master_id")]
    public int MasterId { get; set; }
}
