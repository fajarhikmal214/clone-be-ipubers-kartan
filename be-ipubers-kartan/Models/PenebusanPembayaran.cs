using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenebusanPembayaran", Schema = "dbo_tebus")]
public partial class PenebusanPembayaran
{
    [Key]
    public long PenebusanId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string IdBilling { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ExpiredAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TransactionId { get; set; }

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaidAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    public int? ChannelId { get; set; }

    [Column("MID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Mid { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Account { get; set; }

    [ForeignKey("PenebusanId")]
    [InverseProperty("PenebusanPembayaran")]
    public virtual Penebusan Penebusan { get; set; } = null!;
}
