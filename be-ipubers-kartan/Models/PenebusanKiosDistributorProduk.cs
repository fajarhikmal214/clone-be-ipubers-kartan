using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenebusanKiosDistributorProduk", Schema = "dbo_tebus")]
public partial class PenebusanKiosDistributorProduk
{
    [Key]
    public int Id { get; set; }

    public int IdPenebusan { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    public int Qty { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? HargaBeli { get; set; }

    public int IdProdukRetailer { get; set; }

    public int Kelipatan { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Harga { get; set; }

    [ForeignKey("IdPenebusan")]
    [InverseProperty("PenebusanKiosDistributorProduks")]
    public virtual PenebusanKiosDistributor IdPenebusanNavigation { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("PenebusanKiosDistributorProduks")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
