using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenjualanBatchLog")]
public partial class PenjualanBatchLog
{
    [Key]
    public int Id { get; set; }

    public int IdBatch { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Alasan { get; set; } = null!;

    [Unicode(false)]
    public string SuratKuasa { get; set; } = null!;

    [Unicode(false)]
    public string SwaFotoPerwakilan { get; set; } = null!;

    [Unicode(false)]
    public string KtpPerwakilan { get; set; } = null!;

    [Column("NIKPerwakilan")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nikperwakilan { get; set; } = null!;

    public byte Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Unicode(false)]
    public string SuratKuasaBaru { get; set; } = null!;

    [ForeignKey("IdBatch")]
    [InverseProperty("PenjualanBatchLogs")]
    public virtual PenjualanBatch IdBatchNavigation { get; set; } = null!;
}
