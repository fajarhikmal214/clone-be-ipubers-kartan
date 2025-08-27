using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LinkAja_Payment")]
public partial class LinkAjaPayment
{
    [Key]
    public Guid Id { get; set; }

    public string? Merchant { get; set; }

    public string? Terminal { get; set; }

    [StringLength(50)]
    public string? TrxType { get; set; }

    [StringLength(50)]
    public string? TrxDate { get; set; }

    [Column("TrxID")]
    [StringLength(150)]
    public string? TrxId { get; set; }

    [Column("MSISDN")]
    [StringLength(50)]
    public string? Msisdn { get; set; }

    public string? Msg { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Amount { get; set; }

    public string? IssuerName { get; set; }

    [Column(TypeName = "text")]
    public string? AdditionalData { get; set; }

    public string? FromAccount { get; set; }

    [StringLength(50)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
