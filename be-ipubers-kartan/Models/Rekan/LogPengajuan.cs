using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("LogPengajuan", Schema = "FSCM_BNI")]
public partial class LogPengajuan
{
    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? IdPengajuan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    public int? Status { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    public int? KodeBank { get; set; }

    [ForeignKey("IdPengajuan")]
    [InverseProperty("LogPengajuans")]
    public virtual Pengajuan? IdPengajuanNavigation { get; set; }
}
