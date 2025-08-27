using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SpjbDetail", Schema = "dbo_master")]
public partial class SpjbDetail
{
    [Key]
    public int Id { get; set; }

    public int IdSpjb { get; set; }

    public int IdProdukRetailer { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    public int Qty { get; set; }

    public int QtyOpersional { get; set; }

    public int Tahun { get; set; }

    public int Bulan { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string IdKecamatan { get; set; } = null!;

    public short Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("SpjbDetails")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;

    [ForeignKey("IdSpjb")]
    [InverseProperty("SpjbDetails")]
    public virtual Spjb IdSpjbNavigation { get; set; } = null!;
}
