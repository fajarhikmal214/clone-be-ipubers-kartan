using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// menyimpan informasi tambahan hasil dari kiriman apps
/// </summary>
[PrimaryKey("Id", "CreatedAt")]
[Table("PenjualanBatchAddInfo")]
[Index("BatchId", "IdPenjualanBatch", Name = "IDX_PenjualanBatchAddInfo")]
public partial class PenjualanBatchAddInfo
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualanBatch { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string BatchId { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Info { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Value { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdPenjualanBatch")]
    [InverseProperty("PenjualanBatchAddInfos")]
    public virtual PenjualanBatch IdPenjualanBatchNavigation { get; set; } = null!;
}
