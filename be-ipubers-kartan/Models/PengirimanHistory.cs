using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PengirimanHistory", Schema = "dbo_tebus")]
public partial class PengirimanHistory
{
    [Key]
    public int Id { get; set; }

    public int IdPengiriman { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string NamaTempat { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string Alamat { get; set; } = null!;

    public short IsTiba { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TibaAt { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Lat { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Long { get; set; }

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

    [ForeignKey("IdPengiriman")]
    [InverseProperty("PengirimanHistories")]
    public virtual Pengiriman IdPengirimanNavigation { get; set; } = null!;
}
