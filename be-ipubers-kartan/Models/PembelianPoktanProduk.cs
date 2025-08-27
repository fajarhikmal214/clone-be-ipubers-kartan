using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PembelianPoktanProduk", Schema = "dbo_point")]
public partial class PembelianPoktanProduk
{
    [Key]
    public int Id { get; set; }

    public int IdPembelianPetani { get; set; }

    public int IdProdukRetailer { get; set; }

    public int Qty { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal HargaJual { get; set; }

    [ForeignKey("IdPembelianPetani")]
    [InverseProperty("PembelianPoktanProduks")]
    public virtual PembelianPoktanPetani IdPembelianPetaniNavigation { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("PembelianPoktanProduks")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
