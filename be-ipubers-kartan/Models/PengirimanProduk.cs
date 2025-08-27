using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PengirimanProduk", Schema = "dbo_tebus")]
public partial class PengirimanProduk
{
    [Key]
    public int Id { get; set; }

    public int IdPengiriman { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string ProdukKode { get; set; } = null!;

    public int IdProdukRetailer { get; set; }

    public int Qty { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? KodeProdukWcm { get; set; }

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

    [ForeignKey("IdPengiriman")]
    [InverseProperty("PengirimanProduks")]
    public virtual Pengiriman IdPengirimanNavigation { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("PengirimanProduks")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
