using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PenjualanProdukRetailerAlokasi")]
[Index("Id", Name = "PenjualanProdukRetailerAlokasi_Id_uindex", IsUnique = true)]
public partial class PenjualanProdukRetailerAlokasi
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualan { get; set; }

    public int IdProdukRetailer { get; set; }

    public int AlokasiAwal { get; set; }

    public int Qty { get; set; }

    public int AlokasiAkhir { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    [ForeignKey("IdPenjualan")]
    [InverseProperty("PenjualanProdukRetailerAlokasis")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("PenjualanProdukRetailerAlokasis")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
