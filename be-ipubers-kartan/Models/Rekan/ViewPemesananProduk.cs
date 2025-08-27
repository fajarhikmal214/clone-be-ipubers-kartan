using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class ViewPemesananProduk
{
    [StringLength(50)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string IdPemesanan { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string ProdukKode { get; set; } = null!;

    [Column(TypeName = "numeric(18, 8)")]
    public decimal Qty { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal? Harga { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal? Total { get; set; }

    public int Satuan { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public decimal? SisaTotal { get; set; }

    public bool? IsTolak { get; set; }

    [Column("tanggal", TypeName = "datetime")]
    public DateTime? Tanggal { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Nota { get; set; }

    public byte? Status { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? RetailerId { get; set; }

    [Column(TypeName = "numeric(18, 2)")]
    public decimal? TotalPemesanan { get; set; }

    [StringLength(50)]
    public string? SatuanLabel { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? DistributorNama { get; set; }
}
