using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// Table untuk menyimpan informasi tambahan untuk kebutuhan log, tracing, dan analisa hasil AI Assistant
/// </summary>
[Table("PenjualanAddInfo")]
[Index("Info", "Value", Name = "IDX_Penjualan_AddInfo")]
[Index("CreatedAt", Name = "UK_Penjualan_AddInfo_CreatedAt")]
public partial class PenjualanAddInfo
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualan { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Info { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Value { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    [ForeignKey("IdPenjualan")]
    [InverseProperty("PenjualanAddInfos")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;
}
