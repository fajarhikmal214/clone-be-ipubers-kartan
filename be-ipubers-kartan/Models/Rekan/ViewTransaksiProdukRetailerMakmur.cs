using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class ViewTransaksiProdukRetailerMakmur
{
    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string NamaProduk { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal HargaJual { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal HargaBeli { get; set; }

    public double Qty { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string NamaSatuan { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string NamaKategori { get; set; } = null!;
}
