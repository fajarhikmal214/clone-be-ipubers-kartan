using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("JurnalProduk")]
public partial class JurnalProduk
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualan { get; set; }

    public int IdReference { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalJurnal { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeJurnal { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Keterangan { get; set; } = null!;

    public double Qty { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Jumlah { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Subtotal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdPenjualan")]
    [InverseProperty("JurnalProduks")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;
}
