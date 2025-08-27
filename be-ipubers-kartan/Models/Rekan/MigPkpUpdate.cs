using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("_migPkpUpdate")]
public partial class MigPkpUpdate
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string NoPkp { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string IdKecamatan { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    public byte Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncAt { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string Jenis { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? SyncMessage { get; set; }
}
