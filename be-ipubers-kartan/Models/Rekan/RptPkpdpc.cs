using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RptPKPDPCS")]
public partial class RptPkpdpc
{
    [Key]
    public int Id { get; set; }

    [Column("NoPKP")]
    [StringLength(20)]
    public string NoPkp { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Produsen { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Distributor { get; set; }

    [StringLength(12)]
    public string KodeKios { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalDiterima { get; set; }

    [Column("TanggalPKP", TypeName = "datetime")]
    public DateTime? TanggalPkp { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Produk { get; set; }

    public double? Qty { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Foto1 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Foto2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
