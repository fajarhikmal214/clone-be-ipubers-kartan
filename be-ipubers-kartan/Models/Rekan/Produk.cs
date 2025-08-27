using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Produk")]
public partial class Produk
{
    [Key]
    public int Id { get; set; }

    [Column("IdWCM")]
    [StringLength(3)]
    public string? IdWcm { get; set; }

    public int IdKategori { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string NamaProduk { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Satuan { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? SatuanWcm { get; set; }

    public int? Kelipatan { get; set; }

    public int StatusProduk { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string JenisProduk { get; set; } = null!;

    [Column("HET", TypeName = "decimal(18, 2)")]
    public decimal? Het { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Produsen { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? Gambar { get; set; }

    public int? Urutan { get; set; }

    [ForeignKey("IdKategori")]
    [InverseProperty("Produks")]
    public virtual KategoriProduk IdKategoriNavigation { get; set; } = null!;

    [InverseProperty("IdProdukNavigation")]
    public virtual ICollection<ProdukHarga> ProdukHargas { get; set; } = new List<ProdukHarga>();

    [InverseProperty("IdProdukNavigation")]
    public virtual ICollection<Rdkkproduk> Rdkkproduks { get; set; } = new List<Rdkkproduk>();
}
