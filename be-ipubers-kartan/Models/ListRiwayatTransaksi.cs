using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Keyless]
public partial class ListRiwayatTransaksi
{
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalNota { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? JenisProduk { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NamaKategori { get; set; } = null!;

    public double? NominalPenjualan { get; set; }
}
