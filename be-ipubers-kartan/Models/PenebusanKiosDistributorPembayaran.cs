using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenebusanKiosDistributorPembayaran", Schema = "dbo_tebus")]
public partial class PenebusanKiosDistributorPembayaran
{
    [Key]
    public int IdPenebusan { get; set; }

    public short MetodeBayar { get; set; }

    public short Status { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IdBilling { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdPenebusan")]
    [InverseProperty("PenebusanKiosDistributorPembayaran")]
    public virtual PenebusanKiosDistributor IdPenebusanNavigation { get; set; } = null!;
}
