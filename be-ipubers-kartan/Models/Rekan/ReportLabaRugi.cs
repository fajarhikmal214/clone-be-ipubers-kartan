using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ReportLabaRugi")]
public partial class ReportLabaRugi
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int Bulan { get; set; }

    public int Tahun { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalLapor { get; set; }

    public double Penjualan { get; set; }

    public double Penebusan { get; set; }

    public double Gaji { get; set; }

    public double PengeluaranLain { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("ReportLabaRugis")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
