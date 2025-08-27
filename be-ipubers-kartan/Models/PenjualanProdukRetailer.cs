using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenjualanProdukRetailer")]
[Index("IdProdukRetailer", Name = "NCI_PenjualanProdukRetailer1")]
public partial class PenjualanProdukRetailer
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualan { get; set; }

    public int IdProdukRetailer { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal HargaJual { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal HargaBeli { get; set; }

    public double Qty { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    public int LevelHargaJual { get; set; }

    [ForeignKey("IdPenjualan")]
    [InverseProperty("PenjualanProdukRetailers")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("PenjualanProdukRetailers")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
