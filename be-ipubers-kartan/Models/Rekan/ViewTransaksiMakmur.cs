using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class ViewTransaksiMakmur
{
    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(12)]
    public string KodeKios { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalNota { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string StatusKode { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string StatusNama { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAtRegion { get; set; }

    [Column("TanggalNotaWIB", TypeName = "datetime")]
    public DateTime? TanggalNotaWib { get; set; }

    [StringLength(27)]
    [Unicode(false)]
    public string? KodePelanggan { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaPelanggan { get; set; }

    [Column("NIKPelanggan")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Nikpelanggan { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NoHpPelanggan { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? AlamatPelanggan { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? NoProjek { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? NamaProjek { get; set; }
}
