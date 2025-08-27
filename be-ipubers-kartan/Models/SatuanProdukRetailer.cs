using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SatuanProdukRetailer")]
[Index("Id", Name = "IX_SatuanProdukRetailer", IsUnique = true)]
public partial class SatuanProdukRetailer
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string KodeSatuan { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string NamaSatuan { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public byte Status { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("SatuanProdukRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("SatuanNavigation")]
    public virtual ICollection<ProdukRetailer> ProdukRetailers { get; set; } = new List<ProdukRetailer>();
}
