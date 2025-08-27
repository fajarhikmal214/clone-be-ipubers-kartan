using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenebusanProdukRetailer", Schema = "dbo_tebus")]
public partial class PenebusanProdukRetailer
{
    [Key]
    public long Id { get; set; }

    public long PenebusanId { get; set; }

    public int ProdukRetailerId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? KodeProdukSnd { get; set; }

    public int Qty { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? HargaBeli { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Total { get; set; }

    public int Kelipatan { get; set; }

    [StringLength(4)]
    public string? KodeProdusen { get; set; }

    [ForeignKey("KodeProdusen")]
    [InverseProperty("PenebusanProdukRetailers")]
    public virtual Produsen? KodeProdusenNavigation { get; set; }

    [ForeignKey("PenebusanId")]
    [InverseProperty("PenebusanProdukRetailers")]
    public virtual Penebusan Penebusan { get; set; } = null!;

    [ForeignKey("ProdukRetailerId")]
    [InverseProperty("PenebusanProdukRetailers")]
    public virtual ProdukRetailer ProdukRetailer { get; set; } = null!;
}
public class PenjualanProdukRetailerCreateDto
{
    public ProdukRetailerPenjualanCreateDto ProdukRetailer { get; set; }
    public decimal HargaJual { get; set; }
    public decimal HargaBeli { get; set; }
    public double Qty { get; set; }
    public string Catatan { get; set; }
    public int LevelHargaJual { get; set; }
}

public class ProdukRetailerPenjualanCreateDto
{
    public int Id { get; set; }
    public string KodeProduk { get; set; }
}
