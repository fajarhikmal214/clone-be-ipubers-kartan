using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("Produsen")]
public partial class Produsen
{
    [Key]
    [StringLength(4)]
    public string Code { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ShortName { get; set; }

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

    [InverseProperty("ProdusenNavigation")]
    public virtual ICollection<BankAnper> BankAnpers { get; set; } = new List<BankAnper>();

    [InverseProperty("ProdusenNavigation")]
    public virtual ICollection<FormulaHarga> FormulaHargas { get; set; } = new List<FormulaHarga>();

    [InverseProperty("KodeProdusenNavigation")]
    public virtual ICollection<PenebusanProdukRetailer> PenebusanProdukRetailers { get; set; } = new List<PenebusanProdukRetailer>();

    [InverseProperty("ProdusenNavigation")]
    public virtual ICollection<Pengiriman> Pengirimen { get; set; } = new List<Pengiriman>();

    [InverseProperty("ProdusenNavigation")]
    public virtual ICollection<ProdusenRegion> ProdusenRegions { get; set; } = new List<ProdusenRegion>();

    [InverseProperty("Produsen")]
    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();

    [InverseProperty("ProdusenNavigation")]
    public virtual ICollection<Spjb> Spjbs { get; set; } = new List<Spjb>();
}
