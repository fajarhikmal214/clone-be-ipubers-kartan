using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PantauStokDetail")]
[Index("IdProdukRetailer", Name = "idx_pantau_stock2")]
public partial class PantauStokDetail
{
    [Key]
    public int Id { get; set; }

    public int IdPantauStok { get; set; }

    public int IdProdukRetailer { get; set; }

    public double? Qty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(256)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdPantauStok")]
    [InverseProperty("PantauStokDetails")]
    public virtual PantauStok IdPantauStokNavigation { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("PantauStokDetails")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
