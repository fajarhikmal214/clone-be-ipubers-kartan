using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterTarget")]
public partial class MasterTarget
{
    [Key]
    public int Id { get; set; }

    public int Tahun { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string IdKab { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string JenisPenjualan { get; set; } = null!;

    [Column(TypeName = "decimal(18, 5)")]
    public decimal Gmv { get; set; }

    public int Transaksi { get; set; }

    [ForeignKey("IdKab")]
    [InverseProperty("MasterTargets")]
    public virtual MasterKabupaten IdKabNavigation { get; set; } = null!;
}
