using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("KalkulatorProduk")]
public partial class KalkulatorProduk
{
    [Key]
    public int Id { get; set; }

    public int KalkulatorId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nama { get; set; }

    public int? KuantitasTebus { get; set; }

    public int? KuantitasJual { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? HargaTebus { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? HargaJual { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalPengeluaran { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalPendapatan { get; set; }

    [ForeignKey("KalkulatorId")]
    [InverseProperty("KalkulatorProduks")]
    public virtual Kalkulator Kalkulator { get; set; } = null!;
}
