using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ProdukHarga")]
[Index("IdProduk", "TanggalAwal", "TanggalAkhir", Name = "IX_ProdukHarga", IsUnique = true)]
public partial class ProdukHarga
{
    [Key]
    public int Id { get; set; }

    public int IdProduk { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal HargaJual { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal HargaBeli { get; set; }

    public int MinimumPesanan { get; set; }

    public DateOnly TanggalAwal { get; set; }

    public DateOnly TanggalAkhir { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdProduk")]
    [InverseProperty("ProdukHargas")]
    public virtual Produk IdProdukNavigation { get; set; } = null!;
}
