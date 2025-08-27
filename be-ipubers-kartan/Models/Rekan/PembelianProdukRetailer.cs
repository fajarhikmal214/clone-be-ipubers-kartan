using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PembelianProdukRetailer")]
public partial class PembelianProdukRetailer
{
    [Key]
    public int Id { get; set; }

    public int IdPembelian { get; set; }

    public int IdProdukRetailer { get; set; }

    public double Qty { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Harga { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    [ForeignKey("IdPembelian")]
    [InverseProperty("PembelianProdukRetailers")]
    public virtual Pembelian IdPembelianNavigation { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("PembelianProdukRetailers")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
