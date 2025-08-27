using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[PrimaryKey("KodeProduk", "IdKecamatan")]
[Table("FormulaHarga", Schema = "dbo_master")]
public partial class FormulaHarga
{
    public int Id { get; set; }

    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    [StringLength(4)]
    public string Produsen { get; set; } = null!;

    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string IdKecamatan { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string ConditionType { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Harga { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalAwal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalAkhir { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Formula { get; set; } = null!;

    public short Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdKecamatan")]
    [InverseProperty("FormulaHargas")]
    public virtual MasterKecamatan IdKecamatanNavigation { get; set; } = null!;

    [ForeignKey("Produsen")]
    [InverseProperty("FormulaHargas")]
    public virtual Produsen ProdusenNavigation { get; set; } = null!;
}
