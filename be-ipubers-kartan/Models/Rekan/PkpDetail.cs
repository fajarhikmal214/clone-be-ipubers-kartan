using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PkpDetail")]
public partial class PkpDetail
{
    [Key]
    [StringLength(128)]
    public string Id { get; set; } = null!;

    [StringLength(128)]
    public string IdPkp { get; set; } = null!;

    public int IdProdukRetailer { get; set; }

    [Column("KodeProdukWCM")]
    [StringLength(3)]
    public string? KodeProdukWcm { get; set; }

    [Column("KodeProdukRMS")]
    [StringLength(15)]
    [Unicode(false)]
    public string? KodeProdukRms { get; set; }

    public double Qty { get; set; }

    [Column("QtyRMS")]
    public double? QtyRms { get; set; }

    public double? Stok { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdPkp")]
    [InverseProperty("PkpDetails")]
    public virtual Pkp IdPkpNavigation { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("PkpDetails")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdPkpDetailNavigation")]
    public virtual ICollection<PenjualanProdukRetailerPkp> PenjualanProdukRetailerPkps { get; set; } = new List<PenjualanProdukRetailerPkp>();
}
