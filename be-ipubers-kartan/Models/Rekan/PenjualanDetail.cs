using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PenjualanDetail")]
public partial class PenjualanDetail
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualan { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Persentase { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Nilai { get; set; }

    public double Qty { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Catatan { get; set; } = null!;

    [ForeignKey("IdPenjualan")]
    [InverseProperty("PenjualanDetails")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;
}
