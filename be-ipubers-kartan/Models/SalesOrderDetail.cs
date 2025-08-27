using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SalesOrderDetail", Schema = "dbo_tebus")]
public partial class SalesOrderDetail
{
    [Key]
    public long Id { get; set; }

    public long IdSalesOrder { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    public int IdProdukRetailer { get; set; }

    public int Qty { get; set; }

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
    [InverseProperty("SalesOrderDetails")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;

    [ForeignKey("IdSalesOrder")]
    [InverseProperty("SalesOrderDetails")]
    public virtual SalesOrder IdSalesOrderNavigation { get; set; } = null!;
}
