using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("WcmF6")]
public partial class WcmF6
{
    [Key]
    public int IdItem { get; set; }

    [StringLength(12)]
    public string NoF6 { get; set; } = null!;

    [StringLength(10)]
    public string KodeDistributor { get; set; } = null!;

    [StringLength(191)]
    public string? NamaDistributor { get; set; }

    [StringLength(4)]
    public string KodeProdusen { get; set; } = null!;

    [StringLength(191)]
    public string? NamaProdusen { get; set; }

    [StringLength(191)]
    public string Month { get; set; } = null!;

    [StringLength(191)]
    public string Year { get; set; } = null!;

    [StringLength(4)]
    public string KodeKabupaten { get; set; } = null!;

    [StringLength(191)]
    public string? NamaKabupaten { get; set; }

    [StringLength(6)]
    public string KodeKecamatan { get; set; } = null!;

    [StringLength(191)]
    public string? NamaKecamatan { get; set; }

    [StringLength(3)]
    public string KodeProduk { get; set; } = null!;

    [StringLength(191)]
    public string? NamaProduk { get; set; }

    [StringLength(12)]
    public string KodeRetailer { get; set; } = null!;

    [StringLength(191)]
    public string? NamaRetailer { get; set; }

    public double? StokAwal { get; set; }

    public double? Penebusan { get; set; }

    public double? Penyaluran { get; set; }

    public double? StokAkhir { get; set; }

    [Column("STATUS")]
    [StringLength(1)]
    public string Status { get; set; } = null!;
}
