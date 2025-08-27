using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LogSyncAlokasi")]
public partial class LogSyncAlokasi
{
    [Key]
    public int Id { get; set; }

    [StringLength(14)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime SyncAt { get; set; }

    [Unicode(false)]
    public string? SyncMessage { get; set; }

    public byte SyncStatus { get; set; }

    [Unicode(false)]
    public string? SyncRequestBody { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncResponseAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }
}
