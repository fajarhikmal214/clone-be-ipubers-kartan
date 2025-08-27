using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ProdukRetailerStok")]
public partial class ProdukRetailerStok
{
    [Key]
    public int Id { get; set; }

    public int IdProdukRetailer { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? KodeTransaksiStok { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TglTransaksi { get; set; }

    public double StokAwal { get; set; }

    public double JumlahStok { get; set; }

    public double StokAkhir { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string TipeStok { get; set; } = null!;

    [StringLength(320)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("ProdukRetailerStoks")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
