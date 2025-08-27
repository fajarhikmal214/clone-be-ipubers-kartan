using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("ProdukRetailerTarget")]
public partial class ProdukRetailerTarget
{
    [Key]
    public long Id { get; set; }

    public int? ProdukRetailerId { get; set; }

    public int? Tahun { get; set; }

    public int? Bulan { get; set; }

    public int? TargetTransaksi { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? TargetGmv { get; set; }

    public int? MinAvailableQty { get; set; }

    [ForeignKey("ProdukRetailerId")]
    [InverseProperty("ProdukRetailerTargets")]
    public virtual ProdukRetailer? ProdukRetailer { get; set; }
}
