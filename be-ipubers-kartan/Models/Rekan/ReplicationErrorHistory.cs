using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("replication_error_histories")]
[Index("ReplicationId", Name = "idx_replication_error_histories_on_replication_id")]
public partial class ReplicationErrorHistory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("error", TypeName = "text")]
    public string Error { get; set; } = null!;

    [Column("replication_id")]
    public int ReplicationId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("error_type")]
    [StringLength(255)]
    public string ErrorType { get; set; } = null!;

    [Column("error_no")]
    public int ErrorNo { get; set; }
}
