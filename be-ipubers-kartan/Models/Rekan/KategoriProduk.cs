using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("KategoriProduk")]
[Index("KodeKategori", Name = "IX_KategoriProduk", IsUnique = true)]
public partial class KategoriProduk
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeKategori { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string NamaKategori { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

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

    [InverseProperty("IdKategoriNavigation")]
    public virtual ICollection<Produk> Produks { get; set; } = new List<Produk>();
}
