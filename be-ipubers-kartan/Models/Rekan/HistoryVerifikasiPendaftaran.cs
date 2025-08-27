using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("HistoryVerifikasiPendaftaran")]
public partial class HistoryVerifikasiPendaftaran
{
    [StringLength(60)]
    public string? Id { get; set; }

    [StringLength(60)]
    public string? PendaftaranId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Aksi { get; set; }

    [Column(TypeName = "text")]
    public string? Catatan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(60)]
    public string? CreatedBy { get; set; }
}
