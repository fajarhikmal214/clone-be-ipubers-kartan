using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PenjualanLog")]
public partial class PenjualanLog
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualan { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string KodeLog { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Deskripsi { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdPenjualan")]
    [InverseProperty("PenjualanLogs")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;
}
