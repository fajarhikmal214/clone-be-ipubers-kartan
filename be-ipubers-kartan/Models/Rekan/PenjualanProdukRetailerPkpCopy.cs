using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PenjualanProdukRetailerPkpCopy")]
[Index("IdPenjualanProdukRetailer", "IdPkpDetail", Name = "IX_PenjualanProdukRetailerPkpCopy", IsUnique = true)]
[Index("Id", Name = "PenjualanProdukRetailerPkpCopy_Id_uindex", IsUnique = true)]
public partial class PenjualanProdukRetailerPkpCopy
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualanProdukRetailer { get; set; }

    [StringLength(128)]
    public string IdPkp { get; set; } = null!;

    [StringLength(128)]
    public string? IdPkpDetail { get; set; }

    public int? Qty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdPenjualanProdukRetailer")]
    [InverseProperty("PenjualanProdukRetailerPkpCopies")]
    public virtual PenjualanProdukRetailer IdPenjualanProdukRetailerNavigation { get; set; } = null!;

    [ForeignKey("IdPkpDetail")]
    [InverseProperty("PenjualanProdukRetailerPkpCopies")]
    public virtual PkpDetailCopy? IdPkpDetailNavigation { get; set; }
}
