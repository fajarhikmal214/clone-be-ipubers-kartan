using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RFMapping")]
public partial class Rfmapping
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string IdRetailer { get; set; } = null!;

    /// <summary>
    /// 1 BNI, 2 Raya, 3 Mandiri
    /// </summary>
    public int KodeBank { get; set; }

    /// <summary>
    /// 1 Pengajuan Berhasil; 2 Sedang Di review; 3 Pengajuan Berhasil; 4 Pengajuan Ditolak
    /// </summary>
    public int StatusPengajuan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }
}
