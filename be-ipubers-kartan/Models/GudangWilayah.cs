using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("GudangWilayah", Schema = "dbo_master")]
[Index("IdGudang", Name = "IDX_GudangWilayah_IdGudang")]
[Index("IdKabupaten", Name = "IDX_GudangWilayah_IdKabupaten")]
public partial class GudangWilayah
{
    [Key]
    public int Id { get; set; }

    public int IdGudang { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string IdKabupaten { get; set; } = null!;

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

    [ForeignKey("IdGudang")]
    [InverseProperty("GudangWilayahs")]
    public virtual Gudang IdGudangNavigation { get; set; } = null!;

    [ForeignKey("IdKabupaten")]
    [InverseProperty("GudangWilayahs")]
    public virtual MasterKabupaten IdKabupatenNavigation { get; set; } = null!;

    [InverseProperty("IdGudangNavigation")]
    public virtual ICollection<Pengiriman> Pengirimen { get; set; } = new List<Pengiriman>();

    [InverseProperty("Gudang")]
    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
