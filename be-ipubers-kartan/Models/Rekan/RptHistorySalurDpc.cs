using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RptHistorySalurDPCS")]
public partial class RptHistorySalurDpc
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string KodeKios { get; set; } = null!;

    [Column("NIK")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? NamaPetani { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NamaDesa { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Kecamatan { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NamaKelompokTani { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Komoditas { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NoNota { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalNota { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Produk { get; set; }

    public double? Qty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
