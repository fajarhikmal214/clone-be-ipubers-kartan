using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("KartuTaniTransaksiDetail")]
[Index("KodeProduk", "AgentId", "TanggalAwal", "TanggalAkhir", Name = "IX_KartuTaniTransaksiDetail", IsUnique = true)]
public partial class KartuTaniTransaksiDetail
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string AgentId { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? NamaKios { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalAwal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalAkhir { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    public double Volume { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Amount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }
}
