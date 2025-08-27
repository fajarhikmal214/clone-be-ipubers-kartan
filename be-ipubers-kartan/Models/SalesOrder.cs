using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SalesOrder", Schema = "dbo_tebus")]
[Index("NoSo", Name = "KEY_SalesOrder_NoSO", IsUnique = true)]
public partial class SalesOrder
{
    [Key]
    public long Id { get; set; }

    public long PenebusanId { get; set; }

    [Column("NoSO")]
    [StringLength(20)]
    [Unicode(false)]
    public string NoSo { get; set; } = null!;

    [Column("TanggalSO", TypeName = "datetime")]
    public DateTime TanggalSo { get; set; }

    [StringLength(4)]
    public string ProdusenId { get; set; } = null!;

    public int TransportirId { get; set; }

    public int GudangId { get; set; }

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

    [ForeignKey("GudangId")]
    [InverseProperty("SalesOrders")]
    public virtual GudangWilayah Gudang { get; set; } = null!;

    [ForeignKey("PenebusanId")]
    [InverseProperty("SalesOrders")]
    public virtual Penebusan Penebusan { get; set; } = null!;

    [ForeignKey("ProdusenId")]
    [InverseProperty("SalesOrders")]
    public virtual Produsen Produsen { get; set; } = null!;

    [InverseProperty("IdSalesOrderNavigation")]
    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
