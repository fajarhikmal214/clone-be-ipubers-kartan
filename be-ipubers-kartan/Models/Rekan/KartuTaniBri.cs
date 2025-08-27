using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("_KartuTaniBri")]
[Index("Nik", "RetailerId", Name = "IX__KartuTaniBri")]
public partial class KartuTaniBri
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("retailer_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string RetailerId { get; set; } = null!;

    [Column("product_id")]
    [StringLength(3)]
    [Unicode(false)]
    public string ProductId { get; set; } = null!;

    [Column("trx_date", TypeName = "datetime")]
    public DateTime TrxDate { get; set; }

    [Column("qty")]
    public int Qty { get; set; }

    [Column("amount", TypeName = "money")]
    public decimal Amount { get; set; }

    [Column("nik")]
    [StringLength(20)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [Column("farmer_name")]
    [StringLength(150)]
    [Unicode(false)]
    public string FarmerName { get; set; } = null!;

    [Column("farmer_address")]
    [StringLength(100)]
    [Unicode(false)]
    public string? FarmerAddress { get; set; }

    [Column("bank_code")]
    [StringLength(6)]
    [Unicode(false)]
    public string? BankCode { get; set; }

    [Column("rrn")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Rrn { get; set; }

    [Column("sync_date", TypeName = "datetime")]
    public DateTime SyncDate { get; set; }

    [Column("sync_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SyncBy { get; set; }

    [Column("filename")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Filename { get; set; }
}
