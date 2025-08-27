using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ProdukRetailerStokKecamatan")]
public partial class ProdukRetailerStokKecamatan
{
    [Key]
    public int Id { get; set; }

    public int IdProdukRetailer { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string IdKecamatan { get; set; } = null!;

    public double Stok { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdKecamatan")]
    [InverseProperty("ProdukRetailerStokKecamatans")]
    public virtual MasterKecamatan IdKecamatanNavigation { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("ProdukRetailerStokKecamatans")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
