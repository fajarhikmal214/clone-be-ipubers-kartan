using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("Gudang", Schema = "dbo_master")]
public partial class Gudang
{
    [Key]
    public int Id { get; set; }

    [StringLength(4)]
    [Unicode(false)]
    public string Kode { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string IdKab { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Alamat { get; set; } = null!;

    public short Status { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Lat { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Long { get; set; }

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

    [InverseProperty("IdGudangNavigation")]
    public virtual ICollection<GudangWilayah> GudangWilayahs { get; set; } = new List<GudangWilayah>();

    [ForeignKey("IdKab")]
    [InverseProperty("Gudangs")]
    public virtual MasterKabupaten IdKabNavigation { get; set; } = null!;
}
