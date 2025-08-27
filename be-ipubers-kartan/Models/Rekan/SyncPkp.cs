using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("SyncPkp")]
[Index("NoPkp", Name = "IX_SyncPkp")]
[Index("IdRetailer", Name = "IX_SyncPkp_1")]
[Index("SyncStatus", Name = "IX_SyncPkp_2")]
public partial class SyncPkp
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoPkp { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string IdKecamatan { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ReceivedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastSyncAt { get; set; }

    public byte? SyncStatus { get; set; }

    [Unicode(false)]
    public string? SyncMessage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;
}
