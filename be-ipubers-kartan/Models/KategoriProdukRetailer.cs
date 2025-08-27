using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("KategoriProdukRetailer")]
[Index("IdRetailer", "KodeKategori", Name = "IX_KategoriProdukRetailer", IsUnique = true)]
public partial class KategoriProdukRetailer
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string KodeKategori { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string NamaKategori { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    public byte Status { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("KategoriProdukRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdKategoriNavigation")]
    public virtual ICollection<ProdukRetailer> ProdukRetailers { get; set; } = new List<ProdukRetailer>();
}
