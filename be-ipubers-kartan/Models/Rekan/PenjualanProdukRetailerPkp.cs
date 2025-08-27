using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PenjualanProdukRetailerPkp")]
[Index("IdPenjualanProdukRetailer", "IdPkpDetail", Name = "PenjualanProdukRetailerPkp_IdPenjualanProdukRetailer_IdPkpDetail_uindex", IsUnique = true)]
[Index("Id", Name = "PenjualanProdukRetailerPkp_Id_uindex", IsUnique = true)]
public partial class PenjualanProdukRetailerPkp
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

    [Column("isSynced")]
    public int? IsSynced { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncedAt { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncDate { get; set; }

    [ForeignKey("IdPenjualanProdukRetailer")]
    [InverseProperty("PenjualanProdukRetailerPkps")]
    public virtual PenjualanProdukRetailer IdPenjualanProdukRetailerNavigation { get; set; } = null!;

    [ForeignKey("IdPkpDetail")]
    [InverseProperty("PenjualanProdukRetailerPkps")]
    public virtual PkpDetail? IdPkpDetailNavigation { get; set; }
}
